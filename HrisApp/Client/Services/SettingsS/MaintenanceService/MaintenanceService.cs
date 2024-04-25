namespace HrisApp.Client.Services.SettingsS.MaintenanceService
{
#nullable disable
    public class MaintenanceService : IMaintenanceService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public MaintenanceService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<MaintenanceT> MaintenanceTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<MaintenanceT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<MaintenanceT>>("api/Maintenance");
        }

        public async Task<List<MaintenanceT>> GetAllActivesObj()
        {
            return await _httpClient.GetFromJsonAsync<List<MaintenanceT>>("api/Maintenance/GetAllActivesObj");
        }

        public async Task<MaintenanceT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<MaintenanceT>($"api/Maintenance/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<MaintenanceT>>("api/Maintenance/GetObj");
            if (result != null)
                MaintenanceTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(MaintenanceT model)
        {
            await _httpClient.PostAsJsonAsync("api/Maintenance/CreateObj", model);
        }

        public async Task UpdateObj(MaintenanceT model)
        {
            await _httpClient.PutAsJsonAsync("api/Maintenance/UpdateObj", model);
        }
        public async Task<bool> GetIsMaintain()
        {
            return await _httpClient.GetFromJsonAsync<bool>("api/Maintenance/GetIsMaintain");
        }
    }
}
