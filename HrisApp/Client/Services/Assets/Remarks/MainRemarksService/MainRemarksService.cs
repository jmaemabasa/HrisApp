using System.Net.Http;

namespace HrisApp.Client.Services.Assets.Remarks.MainRemarksService
{
#nullable disable
    public class MainRemarksService : IMainRemarksService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public MainRemarksService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public async Task<List<MainRemarksT>> GetObjList(string code)
        {
            var result = await _httpClient.GetFromJsonAsync<List<MainRemarksT>>($"api/MainRemarks/GetObjList?code={code}");
            return result;
        }

        public async Task<int> GetExistObj(string verifycode)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/MainRemarks/GetExistObj?verifycode={verifycode}");
            return result;
        }

        public async Task UpdateObj(MainRemarksT obj)
        {
            await _httpClient.PutAsJsonAsync($"api/MainRemarks/UpdateObj/{obj.VerifyId}", obj);
        }

        public async Task<string> CreateObj(MainRemarksT obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/MainRemarks/CreateObj", obj);
            var response = await result.Content.ReadFromJsonAsync<MainRemarksT>();
            return response?.Remark;
        }

        public async Task DeleteAllObj(string verId)
        {
            var result = await _httpClient.DeleteAsync($"api/MainRemarks/DeleteAllObj/{verId}");
        }
    }
}
