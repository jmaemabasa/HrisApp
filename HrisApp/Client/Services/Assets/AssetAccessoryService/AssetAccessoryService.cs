namespace HrisApp.Client.Services.Assets.AssetAccessoryService
{
#nullable disable

    public class AssetAccessoryService : IAssetAccessoryService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssetAccessoryService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetAccessoryT> AssetAccessoryTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetAccessoryT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetAccessoryT>>("api/AssetAccess");
        }

        public async Task<AssetAccessoryT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetAccessoryT>($"api/AssetAccess/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetAccessoryT>>("api/AssetAccess/GetObj");
            if (result != null)
                AssetAccessoryTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetAccessoryT model)
        {
            await _httpClient.PostAsJsonAsync("api/AssetAccess/CreateObj", model);
        }

        public async Task UpdateObj(AssetAccessoryT model)
        {
            await _httpClient.PutAsJsonAsync("api/AssetAccess/UpdateObj", model);
        }

        public async Task<int> GetLastCode(int cat, int subcat)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/AssetAccess/GetLastCode?cat={cat}&subcat={subcat}");
            return result;
        }
    }
}