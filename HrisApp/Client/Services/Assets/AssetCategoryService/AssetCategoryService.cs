namespace HrisApp.Client.Services.Assets.AssetCategoryService
{
#nullable disable
    public class AssetCategoryService : IAssetCategoryService
    {
        MainsService _mainService = new();
        private readonly HttpClient _httpClient;
        public AssetCategoryService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetCategoryT> AssetCategoryTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetCategoryT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetCategoryT>>("api/AssetCategory");
        }

        public async Task<AssetCategoryT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetCategoryT>($"api/AssetCategory/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetCategoryT>>("api/AssetCategory/GetObj");
            if (result != null)
                AssetCategoryTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetCategoryT model)
        {
            await _httpClient.PostAsJsonAsync("api/AssetCategory/CreateObj", model);
        }

        public async Task UpdateObj(AssetCategoryT model)
        {
            await _httpClient.PutAsJsonAsync("api/AssetCategory/UpdateObj", model);
        }

        public async Task<int> GetLastCode()
        {
            var result = await _httpClient.GetFromJsonAsync<int>("api/AssetCategory/GetLastCode");
            return result;
        }
    }
}
