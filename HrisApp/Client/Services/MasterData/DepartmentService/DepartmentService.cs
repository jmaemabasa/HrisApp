using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace HrisApp.Client.Services.MasterData.DepartmentService
{
#nullable disable
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public DepartmentService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<DepartmentT> DepartmentTs { get; set; }


        //GEEEEET
        public async Task GetDepartment()
        {
            var result = await _http.GetFromJsonAsync<List<DepartmentT>>("api/Department/GetDepartment");
            if (result != null)
            {
                DepartmentTs = result;
                // Console.WriteLine to check if the data is fetched
                //foreach (var area in DepartmentTs)
                //{
                //    Console.WriteLine($"dept Id: {area.Id}, Name: {area.Name}");
                //}
            }
        }

        public async Task<List<DepartmentT>> GetDepartmentList()
        {
            return await _http.GetFromJsonAsync<List<DepartmentT>>("api/Department");
        }

        public async Task<List<DepartmentT>> GetDeptByDivision(int divisionId)
        {
            return await _http.GetFromJsonAsync<List<DepartmentT>>($"api/Department/DeptByDivision/{divisionId}");
        }


        //CREATE UPDATEEEEEEE
        public async Task CreateDepartment(string deptName, int listDropdownId)
        {
            DepartmentT department = new DepartmentT
            {
                Name = deptName,
                DivisionId = listDropdownId
            };

            HttpResponseMessage response = await _http.PostAsJsonAsync("api/Department/CreateDepartment", department);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
        }

        public async Task UpdateDepartment(DepartmentT dept)
        {
            try
            {
                var result = await _http.PutAsJsonAsync($"api/Department/UpdateDepartment", dept);
                result.EnsureSuccessStatusCode();
                var index = DepartmentTs.FindIndex(a => a.Id == dept.Id);
                if (index >= 0)
                {
                    DepartmentTs[index] = dept;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
