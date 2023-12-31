using Application.Auth.Commands.SignUp;
using Application.Messages;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Data_Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeReport.Commnads.AddEmployeeReport
{
    public class AddEmployeeReportValidation: AbstractValidator<AddEmployeeReportCommand>
    {

        private readonly AppDbContext _context;
        
        public AddEmployeeReportValidation(AppDbContext context) {

            _context = context;

            RuleFor(e => e.OrderId)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("OrderId"))
                .NotNull().WithMessage(ValidationMessages.IsRequired("OrderId"))
                .MaximumLength(30).WithMessage(ValidationMessages.MaxLenght("OrderId", 30));

            RuleFor(e => e.Cost)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("Cost"))
                .NotNull().WithMessage(ValidationMessages.IsRequired("Cost"));

            RuleFor(e => e.Hours)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("Hours"))
                .NotNull().WithMessage(ValidationMessages.IsRequired("Hours"));

            RuleFor(e => e.ReportDate)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("ReportDate"))
                .NotNull().WithMessage(ValidationMessages.IsRequired("ReportDate"));

            RuleFor(e => e.UserId)
                .NotEmpty().WithMessage(ValidationMessages.IsRequired("UserId"))
                .NotNull().WithMessage(ValidationMessages.IsRequired("UserId"))
                .MustAsync((userId, CancellationToken) =>  UserExist(userId)).WithMessage(
                    ValidationMessages.NotExist("UserId")
                ); ;

        }

        private async Task<bool> UserExist(Guid userId)
        {
           bool userExist = await _context.User.AnyAsync(user => user.Id == userId);
           return userExist;
        }
    }
}
