namespace HrisApp.Client.Pages.Employee
{
    public partial class Employee: ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> authState { get; set; }
        string? userRole;

        private List<EmployeeT> EmployeesL = new List<EmployeeT>();
        private EmployeeT employeeee = new EmployeeT();

        private List<string> PDFDataList = new List<string>();


        protected override async Task OnInitializedAsync()
        {
            var auth = await authState;
            userRole = auth.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            await EmployeeService.GetEmployee();
            employeeList = EmployeeService.EmployeeTs;
        }



        #region FUNCTIONS / METHODS
        void CreateNewEmployee() => NavigationManager.NavigateTo("/employee/add");
        void ShowEmployee(int id) => NavigationManager.NavigateTo($"/employee/edit/{id}");


        private string StatusChipColor(string status)
        {
            switch (status)
            {
                case "Active":
                    return "statusActiveChip";
                case "Awol":
                    return "statusAwolChip";
                case "Inactive":
                    return "statusInactiveChip";
                case "Resigned":
                    return "statusResignedChip";
                case "Terminated":
                    return "statusTerminatedChip";
                case "Retired":
                    return "statusRetiredChip";
                default:
                    return "statusRetiredChip";

            }

        }

        //LOADING
        private bool isVisible;
        public async void OpenOverlay()
        {
            isVisible = true;
            await Task.Delay(3000);
            isVisible = false;
            StateHasChanged();
        }

        private string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }
        #endregion

        #region TABLE VARIABLES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<EmployeeT> employeeList = new List<EmployeeT>();
        private EmployeeT selectedItem1 = null;
        private HashSet<EmployeeT> selectedItems = new HashSet<EmployeeT>();

        private bool FilterFunc1(EmployeeT emp) => FilterFunc(emp, searchString1);

        private bool FilterFunc(EmployeeT emp, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
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
            if (emp.Section.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
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
