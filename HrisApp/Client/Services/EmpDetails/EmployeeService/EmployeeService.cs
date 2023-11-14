using HrisApp.Client.Pages.Employee;
using HrisApp.Client.Pages.MasterData;
using HrisApp.Shared.Models.StaticData;

namespace HrisApp.Client.Services.EmpDetails.EmployeeService
{
#nullable disable
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public EmployeeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<EmployeeT> EmployeeTs { get; set; } = new List<EmployeeT>();
        

        public async Task<List<EmployeeT>> GetEmployeeList()
        {
            return await _http.GetFromJsonAsync<List<EmployeeT>>("api/Employee");
        }

        public async Task GetEmployee()
        {
            var result = await _http.GetFromJsonAsync<List<EmployeeT>>("api/Employee/GetEmployee");
            if (result != null)
            {
                EmployeeTs = result;
            }
        }

        public async Task<EmployeeT> GetSingleEmployee(int id)
        {
            var result = await _http.GetFromJsonAsync<EmployeeT>($"api/Employee/{id}");
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

           
            HttpResponseMessage response = await _http.PostAsJsonAsync("api/Employee/CreateEmployee", employee);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
            return employee.Verify_Id;

        }
        public async Task UpdateEmployee(EmployeeT employee)
        {
            var result = await _http.PutAsJsonAsync($"api/Employee/{employee.Id}", employee);
            await SetEmployees(result);
        }

        public async Task DeleteEmployee(int id)
        {
            var result = await _http.DeleteAsync($"api/Employee/{id}");
            await SetEmployees(result);
        }
    }
}
