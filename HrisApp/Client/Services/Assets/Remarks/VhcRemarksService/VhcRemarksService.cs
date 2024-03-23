namespace HrisApp.Client.Services.Assets.Remarks.VhcRemarksService
{
#nullable disable
    public class VhcRemarksService : IVhcRemarksService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public VhcRemarksService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public async Task<List<VehicleRemarksT>> GetObjList(string code)
        {
            var result = await _httpClient.GetFromJsonAsync<List<VehicleRemarksT>>($"api/VehicleRemarks/GetObjList?code={code}");
            return result;
        }

        public async Task<int> GetExistObj(string verifycode)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/VehicleRemarks/GetExistObj?verifycode={verifycode}");
            return result;
        }

        public async Task UpdateObj(VehicleRemarksT obj)
        {
            await _httpClient.PutAsJsonAsync($"api/VehicleRemarks/UpdateObj/{obj.VerifyId}", obj);
        }

        public async Task<string> CreateObj(VehicleRemarksT obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/VehicleRemarks/CreateObj", obj);
            var response = await result.Content.ReadFromJsonAsync<VehicleRemarksT>();
            return response?.Remark;
        }

        public async Task DeleteAllObj(string verId)
        {
            var result = await _httpClient.DeleteAsync($"api/VehicleRemarks/DeleteAllObj/{verId}");
        }
    }
}
