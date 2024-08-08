namespace HrisApp.Client.Services.Attendance.BioAttendanceS
{
#nullable disable
    public class BioAttendanceService : IBioAttendanceService
    {
        MainsService _mainService = new();
        private readonly HttpClient _httpClient;
        public BioAttendanceService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<BioModelT> BioModelTs { get; set; }

        public async Task CreateAttendanceRec(BioModelT obj)
        {
            await _httpClient.PostAsJsonAsync("api/BioAttendance/CreateAttendanceRecord", obj);
        }

        public async Task GetAttendanceRec()
        {
            var res = await _httpClient.GetFromJsonAsync<List<BioModelT>>("api/BioAttendance/GetAttendanceRecord");
            if (res != null)
            {
                BioModelTs = res;
            }
        }

        public async Task<List<BioModelT>> GetAttendanceRecList()
        {
            var res = await _httpClient.GetFromJsonAsync<List<BioModelT>>("api/BioAttendance");
            if (res != null)
            {
                return res;
            }
            else { return null; }
        }

        public async Task<BioModelT> GetSingleAttendanceRec(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<BioModelT>($"api/BioAttendance/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }


        //GET NUMBER OBJECTS COUNT
        public async Task<int> GetExistingCount(string time, string no)
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/BioAttendance/GetExistingObj?time={time}&no={no}");
        }

        public async Task<string> CleanLogs()
        {
            var response = await _httpClient.GetAsync("api/BioAttendance/CleanLogs");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
