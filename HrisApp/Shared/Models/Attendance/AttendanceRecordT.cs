using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Attendance
{
    public class AttendanceRecordT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Biometric ID")]
        public string AC_No { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Time")]
        public DateTime? Time { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; } = string.Empty;
        public string NewState { get; set; } = string.Empty;
        public string Exception { get; set; } = string.Empty;
        public string Operation { get; set; } = string.Empty;
    }
}
