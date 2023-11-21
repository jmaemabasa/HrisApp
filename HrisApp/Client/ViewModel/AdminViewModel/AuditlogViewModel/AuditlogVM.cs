namespace HrisApp.Client.ViewModel.AdminViewModel.AuditlogViewModel
{
    public class AuditlogVM : BaseViewModel
    {
        IAuditlogService AuditlogService = new AuditlogService();
        IEmployeeService EmployeeService = new EmployeeService();
        IAuthService AuthService = new AuthService();

        public List<EmployeeT> employeeList = new List<EmployeeT>();
        public List<UserMasterT> userList = new List<UserMasterT>();
        public List<AuditlogsT> logsList = new List<AuditlogsT>();

        public string infoFormat = "{first_item}-{last_item} of {all_items}";
        public string searchString1 = "";
        public DateRange _dateRange = new DateRange
        {
            Start = DateTime.Now.AddDays(-15),
            End = DateTime.Now
        };
       
        public async Task OnRefreshPage()
        {
            await Task.Delay(500);
            await AuditlogService.GetLogs();
            logsList = AuditlogService.AuditlogsTs
                .Where(log => log.Date >= _dateRange.Start && log.Date <= _dateRange.End)
                .OrderByDescending(log => log.Date)
                .ToList();

            await EmployeeService.GetEmployee();
            employeeList = EmployeeService.EmployeeTs;  

            await AuthService.GetUsers();
            userList = AuthService.UserMasterTs;
        }

        public void DateRangeChange(DateRange? dateRange)
        {
            _dateRange = dateRange;

            logsList = AuditlogService.AuditlogsTs
                .Where(log => log.Date >= _dateRange.Start && log.Date <= _dateRange.End)
                .OrderByDescending(log => log.Date)
                .ToList();
        }

        public bool FilterFunc1(AuditlogsT log) => FilterFunc(log, searchString1);

        private bool FilterFunc(AuditlogsT log, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (log.Action.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (String.Format("{0:dd MMM yyyy}", log.Date).Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public string GetRole(string employeeId)
        {
            // Logic to get the user name based on the employee ID
            var role = userList.FirstOrDefault(e => e.Id == Convert.ToInt32(employeeId));
            return role != null ? $"{role.Role}" : "";
        }

        public string ActionColor(string action)
        {
            return action.ToLower() switch
            {
                "create" => "actionCreate",
                "update" => "actionUpdate",
                "delete" => "actionDelete",
                "logged in" => "actionLogged",
                _ => "actionDefault",
            };
        }

        public bool isVisible;
        public async void OpenOverlay()
        {
            isVisible = true;
            await Task.Delay(3000);
            isVisible = false;
        }
    }
}
