namespace HrisApp.Client.Services.MasterData.VendorService
{
#nullable disable
    public class VendorService : IVendorService
    {
        MainsService _mainService = new();
        private readonly HttpClient _httpClient;
        public VendorService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<VendorT> VendorTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<VendorT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<VendorT>>("api/Vendor");
        }

        public async Task<VendorT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<VendorT>($"api/Vendor/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<VendorT>>("api/Vendor/GetObj");
            if (result != null)
                VendorTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(VendorT model)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Vendor/CreateObj", model);
        }

        public async Task UpdateObj(VendorT model)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Vendor/UpdateObj", model);
        }

        public async Task<int> IsExistCode(string code)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/Vendor/IsExistCode?code={code}");
            return result;
        }

        public async Task<string> DeleteObj(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Vendor/DeleteObj?id={id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            else
            {
                return "Error: " + response.StatusCode.ToString();
            }
        }
    }
}
