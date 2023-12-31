using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Auth.Commands.SignIn
{
    public class LogInCommand:IRequest<ErrorOr<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
