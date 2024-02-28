namespace HrisApp.Client.Services.Assets.MainAssetAccService
{
#nullable disable

    public class MainAssetAccService : IMainAssetAccService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public MainAssetAccService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<MainAssetAccessoriesT> MainAssetAccessoriesTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<MainAssetAccessoriesT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<MainAssetAccessoriesT>>("api/MainAssetAcc");
        }

        public async Task<MainAssetAccessoriesT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<MainAssetAccessoriesT>($"api/MainAssetAcc/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<MainAssetAccessoriesT>>("api/MainAssetAcc/GetObj");
            if (result != null)
                MainAssetAccessoriesTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(MainAssetAccessoriesT model)
        {
            await _httpClient.PostAsJsonAsync("api/MainAssetAcc/CreateObj", model);
        }

        public async Task UpdateObj(MainAssetAccessoriesT model)
        {
            await _httpClient.PutAsJsonAsync("api/MainAssetAcc/UpdateObj", model);
        }
    }
}