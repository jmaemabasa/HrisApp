using System.Data;

namespace HrisApp.Client.Services.Attendance.AttendanceRecS
{
    public interface IAttendanceRecService
    {
        List<AttendanceRecordT> AttendanceRecordTs { get; set; }

        Task<List<AttendanceRecordT>> GetAttendanceRecList();
        Task<AttendanceRecordT> GetSingleAttendanceRec(int id);

        Task CreateAttendanceRec(AttendanceRecordT obj);
        Task GetAttendanceRec();

        Task<int> GetExistingCount(string time, string no, string state);

        Task<string> QueryAttendanceForUpload(DataTable dtable, string filename);
    }
}
