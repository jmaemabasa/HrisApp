using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Education
{
    public class DoctorateT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //Doctorate
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
        public string DocSchoolName { get; set; } = string.Empty;
        public string DocSchoolLoc { get; set; } = string.Empty;
        public string DocAward { get; set; } = string.Empty;
        public string DocSchoolYear { get; set; } = string.Empty;
        public string DocCourse { get; set; } = string.Empty;
    }
}
