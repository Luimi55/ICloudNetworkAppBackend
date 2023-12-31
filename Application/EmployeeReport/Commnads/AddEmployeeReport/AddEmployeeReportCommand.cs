using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;

namespace Application.EmployeeReport.Commnads.AddEmployeeReport
{
    public class AddEmployeeReportCommand:IRequest<ErrorOr<int>>
    {
        public string OrderId { get; set; }
        public double Cost { get; set; }
        public int Hours { get; set; }
        public DateTime ReportDate { get; set; }
        public double Materials { get; set; }
        public double Parking { get; set; }
        public double Toll { get; set; }
        public double Milla { get; set; }
        public double Others { get; set; }
        public Guid UserId { get; set; }
    }
}
