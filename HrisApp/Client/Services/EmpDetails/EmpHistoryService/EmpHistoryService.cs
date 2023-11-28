namespace HrisApp.Client.Services.EmpDetails.EmpHistoryService
{
#nullable disable
    public class EmpHistoryService : IEmpHistoryService
    {
        public HttpClient _httpClient;
        MainsService _mainService = new MainsService();
        public EmpHistoryService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<Emp_PosHistoryT> Emp_PosHistoryTs { get; set; } = new List<Emp_PosHistoryT>();
        public async Task<List<Emp_PosHistoryT>> GetEmpHistoryList(string verCode)
        {
            return await _httpClient.GetFromJsonAsync<List<Emp_PosHistoryT>>($"api/EmpHistory/GetEmpHistorylist?verCode={verCode}");
        }

        public async Task<Emp_PosHistoryT> GetEmpLastHistory(string verCode)
        {
            return await _httpClient.GetFromJsonAsync<Emp_PosHistoryT>($"api/EmpHistory/GetEmpLastHistory?verCode={verCode}");
        }

        public async Task GetEmpHistory()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_PosHistoryT>>("api/EmpHistory/GetEmpHistory");
            if (result != null)
            {
                Emp_PosHistoryTs = result;
            }
        }

        public async Task<Emp_PosHistoryT> GetSingleEmpHistory(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_PosHistoryT>($"api/EmpHistory/{id}");
            if (result != null)
                return result;
            throw new Exception("history not found");
        }

        public async Task<Emp_PosHistoryT> GetSingleLastEmpHistory(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_PosHistoryT>($"api/EmpHistory/GetSingleLastEmpHistory/{id}");
            if (result != null)
                return result;
            throw new Exception("history not found");
        }

        public async Task<string> CreateEmpHistory(Emp_PosHistoryT history)
        {
            Console.WriteLine("Saving Services sa create employee history");


            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/EmpHistory/CreateEmpHistory", history);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
            return history.Verify_Id;
        }

        public async Task UpdateEmpHistory(Emp_PosHistoryT history)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/EmpHistory/{history.Id}", history);
            await SetEmpHistory(result);
        }

        public async Task SetEmpHistory(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Emp_PosHistoryT>>();
            Emp_PosHistoryTs = response;
        }
    }
}
