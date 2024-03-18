namespace HrisApp.Client.Services.EmpDetails.AddressService
{
#nullable disable

    public class AddressService : IAddressService
    {
        private MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;

        public AddressService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<Emp_AddressT> AddressT { get; set; } = new List<Emp_AddressT>();

        public async Task GetAddress()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_AddressT>>("api/Address");
            if (result != null)
                AddressT = result;
        }

        public async Task<Emp_AddressT> GetSingleAddress(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_AddressT>($"api/Address/{id}");
            if (result != null)
                return result;
            throw new Exception("address not found!");
        }

        public async Task<string> CreateAddress(Emp_AddressT address)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Address", address);
            await SetAddress(result);
            return address.Verify_Id;//new
        }

        public async Task UpdateAddress(Emp_AddressT address)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Address/{address.Id}", address);
            await SetAddress(result);
        }

        public async Task DeleteAddress(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Address/{id}");
            //await SetAddress(result);
        }

        private async Task SetAddress(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Emp_AddressT>>();
            AddressT = response;
        }
    }
}