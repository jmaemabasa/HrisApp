namespace HrisApp.Client.Services.Attendance.TimetableS
{
    public interface ITimetableService
    {
        List<ShiftTimetableT> ShiftTimetableTs { get; set; }

        Task<List<ShiftTimetableT>> GetTimetableList();
        Task<ShiftTimetableT> GetSingleTimetable(int id);

        Task CreateTimetable(ShiftTimetableT obj);
        Task UpdateTimetable(ShiftTimetableT obj);
        Task GetTimetable();
    }
}
