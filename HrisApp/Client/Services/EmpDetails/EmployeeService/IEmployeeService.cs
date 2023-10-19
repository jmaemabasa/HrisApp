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

        //FK
        List<StatusT> StatusTs { get; set; }
        List<EmploymentStatusT> EmploymentStatusTs { get; set; }
        List<EmerRelationshipT> EmerRelationshipTs { get; set; }
        List<GenderT> GenderTs { get; set; }
        List<CivilStatusT> CivilStatusTs { get; set; }
        List<ReligionT> ReligionTs { get; set; }
        List<InactiveStatusT> InactiveStatusTs { get; set; }

        Task GetStatusList();
        Task GetEmploymentStatusList();
        Task GetEmerRelationshipList();
        Task GetGenderList();
        Task GetCivilStatusList();
        Task GetReligionList();
        Task GetInactiveStatusList();

    }
}
