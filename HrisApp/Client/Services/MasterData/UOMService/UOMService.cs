namespace HrisApp.Client.Services.MasterData.UOMService
{
#nullable disable
    public class UOMService : IUOMService
    {
        MainsService _mainService = new();
        private readonly HttpClient _httpClient;
        public UOMService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<UOMT> UOMTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<UOMT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<UOMT>>("api/UOM");
        }

        public async Task<UOMT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<UOMT>($"api/UOM/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UOMT>>("api/UOM/GetObj");
            if (result != null)
                UOMTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(UOMT model)
        {
            var result = await _httpClient.PostAsJsonAsync("api/UOM/CreateObj", model);
        }

        public async Task UpdateObj(UOMT model)
        {
            var result = await _httpClient.PutAsJsonAsync("api/UOM/UpdateObj", model);
        }

        public async Task<int> IsExistCode(string code)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/UOM/IsExistCode?code={code}");
            return result;
        }

        public async Task<string> DeleteObj(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/UOM/DeleteObj?id={id}");

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
