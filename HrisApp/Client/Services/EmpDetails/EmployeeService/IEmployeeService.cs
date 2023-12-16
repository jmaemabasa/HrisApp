namespace HrisApp.Client.Services.EmpDetails.EmployeeService
{
    public interface IEmployeeService
    {
        List<EmployeeT> EmployeeTs { get; set; }
        Task<List<EmployeeT>> GetEmployeeList();
        Task<string> Getname(int id);
        Task GetEmployee();
        Task<EmployeeT> GetSingleEmployee(int id);
        Task<EmployeeT> GetSingleEmployeeByVerId(string verId);
        Task<string> CreateEmployee(EmployeeT employee);
        Task UpdateEmployee(EmployeeT employee);
        Task DeleteEmployee(int id);


        Task<int> GetCountEmployee();

        Task<HttpResponseMessage> EmpDetailsPrint(string verid);
        Task<string> EmpDetailsGenerate(string verid);
    }
}
