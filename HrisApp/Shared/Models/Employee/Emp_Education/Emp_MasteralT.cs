using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Emp_Education
{
    public class Emp_MasteralT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //Masteral
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
        public string MasSchoolName { get; set; } = string.Empty;
        public string MasSchoolLoc { get; set; } = string.Empty;
        public string MasAward { get; set; } = string.Empty;
        public string MasSchoolYear { get; set; } = string.Empty;
        public string MasCourse { get; set; } = string.Empty;
    }
}
