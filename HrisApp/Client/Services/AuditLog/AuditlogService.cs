using static System.Net.WebRequestMethods;

namespace HrisApp.Client.Services.AuditLog
{
    public class AuditlogService : IAuditlogService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public AuditlogService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public async Task CreateAudit(int userId, string action, string tablename, string comment, DateTime date)
        {
            AuditLogT audit = new AuditLogT
            {
                UserId = userId,
                Action = action,
                TableName = tablename,
                AdditionalInfo = comment,
                Date = date
            };

            var result = await _http.PostAsJsonAsync("api/AuditLog/CreateAudit", audit);
        }
    }
}
