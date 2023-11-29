using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Employee
{
    public class EmployeeEvaluationT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [ForeignKey("EmployeeVerifyId")]
        public EmployeeT? Employee { get; set; }

        public string EmployeeVerifyId { get; set; } = string.Empty;
        public string Eval1Status { get; set; } = string.Empty;
        public string Eval2Status { get; set; } = string.Empty;
        public string Eval3Status { get; set; } = string.Empty;
        public string Eval4Status { get; set; } = string.Empty;
        public string Eval5Status { get; set; } = string.Empty;
        public string Eval6Status { get; set; } = string.Empty;
        public string EvalStatus { get; set; } = string.Empty;

    }
}
