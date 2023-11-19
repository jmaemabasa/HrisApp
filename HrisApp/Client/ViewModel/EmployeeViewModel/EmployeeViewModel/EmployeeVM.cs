namespace HrisApp.Client.ViewModel.EmployeeViewModel.EmployeeViewModel
{
    public class EmployeeVM : BaseViewModel
    {
        IEmployeeService EmployeeService = new EmployeeService();
        IStaticService StaticService = new StaticService();

        private readonly NavigationManager _navigationManager;
        public EmployeeVM(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public readonly string _infoFormat = "{first_item}-{last_item} of {all_items}";
        public string _searchString1 = "";
        public List<EmployeeT> _employeeList = new();
        public EmployeeT _selectedItem1 = null;
        public List<StatusT> StatusL = new();

        public async Task OnRefreshPage()
        {
            await Task.Delay(1000);
            await EmployeeService.GetEmployee();
            _employeeList = EmployeeService.EmployeeTs;
            await StaticService.GetStatusList();
            StatusL = StaticService.StatusTs;

            #region for DASHBOARD
            var uri = new Uri(_navigationManager.Uri);
            var statusFilterString = uri.Query.Split('=').LastOrDefault();
            if (statusFilterString?.ToLower() == "inactive")
            {
                _employeeList = EmployeeService.EmployeeTs.Where(e => e.StatusId != 1).ToList();
            }
            else if (statusFilterString?.ToLower() == "active")
            {
                _employeeList = EmployeeService.EmployeeTs.Where(e => e.StatusId == 1).ToList();
            }
            #endregion
        }

        #region FUNCTIONS / METHODS
        public void CreateNewEmployee() => _navigationManager.NavigateTo("/employee/add");
        public void ShowEmployee(int id) => _navigationManager.NavigateTo($"/employee/edit/{id}");

        public async Task DeleteEmployee(int id)
        {
            await EmployeeService.DeleteEmployee(id);
        }

        public async Task SearchStatus(int status)
        {
            await Task.Delay(10);
            if (status == 0)
            {
                await EmployeeService.GetEmployee();
                _employeeList = EmployeeService.EmployeeTs;
            }
            else
            {
                await EmployeeService.GetEmployee();
                _employeeList = EmployeeService.EmployeeTs.Where(e => e.StatusId == status).ToList();
            }

        }

        public string StatusChipColor(string status)
        {
            return status switch
            {
                "Active" => "statusActiveChip",
                "Awol" => "statusAwolChip",
                "Inactive" => "statusInactiveChip",
                "Resigned" => "statusResignedChip",
                "Terminated" => "statusTerminatedChip",
                "Retired" => "statusRetiredChip",
                _ => "statusRetiredChip",
            };
        }

        //LOADING
        public bool _isVisible;
        public async void OpenOverlay()
        {
            _isVisible = true;
            await Task.Delay(5000);
            _isVisible = false;
            //StateHasChanged();
        }

        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }
        #endregion

        #region TABLE VARIABLES
        public bool FilterFunc1(EmployeeT emp) => FilterFunc(emp, _searchString1);

        private static bool FilterFunc(EmployeeT emp, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if ((emp.FirstName + " " + emp.LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.MiddleName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.Division.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.Department.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.Position.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.DateHired.ToString("MM/dd/yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }
        #endregion
    }
}
