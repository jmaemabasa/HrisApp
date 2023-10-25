
namespace HrisApp.Client.Services.Payroll
{
    public interface IPayrollService
    {
        List<PayrollT> PayrollTs { get; set; }
        List<RateTypeT> RateTypeTs { get; set; }
        List<CashBondT> CashBondTs { get; set; }
        List<ScheduleTypeT> ScheduleTypeTs { get; set; }

        Task GetPayroll();
        Task<List<PayrollT>> GetPayrollList();
        Task<string> CreatePayroll(PayrollT payroll);
        Task<PayrollT> GetSinglePayroll(int id);
        Task UpdatePayroll(PayrollT payroll);

        //FK
        Task GetRateType();

        Task GetCashbond();

        Task GetScheduleType();
    }
}
