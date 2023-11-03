namespace HrisApp.Client.Services.AuditLog
{
    public interface IAuditlogService
    {
        Task CreateAudit(int userId, string action, string tablename, string comment, DateTime date);

    }
}
