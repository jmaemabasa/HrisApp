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
    }
}
