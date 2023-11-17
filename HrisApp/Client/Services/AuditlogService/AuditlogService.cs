using HrisApp.Client.Pages.MasterData;
using System.Net;
using System.Threading;

namespace HrisApp.Client.Services.AuditlogService
{
#nullable disable
    public class AuditlogService : IAuditlogService
    {
        private readonly HttpClient _http;

        public AuditlogService(HttpClient http)
        {
            _http = http;
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
            var result = await _http.PostAsJsonAsync("api/Auditlogs/CreateLogs", logs);
            //await SetLogs(result);
        }

        public async Task GetLogs()
        {
            var result = await _http.GetFromJsonAsync<List<AuditlogsT>>("/api/Auditlogs/GetLogs");
            if (result != null)
            {
                AuditlogsTs = result;
            }
        }

        public async Task<AuditlogsT> GetSingleLog(int id)
        {
            var result = await _http.GetFromJsonAsync<AuditlogsT>($"api/Auditlogs/{id}");
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
