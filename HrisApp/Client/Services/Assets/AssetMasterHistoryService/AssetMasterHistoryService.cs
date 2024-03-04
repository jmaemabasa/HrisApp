namespace HrisApp.Client.Services.Assets.AssetMasterHistoryService
{
#nullable disable

    public class AssetMasterHistoryService : IAssetMasterHistoryService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssetMasterHistoryService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetMasterHistoryT> AssetMasterHistoryTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetMasterHistoryT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetMasterHistoryT>>("api/AssetMasterHistory");
        }

        public async Task<AssetMasterHistoryT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetMasterHistoryT>($"api/AssetMasterHistory/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetMasterHistoryT>>("api/AssetMasterHistory/GetObj");
            if (result != null)
                AssetMasterHistoryTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetMasterHistoryT model)
        {
            await _httpClient.PostAsJsonAsync("api/AssetMasterHistory/CreateObj", model);
        }

        public async Task UpdateObj(AssetMasterHistoryT model)
        {
            await _httpClient.PutAsJsonAsync("api/AssetMasterHistory/UpdateObj", model);
        }

        public async Task UpdateDateReturned(int empid, int mainassetid, DateTime? released, DateTime? toreturn, AssetMasterHistoryT model)
        {
            await _httpClient.PutAsJsonAsync($"api/AssetMasterHistory/UpdateDateReturned?empid={empid}&mainassetid={mainassetid}&released={released}&toreturn={toreturn}", model);
        }
    }
}