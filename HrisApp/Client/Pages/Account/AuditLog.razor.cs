namespace HrisApp.Client.Pages.Account
{
    public partial class AuditLog : ComponentBase
    {
        public List<EmployeeT> employeeList = new();
        public List<UserMasterT> userList = new();
        public List<AuditlogsT> logsList = new();

        public string infoFormat = "{first_item}-{last_item} of {all_items}";
        public string searchString1 = "";

        public DateRange _dateRange = new()
        {
            Start = DateTime.Now.AddDays(-15),
            End = DateTime.Now
        };

        protected override async Task OnInitializedAsync()
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

            if (logsList == null || logsList.Count == 0)
            {
                OpenOverlay();
            }
        }

        public void DateRangeChange(DateRange? dateRange)
        {
            _dateRange = dateRange!;

            logsList = AuditlogService.AuditlogsTs
                .Where(log => log.Date >= _dateRange.Start && log.Date <= _dateRange.End)
                .OrderByDescending(log => log.Date)
                .ToList();

            if (logsList == null || logsList.Count == 0)
            {
                OpenOverlay();
            }
        }

        public bool FilterFunc1(AuditlogsT log) => FilterFunc(log, searchString1);

        private bool FilterFunc(AuditlogsT log, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (log.Action.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if ((log.EmployeeUSer?.FirstName + " " + log.EmployeeUSer?.LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (String.Format("{0:dd MMM yyyy}", log.Date).Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public string GetRole(int employeeId)
        {
            // Logic to get the user name based on the employee ID
            var role = userList.FirstOrDefault(e => e.EmployeeId == employeeId);
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
            isVisible = false;
            await Task.Delay(2000);
            isVisible = true;
            StateHasChanged();
        }
    }
}