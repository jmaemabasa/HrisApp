using static System.Net.WebRequestMethods;

namespace HrisApp.Client.Services.APiS.MasterDataApiS
{
    public class MasterDataApiService : IMasterDataApiService
    {

        private MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;

        public MasterDataApiService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public async Task UpdateFSSStatus(int empid, int status)
        {
            await _httpClient.PutAsJsonAsync($"api/MasterDataApi/UpdateFSSStatus?empid={empid}&status={status}", empid);
        }
        public async Task UpdateSalesmanStatus(int empid, int status)
        {
            await _httpClient.PutAsJsonAsync($"api/MasterDataApi/UpdateSalesmanStatus?empid={empid}&status={status}", empid);
        }
        public async Task UpdateWmsUserStatus(int empid, int status)
        {
            await _httpClient.PutAsJsonAsync($"api/MasterDataApi/UpdateWMSUserStatus?empid={empid}&status={status}", empid);
        }
        public async Task<byte[]> GetImage()
        {
            var obj = await _httpClient.GetAsync($"api/MasterDataApi/getimage");
            var response = await obj.Content.ReadFromJsonAsync<byte[]>();
            return response!;
        }


    }
}
