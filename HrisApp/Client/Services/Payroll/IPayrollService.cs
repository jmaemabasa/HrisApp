namespace HrisApp.Client.Services.Payroll
{
    public interface IPayrollService
    {
        List<Emp_PayrollT> PayrollTs { get; set; }
        List<ScheduleTypeT> ScheduleTypeTs { get; set; }
      

        Task GetPayroll();
        Task<List<Emp_PayrollT>> GetPayrollList();
        Task<string> CreatePayroll(Emp_PayrollT payroll);
        Task<Emp_PayrollT> GetSinglePayroll(int id);
        Task UpdatePayroll(Emp_PayrollT payroll);
        Task DeletePayroll(int id);

        //FK

        Task GetScheduleType();
        
    }
}
