using HrisApp.Shared.Models.SettingsM;

namespace HrisApp.Client.Services.SettingsS.ExtractLogsService
{
#nullable disable
    public class ExtractLogsService : IExtractLogsService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public ExtractLogsService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<ExtractLogsModel> ExtractLogsModels { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<ExtractLogsModel>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<ExtractLogsModel>>("api/ExtractLogs");
        }

        public async Task<ExtractLogsModel> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ExtractLogsModel>($"api/ExtractLogs/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task<ExtractLogsModel> GetExtractingModel()
        {
            var result = await _httpClient.GetFromJsonAsync<ExtractLogsModel>($"api/ExtractLogs/GetExtractingModel");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task<ExtractLogsModel> GetExtractingCheckingModel()
        {
            var result = await _httpClient.GetFromJsonAsync<ExtractLogsModel>($"api/ExtractLogs/GetExtractingCheckingModel");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ExtractLogsModel>>("api/ExtractLogs/GetObj");
            if (result != null)
                ExtractLogsModels = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(ExtractLogsModel model)
        {
            await _httpClient.PostAsJsonAsync("api/ExtractLogs/CreateObj", model);
        }

        public async Task UpdateObj(ExtractLogsModel model)
        {
            await _httpClient.PutAsJsonAsync("api/ExtractLogs/UpdateObj", model);
        }

        public async Task<int> GetExistExtract(string status)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/ExtractLogs/GetExistExtract?status={status}");
                return result;
        }
        public async Task<string> CleanLogs()
        {
            var response = await _httpClient.GetAsync("api/ExtractLogs/CleanLogs");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

    }
}
