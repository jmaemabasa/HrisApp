using static System.Net.WebRequestMethods;

namespace HrisApp.Client.Services.Payroll
{
#nullable disable
    public class PayrollService : IPayrollService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public PayrollService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<Emp_PayrollT> PayrollTs { get; set; } = new List<Emp_PayrollT>();
        public List<ScheduleTypeT> ScheduleTypeTs { get; set; } = new List<ScheduleTypeT>();

       
        public async Task GetPayroll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_PayrollT>>("api/PayrollT");
            if (result != null)
                PayrollTs = result;
        }
        public async Task<List<Emp_PayrollT>> GetPayrollList()
        {
            return await _httpClient.GetFromJsonAsync<List<Emp_PayrollT>>("api/Payroll/GetOPayrollList");
        }

        private async Task SetPayroll(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Emp_PayrollT>>();
            PayrollTs = response;
        }

        public async Task<string> CreatePayroll(Emp_PayrollT payroll)
        {
            Console.WriteLine("Saving docu");
            var result = await _httpClient.PostAsJsonAsync("api/Payroll", payroll);
            await SetPayroll(result);
            return payroll.Verify_Id;//new
        }
        public async Task<Emp_PayrollT> GetSinglePayroll(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_PayrollT>($"api/Payroll/{id}");
            if (result != null)
                return result;
            throw new Exception("document not found");
        }
        public async Task UpdatePayroll(Emp_PayrollT payroll)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync($"api/Payroll/{payroll.Id}", payroll);
                await SetPayroll(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ("nasave sya sa services,"));
            }
        }

        public async Task DeletePayroll(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Payroll/{id}");
            //await SetPayroll(result);
        }

        //FK
        public async Task GetScheduleType()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ScheduleTypeT>>("api/Payroll/scheduletype");
            if (result != null)
                ScheduleTypeTs = result;
        }
    }
}
