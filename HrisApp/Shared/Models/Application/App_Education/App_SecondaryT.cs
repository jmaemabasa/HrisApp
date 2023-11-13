using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.App_Education
{
    public class App_SecondaryT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        //Secondary
        public int Id { get; set; }
        public string Verify_Id { get; set; } = string.Empty;
        public string SecSchoolName { get; set; } = string.Empty;
        public string SecSchoolLoc { get; set; } = string.Empty;
        public string SecAward { get; set; } = string.Empty;
        public string SecSchoolYear { get; set; } = string.Empty;
    }
}
