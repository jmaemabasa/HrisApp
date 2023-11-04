
namespace HrisApp.Client.Global
{
    public class DummyGlobal
    {
        //public List<AuditLogsDummy> AuditLogs_List = new List<AuditLogsDummy>();
        //public DummyGlobal() {
        //AuditLogs_List = new List<AuditLogsDummy>();
        //}



        private List<AuditLogsDummy> logs = new List<AuditLogsDummy> ();
        public List<AuditLogsDummy> AuditLogs_List
        {
            get => logs;
            set
            {
                logs = value;
            }
        }



        public async Task createAudit(AuditLogsDummy _obj)
        {
            await Task.Delay(1000);
            AuditLogs_List.Add(_obj);
        }

        public List<AuditLogsDummy> GetAuditLogsList()
        {
            return AuditLogs_List;
        }
    }
}
