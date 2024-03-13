using HrisApp.Client.Pages.Dialog.Account;

namespace HrisApp.Client.Pages.Account
{
    public partial class AccountList : ComponentBase
    {
        private List<EmployeeT> employeeList = new();

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(500);
            StateService.OnChange += OnStateChanged;
            await LoadList();

            await EmployeeService.GetEmployee();
            employeeList = EmployeeService.EmployeeTs;
        }

        private async Task LoadList()
        {
            await AuthService.GetUsers();
            StateService.SetState("UserList", AuthService.UserMasterTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            userList = StateService.GetState<List<UserMasterT>>("UserList");
            StateHasChanged();
        }

        private bool isVisible;

        public async void OpenOverlay()
        {
            isVisible = true;
            await Task.Delay(3000);
            isVisible = false;
            StateHasChanged();
        }

        private static string Userstatusclass(string status)
        {
            return status switch
            {
                "Active" => "statusActive",
                "Inactive" => "statusInActive",
                _ => "statusDefChip",
            };
        }

        private void ShowLogs(int id) => NavigationManager.NavigateTo($"/account/logs/{id}");

        //TABLEEES
        private readonly string infoFormat = "{first_item}-{last_item} of {all_items}";

        private string searchString1 = "";
        private List<UserMasterT> userList = new();
        private UserMasterT selectedItem1 = null!;

        private bool FilterFunc1(UserMasterT user) => FilterFunc(user, searchString1);

        private bool FilterFunc(UserMasterT user, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            //if ((user.FirstName + " " + user.LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //    return true;
            if (user.Role.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (user.LoginStatus.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (user.Username.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        private void OpenAddUser()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Small, FullWidth = true, NoHeader = true };
            DialogService.Show<AddAccountDialog>("", options);
        }
    }
}