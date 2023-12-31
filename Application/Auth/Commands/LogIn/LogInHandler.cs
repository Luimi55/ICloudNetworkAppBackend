using Application.Auth.Services.Interfaces;
using Application.Utils.Interfaces;
using Domain.Entities;
using ErrorOr;
using Infrastructure.Data_Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Commands.SignIn
{
    public class LogInHandler: IRequestHandler<LogInCommand, ErrorOr<string>>
    {
        public readonly AppDbContext _context;
        public readonly IJwtProvider _jwtProvider;
        public readonly IEncryptor _encryptor;

        public LogInHandler(AppDbContext context, IJwtProvider jwtProvider, IEncryptor encryptor)
        {
            _context = context;
            _jwtProvider = jwtProvider;
            _encryptor = encryptor;
        }

        public async Task<ErrorOr<string>> Handle(LogInCommand request, CancellationToken cancellationToken)
        {
            
            string requestEmail = request.Email;
            string encryptedPassword = _encryptor.Encrypt(request.Password);

            try
            {
                User? user = await  _context.User
                    .AsNoTracking()
                    .FirstOrDefaultAsync(user =>
                    user.Email == requestEmail &&
                    user.Password == encryptedPassword
                );
                if (user != null && user.Active)
                {
                    string userToken = _jwtProvider.Generate(user);
/*                    LogInResponse response = new()
                    {
                        Id = user.Id,
                        FirstName = user.FirstName, 
                        LastName = user.LastName,
                        Email = user.Email,
                        UserRoleId = user.UserRoleId,
                        Active = user.Active,
                        Token = userToken
                    };*/
                    return userToken;
                }
                else
                {
                    return Error.Custom((int)ErrorType.Unauthorized, "401", "Unauthorized");
                }
            }
            catch (Exception ex)
            {
                return Error.Unexpected("Exception", ex.Message);
            }
        }
    }
}
