using HrisApp.Shared.Models.Employee;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Audit
{
    public class AuditLogsArchiveT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public EmployeeT? EmployeeUSer { get; set; } //FK
        public int EmployeeUserId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
    }
}
