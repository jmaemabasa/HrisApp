namespace HrisApp.Client.Services.ApplicantDetails.AppAddressService
{
    public class AppAddressService : IAppAddressService
    {
        private MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;

        public AppAddressService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<App_AddressT> AddressT { get; set; } = new List<App_AddressT>();

        public async Task GetAddress()
        {
            var result = await _httpClient.GetFromJsonAsync<List<App_AddressT>>("api/AppAddress");
            if (result != null)
                AddressT = result;
        }

        public async Task<App_AddressT> GetSingleAddress(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<App_AddressT>($"api/AppAddress/{id}");
            if (result != null)
                return result;
            throw new Exception("address not found!");
        }

        public async Task<string> CreateAddress(App_AddressT address)
        {
            var result = await _httpClient.PostAsJsonAsync("api/AppAddress", address);
            await SetAddress(result);
            return address.Verify_Id;//new
        }

        public async Task UpdateAddress(App_AddressT address)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/AppAddress/{address.Id}", address);
            await SetAddress(result);
        }

        public async Task DeleteAddress(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/AppAddress/{id}");
            //await SetAddress(result);
        }

        private async Task SetAddress(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<App_AddressT>>();
            AddressT = response;
        }
    }
}