namespace HrisApp.Client.Services.Assets.Licenses.AssLicenseHistoryService
{
#nullable disable
    public class AssLicenseHistoryService : IAssLicenseHistoryService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssLicenseHistoryService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetLicenseHistoryT> AssetLicenseHistoryTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetLicenseHistoryT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetLicenseHistoryT>>("api/AssLicenseHistory");
        }

        public async Task<AssetLicenseHistoryT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetLicenseHistoryT>($"api/AssLicenseHistory/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task<AssetLicenseHistoryT> GetObjByAccIDMainId(int accid, int mainid)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetLicenseHistoryT>($"api/AssLicenseHistory/GetObjByAccIDMainId?accid={accid}&mainid={mainid}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetLicenseHistoryT>>("api/AssLicenseHistory/GetObj");
            if (result != null)
                AssetLicenseHistoryTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetLicenseHistoryT model)
        {
            await _httpClient.PostAsJsonAsync("api/AssLicenseHistory/CreateObj", model);
        }

        public async Task UpdateObj(AssetLicenseHistoryT model)
        {
            await _httpClient.PutAsJsonAsync("api/AssLicenseHistory/UpdateObj", model);
        }

        public async Task UpdateDateUnassigned(AssetLicenseHistoryT obj)
        {
            await _httpClient.PutAsJsonAsync($"api/AssLicenseHistory/UpdateDateUnassigned", obj);
        }

        public async Task<string> GetTestConsole(int obj)
        {
            var _respost = await _httpClient.GetFromJsonAsync<string>($"api/AssLicenseHistory/GetTestConsole?obj={obj}");
            Console.WriteLine("service " + _respost);
            return _respost;
        }
    }
}
