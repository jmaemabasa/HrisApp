namespace HrisApp.Client.Services.Assets.Remarks.AccRemarksService
{
#nullable disable
    public class AccRemarksService : IAccRemarksService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AccRemarksService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public async Task<List<AccessoryRemarksT>> GetObjList(string code)
        {
            var result = await _httpClient.GetFromJsonAsync<List<AccessoryRemarksT>>($"api/AccessRemarks/GetObjList?code={code}");
            return result;
        }

        public async Task<int> GetExistObj(string verifycode)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/AccessRemarks/GetExistObj?verifycode={verifycode}");
            return result;
        }

        public async Task UpdateObj(AccessoryRemarksT obj)
        {
            await _httpClient.PutAsJsonAsync($"api/AccessRemarks/UpdateObj/{obj.VerifyId}", obj);
        }

        public async Task<string> CreateObj(AccessoryRemarksT obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AccessRemarks/CreateObj", obj);
            var response = await result.Content.ReadFromJsonAsync<AccessoryRemarksT>();
            return response?.Remark;
        }

        public async Task DeleteAllObj(string verId)
        {
            await _httpClient.DeleteAsync($"api/AccessRemarks/DeleteAllObj/{verId}");
        }
    }
}
