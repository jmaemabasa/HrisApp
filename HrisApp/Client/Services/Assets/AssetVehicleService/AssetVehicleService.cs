namespace HrisApp.Client.Services.Assets.AssetVehicleService
{
#nullable disable

    public class AssetVehicleService : IAssetVehicleService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public AssetVehicleService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AssetVehiclesT> AssetVehiclesTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<AssetVehiclesT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<AssetVehiclesT>>("api/AssetVehicle");
        }

        public async Task<AssetVehiclesT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AssetVehiclesT>($"api/AssetVehicle/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssetVehiclesT>>("api/AssetVehicle/GetObj");
            if (result != null)
                AssetVehiclesTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(AssetVehiclesT model)
        {
            await _httpClient.PostAsJsonAsync("api/AssetVehicle/CreateObj", model);
        }

        public async Task UpdateObj(AssetVehiclesT model)
        {
            await _httpClient.PutAsJsonAsync("api/AssetVehicle/UpdateObj", model);
        }

        public async Task<int> GetLastCode(int type, int cat, int subcat)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/AssetVehicle/GetLastCode?type={type}&cat={cat}&subcat={subcat}");
            return result;
        }

        public async Task<HttpResponseMessage> QRPrint(string AssetCode)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/AssetPrint/QRPrintMain?AssetCode={AssetCode}");
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"HttpResponse : {ex.Message}");
                return null;
            }
        }

        public async Task<string> QRGenerate(string AssetCode)
        {
            try
            {
                var result = await QRPrint(AssetCode);
                var url = result.RequestMessage.RequestUri.ToString();
                return url;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"String Response : {ex.Message}");
                return null;
            }
        }
    }
}