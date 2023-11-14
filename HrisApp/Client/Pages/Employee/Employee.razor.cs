using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Employee
{
    public partial class Employee: ComponentBase
    {
#nullable disable
        private List<StatusT> StatusL = new();

        protected override async Task OnInitializedAsync()
        {
            await EmployeeService.GetEmployee();
            _employeeList = EmployeeService.EmployeeTs;
            await StaticService.GetStatusList();
            StatusL = StaticService.StatusTs;
            #region for DASHBOARD
            var uri = new Uri(NavigationManager.Uri);
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
        void CreateNewEmployee() => NavigationManager.NavigateTo("/employee/add");
        void ShowEmployee(int id) => NavigationManager.NavigateTo($"/employee/edit/{id}");

        async Task DeleteEmployee(int id)
        {
            await EmployeeService.DeleteEmployee(id);
        }

        private async Task SearchStatus(int status)
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

        private static string StatusChipColor(string status)
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
        private bool _isVisible;
        public async void OpenOverlay()
        {
            _isVisible = true;
            await Task.Delay(5000);
            _isVisible = false;
            StateHasChanged();
        }

        private static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }
        #endregion

        #region TABLE VARIABLES
        private readonly string _infoFormat = "{first_item}-{last_item} of {all_items}";
        private string _searchString1 = "";
        List<EmployeeT> _employeeList = new();
        private EmployeeT _selectedItem1 = null;

        private bool FilterFunc1(EmployeeT emp) => FilterFunc(emp, _searchString1);

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
