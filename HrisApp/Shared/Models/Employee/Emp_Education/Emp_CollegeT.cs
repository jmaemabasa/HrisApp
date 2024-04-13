using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrisApp.Shared.Models.Emp_Education
{
    public class Emp_CollegeT
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //college
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
        public string CollSchoolName { get; set; } = string.Empty;
        public string CollSchoolLoc { get; set; } = string.Empty;
        public string CollAward { get; set; } = string.Empty;
        public string CollSchoolYear { get; set; } = string.Empty;
        public string CollCourse { get; set; } = string.Empty;
    }
}
