using HrisApp.Shared.Models.SettingsM;

namespace HrisApp.Client.Services.SettingsS.BioIPService
{
#nullable disable
    public class BioIPService : IBioIPService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public BioIPService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<BioIPModel> BioIPModels { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<BioIPModel>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<BioIPModel>>("api/BioIP");
        }

        public async Task<BioIPModel> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<BioIPModel>($"api/BioIP/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<BioIPModel>>("api/BioIP/GetObj");
            if (result != null)
                BioIPModels = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(BioIPModel model)
        {
            await _httpClient.PostAsJsonAsync("api/BioIP/CreateObj", model);
        }

        public async Task UpdateObj(BioIPModel model)
        {
            await _httpClient.PutAsJsonAsync("api/BioIP/UpdateObj", model);
        }
    }
}
