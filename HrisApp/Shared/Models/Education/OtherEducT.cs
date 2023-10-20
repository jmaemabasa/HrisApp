using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Education
{
    public class OtherEducT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //Others
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
        public string OthersSchoolType { get; set; } = string.Empty;
        public string OthersSchoolName { get; set; } = string.Empty;
        public string OthersSchoolLoc { get; set; } = string.Empty;
        public string OthersAward { get; set; } = string.Empty;
        public string OthersSchoolYear { get; set; } = string.Empty;
        public string OthersCourse { get; set; } = string.Empty;
    }
}
