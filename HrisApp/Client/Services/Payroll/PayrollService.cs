using static System.Net.WebRequestMethods;

namespace HrisApp.Client.Services.Payroll
{
    public class PayrollService : IPayrollService
    {
        private readonly HttpClient _http;

        public PayrollService(HttpClient http)
        {
            _http = http;
        }
        public List<PayrollT> PayrollTs { get; set; } = new List<PayrollT>();
        public List<RateTypeT> RateTypeTs { get; set; } = new List<RateTypeT>();
        public List<CashBondT> CashBondTs { get; set; } = new List<CashBondT>();
        public List<ScheduleTypeT> ScheduleTypeTs { get; set; } = new List<ScheduleTypeT>();
        public List<RestDayT> RestDayTs { get; set; } = new List<RestDayT>();

        public async Task GetPayroll()
        {
            var result = await _http.GetFromJsonAsync<List<PayrollT>>("api/PayrollT");
            if (result != null)
                PayrollTs = result;
        }
        public async Task<List<PayrollT>> GetPayrollList()
        {
            return await _http.GetFromJsonAsync<List<PayrollT>>("api/Payroll/GetOPayrollList");
        }

        private async Task SetPayroll(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<PayrollT>>();
            PayrollTs = response;
        }

        public async Task<string> CreatePayroll(PayrollT payroll)
        {
            Console.WriteLine("Saving docu");
            var result = await _http.PostAsJsonAsync("api/Payroll", payroll);
            await SetPayroll(result);
            return payroll.Verify_Id;//new
        }
        public async Task<PayrollT> GetSinglePayroll(int id)
        {
            var result = await _http.GetFromJsonAsync<PayrollT>($"api/Payroll/{id}");
            if (result != null)
                return result;
            throw new Exception("document not found");
        }
        public async Task UpdatePayroll(PayrollT payroll)
        {
            try
            {
                var result = await _http.PutAsJsonAsync($"api/Payroll/{payroll.Id}", payroll);
                await SetPayroll(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ("nasave sya sa services,"));
            }
        }

        //FK
        public async Task GetRateType()
        {
            var result = await _http.GetFromJsonAsync<List<RateTypeT>>("api/Payroll/ratetype");
            if (result != null)
                RateTypeTs = result;
        }

        public async Task GetCashbond()
        {
            var result = await _http.GetFromJsonAsync<List<CashBondT>>("api/Payroll/cashbond");
            if (result != null)
                CashBondTs = result;
        }

        public async Task GetScheduleType()
        {
            var result = await _http.GetFromJsonAsync<List<ScheduleTypeT>>("api/Payroll/scheduletype");
            if (result != null)
                ScheduleTypeTs = result;
        }

        public async Task GetRestDay()
        {
            var result = await _http.GetFromJsonAsync<List<RestDayT>>("api/Payroll/restday");
            if (result != null)
                RestDayTs = result;
        }
    }
}
