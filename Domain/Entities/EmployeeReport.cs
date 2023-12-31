using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Intefaces;

namespace Domain.Entities
{
    public class EmployeeReport:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(30)]
        public string OrderId { get; set; }

        [Required]
        [Column(TypeName = "decimal(16, 2)")]
        public double Cost { get; set; }

        [Required]
        public int Hours { get; set; }

        [Required]
        public DateTime ReportDate { get; set; }

        [Column(TypeName = "decimal(16, 2)")]
        public double Materials { get; set; }

        [Column(TypeName = "decimal(16, 2)")]
        public double Parking { get; set; }

        [Column(TypeName = "decimal(16, 2)")]
        public double Toll { get; set; }

        [Column(TypeName = "decimal(16, 2)")]
        public double Milla { get; set; }

        [Column(TypeName = "decimal(16, 2)")]
        public double Others { get; set; }

        [ForeignKey("Fk_EmployeeReport_User")]
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public EmployeeReport() { }

        public EmployeeReport(int id, string orderId, double cost, int hours, DateTime reportDate, double materials, double parking, double toll, double milla, double others, Guid userId)
        {
            Id = id;
            OrderId = orderId;
            Cost = cost;
            Hours = hours;
            ReportDate = reportDate;
            Materials = materials;
            Parking = parking;
            Toll = toll;
            Milla = milla;
            Others = others;
            UserId = userId;
        }
    }
}
