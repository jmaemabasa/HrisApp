namespace HrisApp.Client.Services.Assets.Consumables.ConsTransactionService
{
#nullable disable
    public class ConsTransactionService : IConsTransactionService
    {
        private MainsService _mainService = new();
        private readonly HttpClient _httpClient;

        public ConsTransactionService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<Cons_TransactionT> Cons_TransactionTs { get; set; }

        // GEEEEEEEEEEEET
        public async Task<List<Cons_TransactionT>> GetObjList()
        {
            return await _httpClient.GetFromJsonAsync<List<Cons_TransactionT>>("api/ConsTransaction");
        }

        public async Task<Cons_TransactionT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Cons_TransactionT>($"api/ConsTransaction/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task<Cons_TransactionT> GetSingleObjByCode(string code)
        {
            var result = await _httpClient.GetFromJsonAsync<Cons_TransactionT>($"api/ConsTransaction/GetSingleObjByCode?code={code}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetObj()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Cons_TransactionT>>("api/ConsTransaction/GetObj");
            if (result != null)
                Cons_TransactionTs = result;
        }

        //CREATE AND UPDATE
        public async Task CreateObj(Cons_TransactionT model)
        {
            await _httpClient.PostAsJsonAsync("api/ConsTransaction/CreateObj", model);
        }

        public async Task UpdateObj(Cons_TransactionT model)
        {
            await _httpClient.PutAsJsonAsync("api/ConsTransaction/UpdateObj", model);
        }

        public async Task<int> GetLastCode()
        {
            var result = await _httpClient.GetFromJsonAsync<int>($"api/ConsTransaction/GetLastCode");
            return result;
        }

        public async Task<List<EmployeeT>> GetTopIssuedEmployees(int consID)
        {
            var result = await _httpClient.GetFromJsonAsync<List<EmployeeT>>($"api/ConsTransaction/TopIssuedEmployees?consID={consID}");
            return result;
        }

    }
}
