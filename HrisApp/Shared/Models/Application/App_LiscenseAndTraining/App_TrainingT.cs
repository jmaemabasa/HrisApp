using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.App_LiscenseAndTraining
{
    public class App_TrainingT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string? Verify_Id { get; set; }
        public string? TrainingName { get; set; } = string.Empty;
        public string? SponsorSpeaker { get; set; } = string.Empty;
        public DateTime? TrainingDate { get; set; } = DateTime.Now;
    }
}
