using Application.Role.Models;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Role.Queries.GetAllRoles
{
    public record GetAllBasicRolesQuery():IRequest<ErrorOr<List<RoleDTO>>>;
}
