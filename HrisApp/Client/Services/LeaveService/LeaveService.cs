namespace HrisApp.Client.Services.LeaveService
{
#nullable disable
    public class LeaveService : ILeaveService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public LeaveService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<LeaveTypesT> LeaveTypesTs { get; set; }

        public async Task<List<LeaveTypesT>> GetLeaveList()
        {
            return await _httpClient.GetFromJsonAsync<List<LeaveTypesT>>("api/Leave");
        }

        public async Task GetLeave()
        {
            var result = await _httpClient.GetFromJsonAsync<List<LeaveTypesT>>("api/Leave/GetLeave");
            if (result != null)
                LeaveTypesTs = result;
        }

        public async Task<LeaveTypesT> GetSingleLeave(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<LeaveTypesT>($"api/Leave/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }
        public async Task CreateLeave(string name, int unit, string desc)
        {
            LeaveTypesT areaT = new()
            {
                Name = name,
                Unit = unit,
                Description = desc
            };
            var result = await _httpClient.PostAsJsonAsync("api/Leave/CreateLeave", areaT);
        }

        public async Task UpdateLeave(LeaveTypesT obj)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Leave/UpdateLeave", obj);
        }
    }
}
