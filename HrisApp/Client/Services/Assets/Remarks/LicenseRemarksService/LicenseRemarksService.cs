using HrisApp.Shared.Models.Assets.Licenses;

namespace HrisApp.Client.Services.Assets.Remarks.LicenseRemarksService
{
#nullable disable
    public class LicenseRemarksService : ILicenseRemarksService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public LicenseRemarksService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public async Task<List<AssetLicenseRemarksT>> GetObjList(string code)
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetLicenseRemarksT>>($"api/AssLicenseRemarks/GetObjList?code={code}");
            return result;
        }

        public async Task<int> GetExistObj(string verifycode)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/AssLicenseRemarks/GetExistObj?verifycode={verifycode}");
            return result;
        }

        public async Task UpdateObj(AssetLicenseRemarksT obj)
        {
            await _httpClient.PutAsJsonAsync($"api/AssLicenseRemarks/UpdateObj/{obj.VerifyId}", obj);
        }

        public async Task<string> CreateObj(AssetLicenseRemarksT obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AssLicenseRemarks/CreateObj", obj);
            var response = await result.Content.ReadFromJsonAsync<AssetLicenseRemarksT>();
            return response?.Remark;
        }

        public async Task DeleteAllObj(string verId)
        {
            await _httpClient.DeleteAsync($"api/AssLicenseRemarks/DeleteAllObj/{verId}");
        }
    }
}
