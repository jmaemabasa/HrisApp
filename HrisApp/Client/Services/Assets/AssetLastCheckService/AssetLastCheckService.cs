namespace HrisApp.Client.Services.Assets.AssetLastCheckService
{
#nullable disable

    public class AssetLastCheckService : IAssetLastCheckService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssetLastCheckService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetLastCheckT> AssetLastCheckTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetLastCheckT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetLastCheckT>>("api/AssetLastDateCheck");
        }

        public async Task<AssetLastCheckT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetLastCheckT>($"api/AssetLastDateCheck/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetLastCheckT>>("api/AssetLastDateCheck/GetObj");
            if (result != null)
                AssetLastCheckTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetLastCheckT model)
        {
            await _httpClient.PostAsJsonAsync("api/AssetLastDateCheck/CreateObj", model);
        }

        public async Task UpdateObj(AssetLastCheckT model)
        {
            await _httpClient.PutAsJsonAsync("api/AssetLastDateCheck/UpdateObj", model);
        }
    }
}