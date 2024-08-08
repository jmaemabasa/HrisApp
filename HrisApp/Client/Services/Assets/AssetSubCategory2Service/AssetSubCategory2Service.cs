namespace HrisApp.Client.Services.Assets.AssetSubCategory2Service
{
#nullable disable
    public class AssetSubCategory2Service : IAssetSubCategory2Service
    {
        MainsService _mainService = new();
        private readonly HttpClient _httpClient;
        public AssetSubCategory2Service()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetSubCategory2T> AssetSubCategoryTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetSubCategory2T>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetSubCategory2T>>("api/AssetSubCategory2");
        }

        public async Task<AssetSubCategory2T> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetSubCategory2T>($"api/AssetSubCategory2/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetSubCategory2T>>("api/AssetSubCategory2/GetObj");
            if (result != null)
                AssetSubCategoryTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetSubCategory2T model)
        {
            await _httpClient.PostAsJsonAsync("api/AssetSubCategory2/CreateObj", model);
        }

        public async Task UpdateObj(AssetSubCategory2T model)
        {
            await _httpClient.PutAsJsonAsync("api/AssetSubCategory2/UpdateObj", model);
        }

        public async Task<int> GetLastCode()
        {
            var result = await _httpClient.GetFromJsonAsync<int>("api/AssetSubCategory2/GetLastCode");
            return result;
        }
    }
}
