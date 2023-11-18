namespace HrisApp.Client.Services.MasterData.ScheduleService
{
    public class ScheduleService : IScheduleService
    {
#nullable disable
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public ScheduleService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<ScheduleTypeT> ScheduleTs { get; set; }

        public async Task GetScheduleList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ScheduleTypeT>>("api/Schedule");
            if (result != null)
                ScheduleTs = result;
        }

        public async Task<ScheduleTypeT> GetSingleSchedule(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ScheduleTypeT>($"api/Schedule/{id}");
            if (result != null)
                return result;
            throw new Exception("document not found");
        }

        public async Task GetSchedule()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ScheduleTypeT>>("/api/Schedule/GetSchedule");
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

            var result = await _httpClient.PostAsJsonAsync("api/Schedule/CreateSchedule", sched);
        }

        public async Task UpdateSchedule(ScheduleTypeT schedule)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Schedule/UpdateSchedule", schedule);
        }
    }
}
