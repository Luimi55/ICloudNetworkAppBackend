using Application.Role.Models;
using Application.Role.Queries.GetAllRoles;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ICloudNetworkApp.Controllers
{
    public class RoleController : ApiControllerBase
    {
        public IMediator _mediator { get; set; }
        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBasicRoles()
        {
            ErrorOr<List<RoleDTO>> result = await _mediator.Send(new GetAllBasicRolesQuery());
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }
    }
}
