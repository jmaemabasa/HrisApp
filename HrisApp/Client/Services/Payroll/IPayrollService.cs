namespace HrisApp.Client.Services.Payroll
{
    public interface IPayrollService
    {
        List<Emp_PayrollT> PayrollTs { get; set; }
        List<RateTypeT> RateTypeTs { get; set; }
        List<CashBondT> CashBondTs { get; set; }
        List<ScheduleTypeT> ScheduleTypeTs { get; set; }
        List<RestDayT> RestDayTs { get; set; }

        Task GetPayroll();
        Task<List<Emp_PayrollT>> GetPayrollList();
        Task<string> CreatePayroll(Emp_PayrollT payroll);
        Task<Emp_PayrollT> GetSinglePayroll(int id);
        Task UpdatePayroll(Emp_PayrollT payroll);

        //FK
        Task GetRateType();

        Task GetCashbond();

        Task GetScheduleType();
        Task GetRestDay();
    }
}
