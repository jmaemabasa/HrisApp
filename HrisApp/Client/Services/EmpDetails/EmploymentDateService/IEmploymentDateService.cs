namespace HrisApp.Client.Services.EmpDetails.EmploymentDateService
{
    public interface IEmploymentDateService
    {
        List<EmploymentDateT> EmploymentDateT { get; set; }

        Task<string> CreateEmploymentDate(EmploymentDateT obj);
        Task GetEmploymentDate();
        Task<EmploymentDateT> GetSingleEmploymentDate(int id);
        Task UpdateEmploymentDate(EmploymentDateT obj);
    }
}
