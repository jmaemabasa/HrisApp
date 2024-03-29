﻿namespace HrisApp.Client.Services.MasterData.DepartmentService
{
#nullable disable
    public class DepartmentService : IDepartmentService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public DepartmentService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<DepartmentT> DepartmentTs { get; set; }


        //GEEEEET
        public async Task GetDepartment()
        {
            var result = await _httpClient.GetFromJsonAsync<List<DepartmentT>>("api/Department/GetDepartment");
            if (result != null)
            {
                DepartmentTs = result;
            }
        }

        public async Task<List<DepartmentT>> GetDepartmentList()
        {
            return await _httpClient.GetFromJsonAsync<List<DepartmentT>>("api/Department");
        }

        public async Task<List<DepartmentT>> GetDeptByDivision(int divisionId)
        {
            return await _httpClient.GetFromJsonAsync<List<DepartmentT>>($"api/Department/DeptByDivision/{divisionId}");
        }

        public async Task<DepartmentT> GetSingleDepartment(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<DepartmentT>($"api/Department/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        //CREATE UPDATEEEEEEE
        public async Task CreateDepartment(string deptName, int listDropdownId)
        {
            DepartmentT department = new()
            {
                Name = deptName,
                DivisionId = listDropdownId
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Department/CreateDepartment", department);
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
                var result = await _httpClient.PutAsJsonAsync($"api/Department/UpdateDepartment", dept);
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
