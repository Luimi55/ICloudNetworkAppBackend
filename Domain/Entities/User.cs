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
    public class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Pk_ParticipantID")]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar")]
        [MaxLength(50)]
        public string? LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(256)]
        public string? Password { get; set; }

        [ForeignKey("Fk_User_UserRole")]
        public int UserRoleId { get; set; }
        public UserRole? UserRole { get; set; }

        [Required]
        public bool Active { get; set; } = false;

        public ICollection<EmployeeReport>? EmployeeReports { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User() { }

        public User(string? firstName, string? lastName, string? email, string? password, int userRoleId)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            UserRoleId = userRoleId;
        }
    }
}
