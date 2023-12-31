using Application.Auth.Commands.SignIn;
using Application.Auth.Commands.SignUp;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ICloudNetworkApp.Controllers
{
    public class AuthController : ApiControllerBase
    {
        public IMediator _mediator { get; set; }
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignUpCommand command)
        {
            ErrorOr<Guid> result = await _mediator.Send(command);
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] LogInCommand command)
        {
            ErrorOr<string> result = await _mediator.Send(command);
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }
    }
}
