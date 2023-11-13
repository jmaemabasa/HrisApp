using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Emp_Education
{
    public class Emp_SeniorHST
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //shs
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
        public string ShsSchoolName { get; set; } = string.Empty;
        public string ShsSchoolLoc { get; set; } = string.Empty;
        public string ShsAward { get; set; } = string.Empty;
        public string ShsSchoolYear { get; set; } = string.Empty;
    }
}
