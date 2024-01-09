using HrisApp.Shared.Models.Employee;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace HrisApp.Client.Services.EmpDetails.LeaveHistoryService
{
#nullable disable
    public class LeaveHistoryService : ILeaveHistoryService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public LeaveHistoryService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<Emp_LeaveHistoryT> Emp_LeaveHistoryTs { get; set; }
        public async Task<List<Emp_LeaveHistoryT>> GetLeaveHistoryList()
        {
            return await _httpClient.GetFromJsonAsync<List<Emp_LeaveHistoryT>>("api/LeaveHistory");
        }
        public async Task GetLeaveHistory()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_LeaveHistoryT>>("api/LeaveHistory/GetLeaveHistory");
            if (result != null)
                Emp_LeaveHistoryTs = result;
        }
        public async Task<Emp_LeaveHistoryT> GetSingleLeaveHistory(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_LeaveHistoryT>($"api/LeaveHistory/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }
        public async Task<Emp_LeaveHistoryT> GetSingleLeaveHistoryByVerId(string verid)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_LeaveHistoryT>($"api/LeaveHistory/GetSingleLeaveHistoryByVerId/{verid}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }
        public async Task CreateLeaveHistory(string verid, string leavetype, DateTime? from, DateTime? to, string noofdays, string purpose, string status, DateTime? inserted, string readstatus)
        {
            Emp_LeaveHistoryT obj = new()
            {
                Verify_Id = verid,
                LeaveType = leavetype,
                From = from,
                To = to,
                NoOfDays = noofdays,
                Purpose = purpose,
                Status = status,
                InsertedTime = inserted,
                ReadStatus = readstatus
            };
            var result = await _httpClient.PostAsJsonAsync("api/LeaveHistory/CreateLeaveHistory", obj);
        }
        public async Task UpdateLeaveHistory(Emp_LeaveHistoryT obj)
        {
            var result = await _httpClient.PutAsJsonAsync("api/LeaveHistory/UpdateLeaveHistory", obj);
        }


        public async Task<List<Emp_LeaveHistoryT>> Getpendingcount()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_LeaveHistoryT>>($"api/LeaveHistory/Getpendinglist");
            return result;
        }

        public async Task UpdateAllReadStatus(string status, string newstatus)
        {
            try
            {
                Emp_LeaveHistoryT objT = new()
                {
                    ReadStatus = newstatus,
                };

                var result = await _httpClient.PutAsJsonAsync($"api/LeaveHistory/UpdateAllReadStatus/{status}/{newstatus}", objT);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "daot ang services");
            }
        }
    }
}
