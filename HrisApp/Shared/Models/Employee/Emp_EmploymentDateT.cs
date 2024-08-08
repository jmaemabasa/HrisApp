using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Employee
{
    public class Emp_EmploymentDateT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;

        public int EmpmentStatusId { get; set; }

        //prob
        public DateTime? ProbationStartDate { get; set; }
        public DateTime? ProbationEndDate { get; set; }

        //casual
        public DateTime? CasualStartDate { get; set; }
        public DateTime? CasualEndDate { get; set; }

        //regular
        public DateTime? RegularizationDate { get; set; }
        public DateTime? ResignationDate { get; set; }

        //casual
        public DateTime? FixedStartDate { get; set; }
        public DateTime? FixedEndDate { get; set; }

        //proj
        public DateTime? ProjStartDate { get; set; }
        public DateTime? ProjEndDate { get; set; }
    }
}
