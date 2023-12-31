using Application.EmployeeReport.Modals;
using Domain.Entities;
using ErrorOr;
using Infrastructure.Data_Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeReport.Queries.GetEmployeeReport
{
    public class GetEmployeeReportHandler : IRequestHandler<GetEmployeeReportQuery, ErrorOr<List<EmployeeReportDto>>>
    {
        private readonly AppDbContext _context;
        public GetEmployeeReportHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ErrorOr<List<EmployeeReportDto>>> Handle(GetEmployeeReportQuery request, CancellationToken cancellationToken)
        {

            try
            {
                List<Domain.Entities.EmployeeReport> employeeReports = _context
                .EmployeeReport
                .Where(ep => ep.UserId == request.userId)
                .ToList();

                List<EmployeeReportDto> employeeReportDtos = new();

                foreach (Domain.Entities.EmployeeReport employeeReport in employeeReports)
                {
                    EmployeeReportDto employeeReportDto = new()
                    {
                        OrderId = employeeReport.OrderId,
                        Cost = employeeReport.Cost,
                        Hours = employeeReport.Hours,
                        ReportDate = employeeReport.ReportDate,
                        Materials = employeeReport.Materials,
                        Parking = employeeReport.Parking,
                        Toll = employeeReport.Toll,
                        Milla = employeeReport.Milla,
                        Others = employeeReport.Others,
                        UserId = employeeReport.UserId
                    };

                    employeeReportDtos.Add(employeeReportDto);
                }

                return employeeReportDtos;
            }
            catch (Exception ex)
            {
                return Error.Unexpected("Exception", ex.Message);
            }



        }
    }
}
