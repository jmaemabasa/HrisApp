namespace HrisApp.Client.Services.MasterData.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
#nullable disable
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ScheduleService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<ScheduleTypeT> ScheduleTs { get; set; }

        public async Task GetScheduleList()
        {
            var result = await _http.GetFromJsonAsync<List<ScheduleTypeT>>("api/Schedule");
            if (result != null)
                ScheduleTs = result;
        }

        public async Task<ScheduleTypeT> GetSingleSchedule(int id)
        {
            throw new NotImplementedException();
        }

        public async Task GetSchedule()
        {
            var result = await _http.GetFromJsonAsync<List<ScheduleTypeT>>("/api/Schedule/GetSchedule");
            if (result != null)
            {
                ScheduleTs = result;
            }
        }

        public async Task CreateSchedule(string scheduleName, string timein, string timeout)
        {
            ScheduleTypeT sched = new ScheduleTypeT
            {
                Name = scheduleName,
                TimeIn = timein,
                TimeOut = timeout
                
            };

            var result = await _http.PostAsJsonAsync("api/Schedule/CreateSchedule", sched);
        }

        public async Task UpdateSchedule(ScheduleTypeT schedule)
        {
            var result = await _http.PutAsJsonAsync($"api/Schedule/UpdateSchedule", schedule);
        }
    }
}
