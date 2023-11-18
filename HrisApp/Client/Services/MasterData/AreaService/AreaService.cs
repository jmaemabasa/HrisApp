namespace HrisApp.Client.Services.MasterData.AreaService
{
#nullable disable
    public class AreaService : IAreaService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public AreaService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AreaT> AreaTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task GetAreaList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AreaT>>("api/Area");
            if (result != null)
                AreaTs = result;
        }

        public async Task<AreaT> GetSingleArea(int areaId)
        {
            var result = await _httpClient.GetFromJsonAsync<AreaT>($"api/Area/{areaId}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetArea()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AreaT>>("api/Area/GetArea");
            if (result != null)
                AreaTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateArea(string areaName)
        {
            AreaT areaT = new()
            {
                Name = areaName
            };
            var result = await _httpClient.PostAsJsonAsync("api/Area/CreateArea", areaT);

        }

        public async Task UpdateArea(AreaT area)
        {
            var result = await _httpClient.PutAsJsonAsync("api/Area/UpdateArea", area);
        }
    }
}
