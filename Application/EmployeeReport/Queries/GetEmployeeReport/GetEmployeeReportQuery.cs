using Application.EmployeeReport.Modals;
using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeReport.Queries.GetEmployeeReport
{
    public record GetEmployeeReportQuery(Guid userId) : IRequest<ErrorOr<List<EmployeeReportDto>>>;
}