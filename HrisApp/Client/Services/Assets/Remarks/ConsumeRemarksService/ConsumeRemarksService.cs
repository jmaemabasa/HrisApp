namespace HrisApp.Client.Services.Assets.Remarks.ConsumeRemarksService
{
#nullable disable
    public class ConsumeRemarksService : IConsumeRemarksService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public ConsumeRemarksService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public async Task<List<ConsumableRemarksT>> GetObjList(string code)
        {
            var result = await _httpClient.GetFromJsonAsync<List<ConsumableRemarksT>>($"api/ConsumeRemarks/GetObjList?code={code}");
            return result;
        }

        public async Task<int> GetExistObj(string verifycode)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/ConsumeRemarks/GetExistObj?verifycode={verifycode}");
            return result;
        }

        public async Task UpdateObj(ConsumableRemarksT obj)
        {
            await _httpClient.PutAsJsonAsync($"api/ConsumeRemarks/UpdateObj/{obj.VerifyId}", obj);
        }

        public async Task<string> CreateObj(ConsumableRemarksT obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/ConsumeRemarks/CreateObj", obj);
            var response = await result.Content.ReadFromJsonAsync<ConsumableRemarksT>();
            return response?.Remark;
        }

        public async Task DeleteAllObj(string verId)
        {
            var result = await _httpClient.DeleteAsync($"api/ConsumeRemarks/DeleteAllObj/{verId}");
        }
    }
}
