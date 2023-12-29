using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Employee
{
    public class Emp_LeaveHistoryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
        public string LeaveType { get; set; } = string.Empty;
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public int NoOfDays { get; set; }
        public string Purpose { get; set; } = string.Empty;
    }
}
