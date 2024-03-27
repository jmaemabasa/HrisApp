namespace HrisApp.Client.Services.Assets.Consumables.ConsumablesService
{
#nullable disable
    public class ConsumablesService : IConsumablesService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public ConsumablesService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<ConsumablesT> ConsumablesTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<ConsumablesT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<ConsumablesT>>("api/Consumables");
        }

        public async Task<ConsumablesT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ConsumablesT>($"api/Consumables/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task<ConsumablesT> GetSingleObjByCode(string code)
        {
            var result = await _httpClient.GetFromJsonAsync<ConsumablesT>($"api/Consumables/GetSingleObjByCode?code={code}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ConsumablesT>>("api/Consumables/GetObj");
            if (result != null)
                ConsumablesTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(ConsumablesT model)
        {
            await _httpClient.PostAsJsonAsync("api/Consumables/CreateObj", model);
        }

        public async Task UpdateObj(ConsumablesT model)
        {
            await _httpClient.PutAsJsonAsync("api/Consumables/UpdateObj", model);
        }

        public async Task<int> GetLastCode(int type, int cat, int subcat)
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/Consumables/GetLastCode?type={type}&cat={cat}&subcat={subcat}");
            return result;
        }

    }
}
