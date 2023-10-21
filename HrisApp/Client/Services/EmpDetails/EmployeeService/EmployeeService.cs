using HrisApp.Client.Pages.Employee;
using HrisApp.Client.Pages.MasterData;

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
        //FK
        public List<StatusT> StatusTs { get; set; }
        public List<EmploymentStatusT> EmploymentStatusTs { get; set; }
        public List<EmerRelationshipT> EmerRelationshipTs { get; set; }
        public List<GenderT> GenderTs { get; set; }
        public List<CivilStatusT> CivilStatusTs { get; set; }
        public List<ReligionT> ReligionTs { get; set; }
        public List<InactiveStatusT> InactiveStatusTs { get; set; }

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

        //FK

        public async Task GetStatusList()
        {
            var result = await _http.GetFromJsonAsync<List<StatusT>>("api/Employee/GetStatusList");
            if (result != null)
            {
                StatusTs = result;
            }
        }
        public async Task GetEmploymentStatusList()
        {
            var result = await _http.GetFromJsonAsync<List<EmploymentStatusT>>("api/Employee/GetEmploymentStatusList");
            if (result != null)
            {
                EmploymentStatusTs = result;
            }
        }
        public async Task GetEmerRelationshipList()
        {
            var result = await _http.GetFromJsonAsync<List<EmerRelationshipT>>("api/Employee/GetEmerRelationshipList");
            if (result != null)
            {
                EmerRelationshipTs = result;
            }
        }
        public async Task GetGenderList()
        {
            var result = await _http.GetFromJsonAsync<List<GenderT>>("api/Employee/GetGenderList");
            if (result != null)
            {
                GenderTs = result;
            }
        }
        public async Task GetCivilStatusList()
        {
            var result = await _http.GetFromJsonAsync<List<CivilStatusT>>("api/Employee/GetCivilStatusList");
            if (result != null)
            {
                CivilStatusTs = result;
            }
        }
        public async Task GetReligionList()
        {
            var result = await _http.GetFromJsonAsync<List<ReligionT>>("api/Employee/GetReligionList");
            if (result != null)
            {
                ReligionTs = result;
            }
        }
        public async Task GetInactiveStatusList()
        {
            var result = await _http.GetFromJsonAsync<List<InactiveStatusT>>("api/Employee/GetInactiveStatusList");
            if (result != null)
            {
                InactiveStatusTs = result;
            }
        }
    }
}
