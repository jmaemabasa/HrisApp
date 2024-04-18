using System.Data;

namespace HrisApp.Client.Services.Attendance.BioAttendanceS
{
    public interface IBioAttendanceService
    {
        List<BioModelT> BioModelTs { get; set; }

        Task<List<BioModelT>> GetAttendanceRecList();
        Task<BioModelT> GetSingleAttendanceRec(int id);

        Task CreateAttendanceRec(BioModelT obj);
        Task<int> GetExistingCount(string time, string no);

        Task GetAttendanceRec();
    }
}
