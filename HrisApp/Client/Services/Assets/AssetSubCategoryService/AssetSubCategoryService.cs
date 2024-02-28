namespace HrisApp.Client.Services.Assets.AssetSubCategoryService
{
#nullable disable
    public class AssetSubCategoryService : IAssetSubCategoryService
    {
        MainsService _mainService = new();
        private readonly HttpClient _httpClient;
        public AssetSubCategoryService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetSubCategoryT> AssetSubCategoryTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetSubCategoryT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetSubCategoryT>>("api/AssetSubCategory");
        }

        public async Task<AssetSubCategoryT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetSubCategoryT>($"api/AssetSubCategory/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetSubCategoryT>>("api/AssetSubCategory/GetObj");
            if (result != null)
                AssetSubCategoryTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetSubCategoryT model)
        {
            await _httpClient.PostAsJsonAsync("api/AssetSubCategory/CreateObj", model);
        }

        public async Task UpdateObj(AssetSubCategoryT model)
        {
            await _httpClient.PutAsJsonAsync("api/AssetSubCategory/UpdateObj", model);
        }

        public async Task<int> GetLastCode()
        {
            var result = await _httpClient.GetFromJsonAsync<int>("api/AssetSubCategory/GetLastCode");
            return result;
        }
    }
}
