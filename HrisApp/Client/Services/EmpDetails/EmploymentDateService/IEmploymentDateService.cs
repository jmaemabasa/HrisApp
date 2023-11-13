namespace HrisApp.Client.Services.EmpDetails.EmploymentDateService
{
    public interface IEmploymentDateService
    {
        List<Emp_EmploymentDateT> EmploymentDateT { get; set; }

        Task<string> CreateEmploymentDate(Emp_EmploymentDateT obj);
        Task GetEmploymentDate();
        Task<Emp_EmploymentDateT> GetSingleEmploymentDate(int id);
        Task UpdateEmploymentDate(Emp_EmploymentDateT obj);
    }
}
