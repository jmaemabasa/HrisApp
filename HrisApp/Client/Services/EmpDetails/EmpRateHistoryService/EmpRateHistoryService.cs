namespace HrisApp.Client.Services.EmpDetails.EmpRateHistoryService
{
#nullable disable
    public class EmpRateHistoryService : IEmpRateHistoryService
    {
        public HttpClient _httpClient;
        private MainsService _mainService = new();

        public EmpRateHistoryService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<Emp_RateHistoryT> Emp_RateHistoryTs { get; set; } = new List<Emp_RateHistoryT>();

        public async Task<List<Emp_RateHistoryT>> GetHistoryList(int empid)
        {
            return await _httpClient.GetFromJsonAsync<List<Emp_RateHistoryT>>($"api/EmpRateHistory/GetHistoryList?empid={empid}");
        }

        public async Task<Emp_RateHistoryT> GetLastHistory(int empid)
        {
            return await _httpClient.GetFromJsonAsync<Emp_RateHistoryT>($"api/EmpRateHistory/GetLastHistory?empid={empid}");
        }

        public async Task<Emp_RateHistoryT> GetLastHistoryWithoutDateEnded(int empid)
        {
            return await _httpClient.GetFromJsonAsync<Emp_RateHistoryT>($"api/EmpRateHistory/GetLastHistoryWithoutDateEnded?empid={empid}");
        }

        public async Task GetAllHistory()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_RateHistoryT>>("api/EmpRateHistory/GetAllHistory");
            if (result != null)
            {
                Emp_RateHistoryTs = result;
            }
        }

        public async Task<Emp_RateHistoryT> GetSingleHistory(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_RateHistoryT>($"api/EmpRateHistory/{id}");
            if (result != null)
                return result;
            throw new Exception("history not found");
        }

        public async Task<Emp_RateHistoryT> GetSingleLastHistory(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_RateHistoryT>($"api/EmpRateHistory/GetSingleLastHistory/{id}");
            if (result != null)
                return result;
            throw new Exception("history not found");
        }

        public async Task<string> CreateHistory(Emp_RateHistoryT history)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/EmpRateHistory/CreateHistory", history);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
            }
            return history.EmployeeId.ToString();
        }

        public async Task UpdateHistory(Emp_RateHistoryT history)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/EmpRateHistory/{history.Id}", history);
            await SetEmpHistory(result);
        }

        public async Task SetEmpHistory(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Emp_RateHistoryT>>();
            Emp_RateHistoryTs = response;
        }


        public async Task DeleteHistory(int id)
        {
            await _httpClient.DeleteAsync($"api/EmpRateHistory/DeleteHistory?id={id}");
        }
    }
}
