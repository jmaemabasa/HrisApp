namespace HrisApp.Client.Services.EmpDetails.AddressService
{
#nullable disable
    public class AddressService : IAddressService
    {
        private readonly HttpClient _http;

        public AddressService(HttpClient http)
        {
            _http = http;
        }
        public List<AddressT> AddressT { get; set; } = new List<AddressT>();

        public async Task GetAddress()
        {
            var result = await _http.GetFromJsonAsync<List<AddressT>>("api/Address");
            if (result != null)
                AddressT = result;
        }
        public async Task<AddressT> GetSingleAddress(int id)
        {

            var result = await _http.GetFromJsonAsync<AddressT>($"api/Address/{id}");
            if (result != null)
                return result;
            throw new Exception("address not found!");
        }

        public async Task<string> CreateAddress(AddressT address)
        {
            Console.WriteLine("Saving address");
            var result = await _http.PostAsJsonAsync("api/Address", address);
            await SetAddress(result);
            return address.Verify_Id;//new
        }

        public async Task UpdateAddress(AddressT address)
        {
            var result = await _http.PutAsJsonAsync($"api/Address/{address.Id}", address);
            await SetAddress(result);
        }

        private async Task SetAddress(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<AddressT>>();
            AddressT = response;

        }

    }
}
