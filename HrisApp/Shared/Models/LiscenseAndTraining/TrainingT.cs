using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.LiscenseAndTraining
{
    public class TrainingT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string? TrainingName { get; set; } = string.Empty;
        public string? SponsorSpeaker { get; set; } = string.Empty;
        public DateTime? TrainingDate { get; set; } = DateTime.Now;
        public string? Verify_Id { get; set; }
    }
}
