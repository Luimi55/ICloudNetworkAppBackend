using Application.Utils;
using Application.Utils.Interfaces;
using Domain.Entities;
using ErrorOr;
using Infrastructure.Data_Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Commands.SignUp
{
    public class SignUpHandler : IRequestHandler<SignUpCommand, ErrorOr<Guid>>
    {
        private readonly AppDbContext _context;
        private readonly IEncryptor _encryptor;

        public SignUpHandler(AppDbContext context, IEncryptor encryptor)
        {
            _context = context;
            _encryptor = encryptor;
        }

        public async Task<ErrorOr<Guid>> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            try
            {
                string encryptedPassword = _encryptor.Encrypt(request.Password!);
                
                User user = new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = encryptedPassword,
                    UserRoleId = request.UserRoleId,
                    Active = request.Active
                };

                _context.Add(user);
                await _context.SaveChangesAsync(cancellationToken);
                return user.Id;
            }
            catch (Exception ex)
            {
                return Error.Unexpected("Exception", ex.Message);
            }

        }
    }
}
