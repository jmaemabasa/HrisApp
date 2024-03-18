using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Employee
{
    public class Emp_EvaluationT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string Verify_Id { get; set; } = string.Empty;
        public string Eval1Status { get; set; } = string.Empty;
        public string Eval2Status { get; set; } = string.Empty;
        public string Eval3Status { get; set; } = string.Empty;

        //public string Eval4Status { get; set; } = string.Empty;
        public string Eval5Status { get; set; } = string.Empty;

        //public string Eval6Status { get; set; } = string.Empty;
        public string EvalStatus { get; set; } = string.Empty;

        public DateTime DateHired { get; set; }
        public DateTime? DateEvaluate { get; set; }
        public int TimesEvaluate { get; set; }
    }
}