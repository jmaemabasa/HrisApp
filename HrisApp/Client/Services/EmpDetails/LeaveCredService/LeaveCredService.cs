namespace HrisApp.Client.Services.EmpDetails.LeaveCredService
{
#nullable disable
    public class LeaveCredService : ILeaveCredService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public LeaveCredService()
        {
            _httpClient = _mainService.Get_Http();
        }


        public List<Emp_LeaveCreditT> Emp_LeaveCreditTs { get; set; }
        public async Task<List<Emp_LeaveCreditT>> GetLeaveCredList()
        {
            return await _httpClient.GetFromJsonAsync<List<Emp_LeaveCreditT>>("api/LeaveCredit");
        }
        public async Task GetLeaveCred()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_LeaveCreditT>>("api/LeaveCredit/GetLeaveCredit");
            if (result != null)
                Emp_LeaveCreditTs = result;
        }
        public async Task<Emp_LeaveCreditT> GetSingleLeaveCred(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_LeaveCreditT>($"api/LeaveCredit/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task<Emp_LeaveCreditT> GetSingleLeaveCredByVerId(string verid)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_LeaveCreditT>($"api/LeaveCredit/GetSingleLeaveCreditByVerId/{verid}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task CreateLeaveCred(string verid, int el, int ml, int pl, int sl, int vl, int ol)
        {
            Emp_LeaveCreditT obj = new()
            {
                Verify_Id = verid,
                EL = el,
                ML = ml,
                PL = pl,
                SL = sl,
                VL = vl,
                OL = ol
            };
            var result = await _httpClient.PostAsJsonAsync("api/LeaveCredit/CreateLeaveCredit", obj);
        }
        public async Task UpdateLeaveCred(Emp_LeaveCreditT obj)
        {
            var result = await _httpClient.PutAsJsonAsync("api/LeaveCredit/UpdateLeaveCredit", obj);
        }
        public async Task<double> GetCountExistCredits(string verid, string type)
        {
            var result = await _httpClient.GetFromJsonAsync<double>($"api/LeaveCredit/GetCountExistCredits/{verid}/{type}");
            return result;
        }

    }
}
