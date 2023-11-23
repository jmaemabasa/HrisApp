using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.App_LiscenseAndTraining
{
    public class App_LicenseT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string? Verify_Id { get; set; }
        public string? Examination { get; set; } = string.Empty;
        public string? LicenseNo { get; set; } = string.Empty;
        public string? Rating { get; set; } = string.Empty;
        public DateTime? Date { get; set; }
    }
}
