namespace HrisApp.Client.Services.Assets.AssetTypeService
{
#nullable disable
    public class AssetTypeService : IAssetTypeService
    {
        MainsService _mainService = new();
        private readonly HttpClient _httpClient;
        public AssetTypeService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetTypesT> AssetTypesTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetTypesT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetTypesT>>("api/AssetType");
        }

        public async Task<AssetTypesT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetTypesT>($"api/AssetType/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetTypesT>>("api/AssetType/GetObj");
            if (result != null)
                AssetTypesTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetTypesT model)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AssetType/CreateObj", model);
        }

        public async Task UpdateObj(AssetTypesT model)
        {
            var result = await _httpClient.PutAsJsonAsync("api/AssetType/UpdateObj", model);
        }

        public async Task<int> GetLastCode()
        {
            var result = await _httpClient.GetFromJsonAsync<int>("api/AssetType/GetLastCode");
            return result;
        }

    }
}
