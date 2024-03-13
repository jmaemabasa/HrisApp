namespace HrisApp.Client.Services.Assets.AssetAccessHistoryService
{
#nullable disable

    public class AssetAccessHistoryService : IAssetAccessHistoryService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssetAccessHistoryService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetAccessHistoryT> AssetAccessHistoryTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetAccessHistoryT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetAccessHistoryT>>("api/AssetAccessHistory");
        }

        public async Task<AssetAccessHistoryT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetAccessHistoryT>($"api/AssetAccessHistory/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task<AssetAccessHistoryT> GetObjByAccIDMainId(int accid, int mainid)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetAccessHistoryT>($"api/AssetAccessHistory/GetObjByAccIDMainId?accid={accid}&mainid={mainid}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetAccessHistoryT>>("api/AssetAccessHistory/GetObj");
            if (result != null)
                AssetAccessHistoryTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetAccessHistoryT model)
        {
            await _httpClient.PostAsJsonAsync("api/AssetAccessHistory/CreateObj", model);
        }

        public async Task UpdateObj(AssetAccessHistoryT model)
        {
            await _httpClient.PutAsJsonAsync("api/AssetAccessHistory/UpdateObj", model);
        }

        public async Task UpdateDateUnassigned(AssetAccessHistoryT obj)
        {
            await _httpClient.PutAsJsonAsync($"api/AssetAccessHistory/UpdateDateUnassigned", obj);
        }

        public async Task<string> GetTestConsole(int obj)
        {
            var _respost = await _httpClient.GetFromJsonAsync<string>($"api/AssetAccessHistory/GetTestConsole?obj={obj}");
            Console.WriteLine("service " + _respost);
            return _respost;
        }
    }
}