namespace HrisApp.Client.Services.AuditlogService
{
    public interface IAuditlogService
    {
        List<AuditlogsT> AuditlogsTs { get; set; }

        Task<AuditlogsT> GetSingleLog(int id);

        Task CreateLog(int userid, string action, string type, DateTime date);
        Task GetLogs();
    }
}
