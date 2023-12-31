using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Commands.SignUp
{
    public class SignUpCommand : IRequest<ErrorOr<Guid>>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int UserRoleId { get; set; }
        public bool Active { get; set; }
    }
}
