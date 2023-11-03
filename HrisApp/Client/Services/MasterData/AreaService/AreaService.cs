namespace HrisApp.Client.Services.MasterData.AreaService
{
#nullable disable
    public class AreaService : IAreaService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public AreaService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<AreaT> AreaTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task GetAreaList()
        {
            var result = await _http.GetFromJsonAsync<List<AreaT>>("api/Area");
            if (result != null)
                AreaTs = result;
        }

        public async Task<AreaT> GetSingleArea(int areaId)
        {
            var result = await _http.GetFromJsonAsync<AreaT>($"api/Area/{areaId}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetArea()
        {
            var result = await _http.GetFromJsonAsync<List<AreaT>>("api/Area/GetArea");
            if (result != null)
                AreaTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateArea(string areaName)
        {
            AreaT areaT = new AreaT
            {
                Name = areaName
            };
            var result = await _http.PostAsJsonAsync("api/Area/CreateArea", areaT);

        }

        public async Task UpdateArea(AreaT area)
        {
            var result = await _http.PutAsJsonAsync("api/Area/UpdateArea", area);
        }
    }
}
