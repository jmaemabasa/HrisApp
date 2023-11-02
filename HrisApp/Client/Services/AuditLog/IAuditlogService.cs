namespace HrisApp.Client.Services.AuditLog
{
    public interface IAuditlogService
    {
        Task CreateAudit(int userId, string tablename, string action);

    }
}
