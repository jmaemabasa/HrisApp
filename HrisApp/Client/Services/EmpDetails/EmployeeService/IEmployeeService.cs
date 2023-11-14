using HrisApp.Shared.Models.StaticData;

namespace HrisApp.Client.Services.EmpDetails.EmployeeService
{
    public interface IEmployeeService
    {
        List<EmployeeT> EmployeeTs { get; set; }
        Task<List<EmployeeT>> GetEmployeeList();
        Task GetEmployee();
        Task<EmployeeT> GetSingleEmployee(int id);
        Task<string> CreateEmployee(EmployeeT employee);
        Task UpdateEmployee(EmployeeT employee);
        Task DeleteEmployee(int id);

    }
}
