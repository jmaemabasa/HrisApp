using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Employee
{
    public class Emp_ProfBackgroundT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
        public DateTime? DateFrom { get; set; } = DateTime.Now;
        public DateTime? DateTo { get; set; } = DateTime.Now;
        public string CompanyName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string BasicSalary { get; set; } = string.Empty;
        public string RSLeaving { get; set; } = string.Empty;
    }
}
