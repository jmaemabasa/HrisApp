using HrisApp.Client.Pages.Dialog.Account;

namespace HrisApp.Client.Pages.Account
{
    public partial class AccountList : ComponentBase
    {
        List<AreaT> areaList = new();


        protected override async Task OnInitializedAsync()
        {
            StateService.OnChange += OnStateChanged;
            await LoadList();

            await AreaService.GetArea();
            areaList = AreaService.AreaTs;
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

        private static string userstatusclass(string status)
        {
            return status switch
            {
                "Active" => "statusActive",
                "Inactive" => "statusInActive",
                _ => "statusDefChip",
            };
        }

        void ShowLogs(int id) => NavigationManager.NavigateTo($"/account/logs/{id}");

        //TABLEEES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<UserMasterT> userList = new();
        private UserMasterT selectedItem1 = null;
        private HashSet<UserMasterT> selectedItems = new();

        private bool FilterFunc1(UserMasterT user) => FilterFunc(user, searchString1);

        private bool FilterFunc(UserMasterT user, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if ((user.FirstName + " " + user.LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (user.Role.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (user.LoginStatus.Contains(searchString, StringComparison.OrdinalIgnoreCase))
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
