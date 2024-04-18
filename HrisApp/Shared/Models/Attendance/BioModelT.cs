using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrisApp.Shared.Models.Attendance
{
    public class BioModelT
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public int MachineNumber { get; set; }
        public int IndRegID { get; set; } //biometric id
        public string DateTimeRecord { get; set; } = string.Empty;

        public DateTime DateOnlyRecord { get; set; }
        public DateTime TimeOnlyRecord { get; set; }


        public string AttendanceType { get; set; } = string.Empty; //Biometric, Manual Entry, Mobile App

        public string IPAddress { get; set; } = string.Empty;
        public string Remarks { get; set; } = string.Empty;
    }
}
