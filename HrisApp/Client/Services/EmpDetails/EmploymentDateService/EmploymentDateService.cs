namespace HrisApp.Client.Services.EmpDetails.EmploymentDateService
{
    public class EmploymentDateService : IEmploymentDateService
    {
        private MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;

        public EmploymentDateService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<Emp_EmploymentDateT> EmploymentDateT { get; set; } = new List<Emp_EmploymentDateT>();

        public async Task<string> CreateEmploymentDate(Emp_EmploymentDateT obj)
        {
            var result = await _httpClient.PostAsJsonAsync("api/EmploymentDate", obj);
            await SetEmploymentDate(result);
            return obj.Verify_Id;//new
        }

        public async Task GetEmploymentDate()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_EmploymentDateT>>("api/EmploymentDate");
            if (result != null)
                EmploymentDateT = result;
        }

        public async Task<Emp_EmploymentDateT> GetSingleEmploymentDate(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_EmploymentDateT>($"api/EmploymentDate/{id}");
            if (result != null)
                return result;
            throw new Exception("date not found!");
        }

        public async Task UpdateEmploymentDate(Emp_EmploymentDateT obj)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/EmploymentDate/{obj.Id}", obj);
            await SetEmploymentDate(result);
        }

        private async Task SetEmploymentDate(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Emp_EmploymentDateT>>();
            EmploymentDateT = response;
        }
    }
}