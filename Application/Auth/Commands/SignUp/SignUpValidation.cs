using Application.Messages;
using FluentValidation;
using Infrastructure.Data_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Commands.SignUp
{
    public class SignUpValidation : AbstractValidator<SignUpCommand>
    {
        private readonly AppDbContext _context;
        public SignUpValidation(AppDbContext context)
        {
            _context = context;

            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("FirstName"))
                .NotNull().WithErrorCode(ValidationMessages.IsRequired("FirstName"))
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLenght("FirstName", 50));

            RuleFor(e => e.LastName)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("LastName"))
                .NotNull().WithErrorCode(ValidationMessages.IsRequired("LastName"))
                .MaximumLength(50).WithMessage(ValidationMessages.MaxLenght("LastName", 50));

            RuleFor(e => e.Email)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("Email"))
                .NotNull().WithErrorCode(ValidationMessages.IsRequired("Email"))
                .MaximumLength(256).WithMessage(ValidationMessages.MaxLenght("Email", 256))
                .Matches("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$") //Common Email Regex format
                    .WithMessage(ValidationMessages.InvalidEmail("Email"));

            RuleFor(e => e.Password)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("Password"))
                .NotNull().WithMessage(ValidationMessages.IsRequired("Password"))
                .MaximumLength(256).WithMessage(ValidationMessages.MaxLenght("Password", 256));

            RuleFor(e => e.UserRoleId)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("UserRoleId"))
                .NotNull().WithMessage(ValidationMessages.IsRequired("UserRoleId"));
        }
    }
}
