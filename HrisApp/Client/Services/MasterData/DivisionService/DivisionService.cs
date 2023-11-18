namespace HrisApp.Client.Services.MasterData.DivisionService
{
#nullable disable
    public class DivisionService : IDivisionService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public DivisionService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<DivisionT> DivisionTs { get; set; }

        public async Task GetDivisionList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<DivisionT>>("api/Division");
            if (result != null)
                DivisionTs = result;
        }

        public async Task GetDivision()
        {
            var result = await _httpClient.GetFromJsonAsync<List<DivisionT>>("/api/Division/GetDivision");
            if (result != null)
            {
                DivisionTs = result;

                // Console.WriteLine to check if the data is fetched
                //foreach (var area in DivisionTs)
                //{
                //    Console.WriteLine($"Area Id: {area.Id}, Name: {area.Name}");
                //}
            }
        }

        public async Task<DivisionT> GetSingleDivision(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<DivisionT>($"api/Division/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task CreateDivision(string divisionName)
        {
            DivisionT div = new()
            {
                Name = divisionName
            };

            var result = await _httpClient.PostAsJsonAsync("api/Division/CreateDivision", div);
        }

        public async Task UpdateDivision(DivisionT division)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/division/UpdateDivision", division);
        }
    }
}
