using HrisApp.Shared.Models.Assets.Licenses;

namespace HrisApp.Client.Services.Assets.Licenses.AssLicenseService
{
#nullable disable
    public class AssLicenseService : IAssLicenseService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssLicenseService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetLicenseT> AssetLicenseTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetLicenseT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetLicenseT>>("api/AssetLicense");
        }

        public async Task<AssetLicenseT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetLicenseT>($"api/AssetLicense/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task<AssetLicenseT> GetSingleObjByCode(string code)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetLicenseT>($"api/AssetLicense/GetSingleObjByCode?code={code}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetLicenseT>>("api/AssetLicense/GetObj");
            if (result != null)
                AssetLicenseTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetLicenseT model)
        {
            await _httpClient.PostAsJsonAsync("api/AssetLicense/CreateObj", model);
        }

        public async Task UpdateObj(AssetLicenseT model)
        {
            await _httpClient.PutAsJsonAsync("api/AssetLicense/UpdateObj", model);
        }

        public async Task<int> GetLastCode(int cat, int subcat)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/AssetLicense/GetLastCode?cat={cat}&subcat={subcat}");
            return result;
        }

        public async Task<HttpResponseMessage> QRPrint(string AssetCode)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/AssetPrint/QRPrintLicense?AssetCode={AssetCode}");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HttpResponse : {ex.Message}");
                return null;
            }
        }

        public async Task<string> QRGenerate(string AssetCode)
        {
            try
            {
                var result = await QRPrint(AssetCode);
                var url = result.RequestMessage.RequestUri.ToString();
                return url;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"String Response : {ex.Message}");
                return null;
            }
        }
    }
}
