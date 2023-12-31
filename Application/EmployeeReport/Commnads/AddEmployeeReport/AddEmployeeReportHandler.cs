using Domain.Entities;
using ErrorOr;
using Infrastructure.Data_Context;
using MediatR;


namespace Application.EmployeeReport.Commnads.AddEmployeeReport
{
    public class AddEmployeeReportHandler : IRequestHandler<AddEmployeeReportCommand, ErrorOr<int>>
    {
        private readonly AppDbContext _context;

        public AddEmployeeReportHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ErrorOr<int>> Handle(AddEmployeeReportCommand request, CancellationToken cancellationToken)
        {

            try
            {
                Domain.Entities.EmployeeReport employeeReport = new()
                {
                    OrderId = request.OrderId,
                    Cost = request.Cost,
                    Hours = request.Hours,
                    ReportDate = request.ReportDate,
                    Materials = request.Materials,
                    Parking = request.Parking,
                    Toll = request.Toll,
                    Milla = request.Milla,
                    Others = request.Others,
                    UserId = request.UserId
                };

                _context.EmployeeReport.Add(employeeReport);

                await _context.SaveChangesAsync();

                return employeeReport.Id;
            }
            catch (Exception ex)
            {
                return Error.Unexpected("Exception", ex.Message);
            }



        }
    }
}
