using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EmployeeReport.Modals
{
    public class EmployeeReportDto
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
