namespace HrisApp.Client.Services.Assets.MainAssetLicenseService
{
#nullable disable
    public class MainAssetLicenseService : IMainAssetLicenseService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public MainAssetLicenseService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<MainAssetLicensesT> MainAssetLicensesTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<MainAssetLicensesT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<MainAssetLicensesT>>("api/MainAssetLicense");
        }

        public async Task<MainAssetLicensesT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<MainAssetLicensesT>($"api/MainAssetLicense/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<MainAssetLicensesT>>("api/MainAssetLicense/GetObj");
            if (result != null)
                MainAssetLicensesTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(MainAssetLicensesT model)
        {
            await _httpClient.PostAsJsonAsync("api/MainAssetLicense/CreateObj", model);
        }

        public async Task UpdateObj(MainAssetLicensesT model)
        {
            await _httpClient.PutAsJsonAsync("api/MainAssetLicense/UpdateObj", model);
        }

        public async Task DeleteAccessory(int mainid, int accid)
        {
            await _httpClient.DeleteAsync($"api/MainAssetLicense/DeleteAccessory?mainid={mainid}&accid={accid}");
        }
    }
}
