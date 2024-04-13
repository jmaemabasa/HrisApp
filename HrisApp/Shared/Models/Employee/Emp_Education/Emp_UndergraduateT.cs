using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Employee.Emp_Education
{
    public class Emp_UndergraduateT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //college
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
        public string UGSchoolName { get; set; } = string.Empty;
        public string UGSchoolLoc { get; set; } = string.Empty;
        public string UGAward { get; set; } = string.Empty;
        public string UGSchoolYear { get; set; } = string.Empty;
        public string UGCourse { get; set; } = string.Empty;
    }
}
