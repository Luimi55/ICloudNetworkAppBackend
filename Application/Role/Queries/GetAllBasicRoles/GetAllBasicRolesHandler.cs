using Application.Role.Models;
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

namespace Application.Role.Queries.GetAllRoles
{
    public class GetAllBasicRolesHandler : IRequestHandler<GetAllBasicRolesQuery, ErrorOr<List<RoleDTO>>>
    {
        private readonly AppDbContext _context;

        public GetAllBasicRolesHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<List<RoleDTO>>> Handle(GetAllBasicRolesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                List<UserRole> userRoles = await _context.UserRole
                    .Where(role=> role.Name != "Admin")
                    .AsNoTracking()
                    .ToListAsync();
                List<RoleDTO> listRoleDTO = new();
                foreach (UserRole userRole in userRoles)
                {
                    RoleDTO roleDTO = new()
                    {
                        Id = userRole.Id,
                        Name = userRole.Name,
                    };
                    listRoleDTO.Add(roleDTO);
                }
                return listRoleDTO;
            }
            catch (Exception ex)
            {
                return Error.Unexpected("Exception", ex.Message);
            }
        }
    }
}
