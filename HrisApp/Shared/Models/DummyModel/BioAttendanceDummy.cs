using HrisApp.Shared.Models.Employee;

namespace HrisApp.Shared.Models.DummyModel
{
    public class BioAttendanceDummy
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Verify_Id { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
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
