using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Emp_Education
{
    public class Emp_PrimaryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        // public string PrimaryId { get; set; } = string.Empty;
        public string Verify_Id { get; set; } = string.Empty;

        //primary
        public string PriSchoolName { get; set; } = string.Empty;
        public string PriSchoolLoc { get; set; } = string.Empty;
        public string PriAward { get; set; } = string.Empty;
        public string PriSchoolYear { get; set; } = string.Empty;
    }
}
