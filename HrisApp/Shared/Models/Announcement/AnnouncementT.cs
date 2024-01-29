using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrisApp.Shared.Models.StaticData;

namespace HrisApp.Shared.Models.Announcement
{
    public class AnnouncementT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Ann_Code { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Title")]
        public string Ann_Title { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Description")]
        public string Ann_Desc { get; set; } = string.Empty;
        public StatusT? Status { get; set; }
        public int StatusId { get; set; } = 1;//FK

        [Required]
        [Display(Name = "Date Start")]
        public DateTime? DateStart { get; set; }
        [Required]
        [Display(Name = "Date End")]
        public DateTime? DateEnd { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;
    }
}
