namespace HrisApp.Client.Pages.Attendance
{
    public partial class LeaveApprovals : ComponentBase
    {
        //table
        List<Emp_LeaveHistoryT> leaveHistoryList = new();
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        private Emp_LeaveHistoryT selectedItem1 = null;

        //update status
        Emp_LeaveHistoryT obj = new();
        private bool isUpdateStatus = false;
        private bool visibleView;
        private DialogOptions dialogOptions = new() { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall, NoHeader = true };

        public List<LeaveTypesT> leavelist = new();

        protected override async Task OnInitializedAsync()
        {
            await LeaveService.GetLeave();
            leavelist = LeaveService.LeaveTypesTs;

            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (leaveHistoryList == null || leaveHistoryList.Count == 0)
            {
                OpenOverlay();
            };
        }

        private async Task LoadList()
        {
            await LeaveHistoryService.GetLeaveHistory();
            StateService.SetState("ApprovalLeaveHistoryList", LeaveHistoryService.Emp_LeaveHistoryTs.OrderBy(d => GetStatusOrder(d.Status)).ThenByDescending(d => d.To).ToList());
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            leaveHistoryList = StateService.GetState<List<Emp_LeaveHistoryT>>("ApprovalLeaveHistoryList");
            StateHasChanged();
        }


        #region FUNCTIONS
        private async Task OpenViewLeaveDetails(int id)
        {
            obj = await LeaveHistoryService.GetSingleLeaveHistory((int)id);
            visibleView = true;
        }

        void Cancel() { 
            visibleView = false;
            isUpdateStatus = false;
        }

        private async Task ShowErrorMessageBox(string mess)
        {
            bool? result = await DialogService.ShowMessageBox(
            "Warning",
            mess,
            yesText: "Ok");
        }

        private bool isVisible;
        public async void OpenOverlay()
        {
            isVisible = false;
            await Task.Delay(1000);
            isVisible = true;
            StateHasChanged();
        }
        #endregion

        #region VIEWLEAVE DIALOG
        private void OpenDropDownlist()
        {
            isUpdateStatus = !isUpdateStatus;
        }

        async Task SaveUpdateStatus()
        {
            await LeaveHistoryService.UpdateLeaveHistory(obj);

            await LeaveHistoryService.GetLeaveHistory();
            var newList = LeaveHistoryService.Emp_LeaveHistoryTs.OrderBy(d => GetStatusOrder(d.Status)).ThenByDescending(d => d.To).ToList();
            StateService.SetState("ApprovalLeaveHistoryList", newList);

            OpenDropDownlist();
        }

        private int GetStatusOrder(string status)
        {
            switch (status.ToLowerInvariant())
            {
                case "pending":
                    return 1;
                case "approved":
                    return 2;
                case "rejected":
                    return 3;
                // Add more cases if needed
                default:
                    return int.MaxValue; // Any other status is placed at the end
            }
        }
        #endregion
    }
}
