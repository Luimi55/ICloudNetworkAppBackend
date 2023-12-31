using Application.Auth.Services;
using Microsoft.Extensions.Options;

namespace ICloudNetworkApp.Setups
{
    public class JwtOptionsSetup : IConfigureOptions<JwtOptions>
    {
        private readonly string SectionName = "Jwt";
        private readonly IConfiguration _configuration;

        public JwtOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
