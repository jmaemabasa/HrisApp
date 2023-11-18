namespace HrisApp.Client.Services.AuditlogService
{
#nullable disable
    public class AuditlogService : IAuditlogService
    {
        public HttpClient _httpClient;
        MainsService _mainService = new MainsService();
        public AuditlogService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AuditlogsT> AuditlogsTs { get; set; }

        public async Task CreateLog(int userid, string action, string type, DateTime date)
        {
            AuditlogsT logs = new AuditlogsT
            {
                UserId = userid,
                Action = action,
                Type = type,
                Date = date
            };
            var result = await _httpClient.PostAsJsonAsync("api/Auditlogs/CreateLogs", logs);
            //await SetLogs(result);
        }

        public async Task GetLogs()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AuditlogsT>>("/api/Auditlogs/GetLogs");
            if (result != null)
            {
                AuditlogsTs = result;
            }
        }

        public async Task<AuditlogsT> GetSingleLog(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AuditlogsT>($"api/Auditlogs/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("logs not found");
        }

        private async Task SetLogs(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<AuditlogsT>>();
            AuditlogsTs = response;

        }
    }
}
