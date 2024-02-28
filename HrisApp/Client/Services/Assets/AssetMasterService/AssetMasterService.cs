namespace HrisApp.Client.Services.Assets.AssetMasterService
{
#nullable disable

    public class AssetMasterService : IAssetMasterService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssetMasterService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetMasterT> AssetMasterTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetMasterT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetMasterT>>("api/AssetMaster");
        }

        public async Task<AssetMasterT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetMasterT>($"api/AssetMaster/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetMasterT>>("api/AssetMaster/GetObj");
            if (result != null)
                AssetMasterTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetMasterT model)
        {
            await _httpClient.PostAsJsonAsync("api/AssetMaster/CreateObj", model);
        }

        public async Task UpdateObj(AssetMasterT model)
        {
            await _httpClient.PutAsJsonAsync("api/AssetMaster/UpdateObj", model);
        }

        public async Task<int> GetLastCode(int type, int cat, int subcat)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/AssetMaster/GetLastCode?type={type}&cat={cat}&subcat={subcat}");
            return result;
        }
    }
}