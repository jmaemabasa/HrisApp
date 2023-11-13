namespace HrisApp.Client.Services.EmpDetails.EmploymentDateService
{
    public class EmploymentDateService : IEmploymentDateService
    {
        private readonly HttpClient _http;
        public EmploymentDateService(HttpClient http)
        {
            _http = http;
        }

        public List<Emp_EmploymentDateT> EmploymentDateT { get; set; } = new List<Emp_EmploymentDateT>();

        public async Task<string> CreateEmploymentDate(Emp_EmploymentDateT obj)
        {
            Console.WriteLine("Saving EmploymentDate");
            var result = await _http.PostAsJsonAsync("api/EmploymentDate", obj);
            await SetEmploymentDate(result);
            return obj.Verify_Id;//new
        }

        public async Task GetEmploymentDate()
        {
            var result = await _http.GetFromJsonAsync<List<Emp_EmploymentDateT>>("api/EmploymentDate");
            if (result != null)
                EmploymentDateT = result;
        }

        public async Task<Emp_EmploymentDateT> GetSingleEmploymentDate(int id)
        {
            var result = await _http.GetFromJsonAsync<Emp_EmploymentDateT>($"api/EmploymentDate/{id}");
            if (result != null)
                return result;
            throw new Exception("date not found!");
        }

        public async Task UpdateEmploymentDate(Emp_EmploymentDateT obj)
        {
            var result = await _http.PutAsJsonAsync($"api/EmploymentDate/{obj.Id}", obj);
            await SetEmploymentDate(result);
        }

        private async Task SetEmploymentDate(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Emp_EmploymentDateT>>();
            EmploymentDateT = response;

        }
    }
}
