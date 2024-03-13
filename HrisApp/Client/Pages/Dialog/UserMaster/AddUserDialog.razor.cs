namespace HrisApp.Client.Pages.Dialog.UserMaster
{
    public partial class AddUserDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }

        private void Cancel() => MudDialog?.Cancel();

        private UserLoginDto reg = new();
        private bool _processing = false;
        private bool readonlyvar = true;
        private string? UsernameHolder { get; set; }

        // MudAlert properties
        private string message = string.Empty;

        private MudBlazor.Severity _severity;
        private bool showAlert = false;

        public void CloseMe() => showAlert = false;

        private string roleholder = string.Empty;

        private List<UserRoleT> UserRolesL = new();
        private List<DepartmentT> DepartmentsL = new();
        private List<DivisionT> DivisionsL = new();
        private List<EmployeeT> EmployeesL = new();

        private int divvar;
        private int deptvar;

        protected override async Task OnInitializedAsync()
        {
            await UserRoleService.GetUserRole();
            UserRolesL = UserRoleService.UserRoleTs;

            await DivisionService.GetDivision();
            DivisionsL = DivisionService.DivisionTs;

            await DepartmentService.GetDepartment();
            DepartmentsL = DepartmentService.DepartmentTs;

            await EmployeeService.GetEmployee();
            EmployeesL = EmployeeService.EmployeeTs;
        }

        private string GetFormattedUsername()
        {
            if (readonlyvar)
            {
                var employee = EmployeesL.FirstOrDefault(e => e.Id == reg.EmployeeId);

                if (employee != null)
                {
                    reg.Username = !string.IsNullOrEmpty(employee.FirstName) && !string.IsNullOrEmpty(employee.LastName)
                        ? $"{employee.FirstName[0].ToString().ToLower()}.{employee.LastName.ToLower()}"
                        : "";

                    return !string.IsNullOrEmpty(employee.FirstName) && !string.IsNullOrEmpty(employee.LastName)
                        ? $"{employee.FirstName[0].ToString().ToLower()}.{employee.LastName.ToLower()}"
                        : "";
                }
                else
                    return "";
            }
            else
                return "";
        }

        private async Task HandleRegistration()
        {
            if (divvar == 0)
            {
                showAlert = true;
                message = "Please select Division.";
                _severity = Severity.Error;
                _processing = false;
                readonlyvar = false;
            }
            else if (deptvar == 0)
            {
                showAlert = true;
                message = "Please select Department.";
                _severity = Severity.Error;
                _processing = false;
                readonlyvar = false;
            }
            else if (reg.EmployeeId == 0)
            {
                showAlert = true;
                message = "Please select an Employee.";
                _severity = Severity.Error;
                _processing = false;
                readonlyvar = false;
            }
            else if (string.IsNullOrWhiteSpace(reg.Role))
            {
                showAlert = true;
                message = "Please select a Role.";
                _severity = Severity.Error;
            }
            else if (string.IsNullOrWhiteSpace(reg.Username))
            {
                showAlert = true;
                message = "Please enter Username.";
                _severity = Severity.Error;
            }
            else
            {
                try
                {
                    _processing = true;

                    // reg.Username = $"{reg.FirstName[0].ToString().ToLower()}.{reg.LastName.ToLower()}";

                    await Task.Delay(1000);
                    bool isUsernameExist = await AuthService.IsUsernameExist(reg.Username);

                    if (isUsernameExist)
                    {
                        showAlert = true;
                        message = "Username already exists.";
                        _severity = Severity.Error;
                        _processing = false;
                        readonlyvar = false;
                    }
                    else
                    {
                        MudDialog?.Close();
                        reg.Password = "p@ssw0rd";
                        reg.LoginStatus = "Inactive";
                        var result = await AuthService.Register(reg);
                        _toastService.ShowSuccess("Registered Successfully!");

                        _processing = false;

                        // Update the List using the StateService
                        await AuthService.GetUsers();
                        var newList = AuthService.UserMasterTs;
                        StateService.SetState("UserList", newList);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    _processing = false;
                }
            }
        }

        private bool isShow;
        private InputType PasswordInput = InputType.Password;
        private string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        private void ShowPassword()
        {
            if (isShow)
            {
                isShow = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                isShow = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
    }
}