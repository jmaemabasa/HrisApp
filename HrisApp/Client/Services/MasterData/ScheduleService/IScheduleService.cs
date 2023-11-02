namespace HrisApp.Client.Services.MasterData.ScheduleService
{
    public interface IScheduleService
    {
        List<ScheduleTypeT> ScheduleTs { get; set; }

        Task GetScheduleList();

        Task<ScheduleTypeT> GetSingleSchedule(int id);

        Task GetSchedule();

        Task CreateSchedule(string scheduleName, string timein, string timeout);

        Task UpdateSchedule(ScheduleTypeT schedule);
    }
}
