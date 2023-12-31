using Application.EmployeeReport.Commnads.AddEmployeeReport;
using Application.EmployeeReport.Modals;
using Application.EmployeeReport.Queries.GetEmployeeReport;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ICloudNetworkApp.Controllers
{
    public class EmployeeReportController:ApiControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeReportController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost ]
        public async Task<IActionResult> AddEmployeeReport([FromBody] AddEmployeeReportCommand command)
        {
            ErrorOr<int> result = await _mediator.Send(command);
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeReport([FromQuery] GetEmployeeReportQuery query)
        {
            ErrorOr<List<EmployeeReportDto>> result = await _mediator.Send(query);
            return result.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }
    }
}
