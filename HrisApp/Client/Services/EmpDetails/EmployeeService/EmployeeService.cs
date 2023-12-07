using System.Net.Http;

namespace HrisApp.Client.Services.EmpDetails.EmployeeService
{
#nullable disable
    public class EmployeeService : IEmployeeService
    {
        public HttpClient _httpClient;
        MainsService _mainService = new MainsService();
        public EmployeeService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<EmployeeT> EmployeeTs { get; set; } = new List<EmployeeT>();


        public async Task<List<EmployeeT>> GetEmployeeList()
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeT>>("api/Employee");
        }

        public async Task GetEmployee()
        {
            var result = await _httpClient.GetFromJsonAsync<List<EmployeeT>>("api/Employee/GetEmployee");
            if (result != null)
            {
                EmployeeTs = result;
            }
        }

        public async Task<EmployeeT> GetSingleEmployee(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmployeeT>($"api/Employee/{id}");
            if (result != null)
                return result;
            throw new Exception("employee not found");

        }

        public async Task<EmployeeT> GetSingleEmployeeByVerId(string verId)
        {
            var result = await _httpClient.GetFromJsonAsync<EmployeeT>($"api/Employee/GetSingleEmployeeByVerId/{verId}");
            if (result != null)
                return result;
            throw new Exception("employee not found");

        }

        public async Task SetEmployees(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<EmployeeT>>();
            EmployeeTs = response;
        }

        public async Task<string> CreateEmployee(EmployeeT employee)
        {
            Console.WriteLine("Saving Services sa create employee");


            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Employee/CreateEmployee", employee);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
            return employee.Verify_Id;

        }
        public async Task UpdateEmployee(EmployeeT employee)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Employee/{employee.Id}", employee);
            await SetEmployees(result);
        }

        public async Task DeleteEmployee(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Employee/{id}");
            //await SetEmployees(result);
        }

        public async Task<string> Getname(int id)
        {
            var returnlist = await _httpClient.GetFromJsonAsync<List<EmployeeT>>($"api/Employee/GetEmpName/{id}");


            var returnmodel = returnlist.Where(e => e.Id == id).FirstOrDefault();

            return $"{CapitalizeFirstLetter(returnmodel.FirstName)} {CapitalizeFirstLetter(returnmodel.LastName)}";
        }

        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }

        public async Task<int> GetCountEmployee()
        {
            var response = await _httpClient.GetFromJsonAsync<int>("api/Employee/EmployeeCount");
            return response;
        }

    }
}
