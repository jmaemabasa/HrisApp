namespace HrisApp.Client.Services.Attendance.TimetableS
{
#nullable disable
    public class TimetableService : ITimetableService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public TimetableService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<ShiftTimetableT> ShiftTimetableTs { get; set; }

        public async Task CreateTimetable(ShiftTimetableT obj)
        {
            var res = await _httpClient.PostAsJsonAsync("api/ShiftTimetable/CreateTimetable", obj);
        }

        public async Task GetTimetable()
        {
            var res = await _httpClient.GetFromJsonAsync<List<ShiftTimetableT>>("api/ShiftTimetable/CreateTimetable");
            if (res != null)
            {
                ShiftTimetableTs = res;
            }
        }

        public async Task<List<ShiftTimetableT>> GetTimetableList()
        {
            var res = await _httpClient.GetFromJsonAsync<List<ShiftTimetableT>>("api/ShiftTimetable/");
            if (res != null)
            {
                return res;
            }
            else { return null; }
        }

        public async Task<ShiftTimetableT> GetSingleTimetable(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ShiftTimetableT>($"api/ShiftTimetable/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task UpdateTimetable(ShiftTimetableT obj)
        {
            try
            {
                var res = await _httpClient.PutAsJsonAsync("api/ShiftTimetable/UpdateTimetable", obj);
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex + " hays");
            }
        }
    }
}
