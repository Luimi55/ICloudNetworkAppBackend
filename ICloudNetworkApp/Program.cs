using Application.Auth.Commands;
using Infrastructure.Data_Context;
using Application;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Application.Auth.Services.Interfaces;
using Application.Auth.Services;
using Application.Utils;
using Application.Utils.Interfaces;
using ICloudNetworkApp.Setups;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Appsettings
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
string issuer = builder.Configuration.GetSection("Jwt").GetValue<string>("Issuer");
string audience = builder.Configuration.GetSection("Jwt").GetValue<string>("Audience");
string secretKey = builder.Configuration.GetSection("Jwt").GetValue<string>("SecretKey");

//Configure Connection YO
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

// Add services to the container.
builder.Services.ConfigureServices();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IEncryptor, Encryptor>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(o => o.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secretKey)
        ),
    });

builder.Services.ConfigureOptions<JwtOptionsSetup>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", policy =>
    {
        policy.SetIsOriginAllowed(origin=>new Uri(origin).Host == "localhost")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// YO
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var context = service.GetRequiredService<AppDbContext>();
    DbInitializer.Initialize(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseCors("cors");

app.MapControllers();

app.Run();
