using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrisApp.Shared.Models.Attendance
{
    public class ShiftTimetableT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Timetable_Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required")]
        public TimeSpan? OnDuty_Time {  get; set; }
        [Required(ErrorMessage = "This field is required")]
        public TimeSpan? OffDuty_Time {  get; set; }
        [Required(ErrorMessage = "This field is required")]
        public TimeSpan? Begin_C_In {  get; set; }
        [Required(ErrorMessage = "This field is required")]
        public TimeSpan? Ending_C_In {  get; set; }
        [Required(ErrorMessage = "This field is required")]
        public TimeSpan? Begin_C_Out { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public TimeSpan? Ending_C_Out { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Workday_Count { get; set; } = 1;
        [Required(ErrorMessage = "This field is required")]
        public int Minute_Count { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Late_Time { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int LeaveEarly_Time { get; set; }
        public bool Must_C_In { get; set; }
        public bool Must_C_Out { get; set; }
    }
}
