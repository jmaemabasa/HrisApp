namespace HrisApp.Client.Pages.Attendance
{
    public partial class LeaveApprovals : ComponentBase
    {
        //table
        private List<Emp_LeaveHistoryT> leaveHistoryList = new();

        private readonly string infoFormat = "{first_item}-{last_item} of {all_items}";
        private Emp_LeaveHistoryT selectedItem1 = null!;

        //update status
        private Emp_LeaveHistoryT obj = new();

        private bool isUpdateStatus = false;
        private bool visibleView;
        private readonly DialogOptions dialogOptions = new() { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall, NoHeader = true };

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
            StateService.SetState("ApprovalLeaveHistoryList", LeaveHistoryService.Emp_LeaveHistoryTs.Where(d => d.From?.Year == DateTime.Now.Year && d.To?.Year == DateTime.Now.Year).OrderBy(d => GetStatusOrder(d.Status)).ThenByDescending(d => d.To).ToList());
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

        private void Cancel()
        {
            visibleView = false;
            isUpdateStatus = false;
        }

        private bool isVisible;

        public async void OpenOverlay()
        {
            isVisible = false;
            await Task.Delay(1000);
            isVisible = true;
            StateHasChanged();
        }

        #endregion FUNCTIONS

        #region VIEWLEAVE DIALOG

        private void OpenDropDownlist()
        {
            isUpdateStatus = !isUpdateStatus;
        }

        private async Task SaveUpdateStatus()
        {
            await LeaveHistoryService.UpdateLeaveHistory(obj);

            await LeaveHistoryService.GetLeaveHistory();
            var newList = LeaveHistoryService.Emp_LeaveHistoryTs.Where(d => d.From?.Year == DateTime.Now.Year && d.To?.Year == DateTime.Now.Year).OrderBy(d => GetStatusOrder(d.Status)).ThenByDescending(d => d.To).ToList();
            StateService.SetState("ApprovalLeaveHistoryList", newList);

            OpenDropDownlist();
        }

        private int GetStatusOrder(string status)
        {
            return status.ToLowerInvariant() switch
            {
                "pending" => 1,
                "approved" => 2,
                "rejected" => 3,
                // Add more cases if needed
                _ => int.MaxValue,// Any other status is placed at the end
            };
        }

        #endregion VIEWLEAVE DIALOG
    }
}