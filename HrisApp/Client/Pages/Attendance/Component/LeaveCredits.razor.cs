﻿namespace HrisApp.Client.Pages.Attendance.Component
{
    public partial class LeaveCredits : ComponentBase
    {
        [Parameter]
        public string verify { get; set; }

        Emp_LeaveCreditT empLeaveCred = new();
        Emp_LeaveHistoryT obj = new();
        private bool isUpdateStatus = false;
        private bool visibleView;
        private DialogOptions dialogOptions = new() { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall, NoHeader = true };

        List<Emp_LeaveHistoryT> leaveHistoryList = new();
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        private Emp_LeaveHistoryT selectedItem1 = null;

        private string availableLeavetext = "";
        private string availableLeavetextEL = "";
        private string availableLeavetextML = "";
        private string availableLeavetextPL = "";
        private string availableLeavetextVL = "";
        private string availableLeavetextOL = "";

        private double countSl, countEl, countMl, countPl, countVl, countOl;

        protected override async Task OnInitializedAsync()
        {
            await LeaveService.GetLeave();
            leavelist = LeaveService.LeaveTypesTs;
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                empLeaveCred = await LeaveCredService.GetSingleLeaveCredByVerId(verify);

                StateService.OnChange += OnStateChanged;
                await LoadList();

                if (leaveHistoryList == null || leaveHistoryList.Count == 0)
                {
                    OpenOverlay();
                };

                await SetValues();

            }
            catch (Exception)
            {
                Console.WriteLine("");
            }
        }

        private async Task LoadList()
        {
            await LeaveHistoryService.GetLeaveHistory();
            StateService.SetState("UserLeaveHistoryList", LeaveHistoryService.Emp_LeaveHistoryTs.Where(d => d.Verify_Id == empLeaveCred.Verify_Id && d.From?.Year == DateTime.Now.Year && d.To?.Year == DateTime.Now.Year).OrderBy(d => GetStatusOrder(d.Status)).ThenByDescending(d => d.To).ToList());
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            leaveHistoryList = StateService.GetState<List<Emp_LeaveHistoryT>>("UserLeaveHistoryList");
            StateHasChanged();
        }

        #region SAVE BUTTON FUNCTIONS
        public List<LeaveTypesT> leavelist = new();

        public string newLeaveType = "--Select Leave Type--";
        public string newpurpose = "";
        public DateTime? newfrom = DateTime.Today;
        public DateTime? newto = DateTime.Today;
        public string noofdays = "1";
        private async Task ConfirmCreateLeave()
        {
            if (newLeaveType == "--Select Leave Type--")
            {
                await ShowErrorMessageBox("Please select leave type!");
            }
            else if (string.IsNullOrWhiteSpace(newpurpose))
            {
                await ShowErrorMessageBox("Please fill up the No of Days field!");
            }
            else if (string.IsNullOrWhiteSpace(noofdays))
            {
                await ShowErrorMessageBox("Please fill up the purpose!");
            }
            else
            {
                await LeaveHistoryService.CreateLeaveHistory(verify, newLeaveType, newfrom, newto, noofdays, newpurpose, "Approved", DateTime.Now, "Read");

                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                _toastService.ShowSuccess(newLeaveType + " Created Successfully!");

                AddHistoryOpen = false;

                await LeaveHistoryService.GetLeaveHistory();
                var newList = LeaveHistoryService.Emp_LeaveHistoryTs.Where(d => d.Verify_Id == empLeaveCred.Verify_Id && d.From?.Year == DateTime.Now.Year && d.To?.Year == DateTime.Now.Year).OrderBy(d => GetStatusOrder(d.Status)).ThenByDescending(d => d.To).ToList();
                StateService.SetState("UserLeaveHistoryList", newList);

                await SetValues();
            }
        }

        async Task UpdateLeave()
        {
            if (empLeaveCred == null)
                return;

            if (string.IsNullOrWhiteSpace(empLeaveCred.Verify_Id))
            {
                await ShowErrorMessageBox("Please fill up the name!");
            }
            else
            {
                await LeaveCredService.UpdateLeaveCred(empLeaveCred);
                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                _toastService.ShowSuccess("Updated Successfully!");
                UpdateLeaveBalOpen = false;

                await SetValues();
            }
        }
        #endregion

        #region OPEN DRAWERS FUNCTIONS
        bool UpdateLeaveBalOpen, AddHistoryOpen;
        Anchor anchor;
        private readonly string _width = "500px";
        private readonly string _height = "100%";

        void OpenDrawer(Anchor anchor, string drawerx)
        {
            UpdateLeaveBalOpen = (drawerx == "UpdateLeaveBalOpen");
            AddHistoryOpen = (drawerx == "AddHistoryOpen");
            this.anchor = anchor;
        }
        #endregion

        #region FUNCTIONS
        private async Task OpenViewLeaveDetails(int id)
        {
            obj = await LeaveHistoryService.GetSingleLeaveHistory((int)id);
            visibleView = true;
        }

        void Cancel() => visibleView = false;

        async Task SetValues()
        {
            countSl = await LeaveCredService.GetCountExistCredits(verify, "Sick");
            countEl = await LeaveCredService.GetCountExistCredits(verify, "Emergency");
            countMl = await LeaveCredService.GetCountExistCredits(verify, "Maternity");
            countPl = await LeaveCredService.GetCountExistCredits(verify, "Paternity");
            countVl = await LeaveCredService.GetCountExistCredits(verify, "Vacation");
            countOl = await LeaveCredService.GetCountExistCredits(verify, "Other");

            availableLeavetext = (((Convert.ToDouble(empLeaveCred.SL) - countSl) / Convert.ToDouble(empLeaveCred.SL)) * 100).ToString() + "%";
            availableLeavetextEL = (((Convert.ToDouble(empLeaveCred.EL) - countEl) / Convert.ToDouble(empLeaveCred.EL)) * 100).ToString() + "%";
            availableLeavetextML = (((Convert.ToDouble(empLeaveCred.ML) - countMl) / Convert.ToDouble(empLeaveCred.ML)) * 100).ToString() + "%";
            availableLeavetextPL = (((Convert.ToDouble(empLeaveCred.PL) - countPl) / Convert.ToDouble(empLeaveCred.PL)) * 100).ToString() + "%";
            availableLeavetextVL = (((Convert.ToDouble(empLeaveCred.VL) - countVl) / Convert.ToDouble(empLeaveCred.VL)) * 100).ToString() + "%";
            availableLeavetextOL = (((Convert.ToDouble(empLeaveCred.OL) - countOl) / Convert.ToDouble(empLeaveCred.OL)) * 100).ToString() + "%";

            newLeaveType = "--Select Leave Type--";
            newpurpose = "";
            newfrom = DateTime.Today;
            newto = DateTime.Today;
            noofdays = "1";
        }

        private async Task ShowErrorMessageBox(string mess)
        {
            bool? result = await DialogService.ShowMessageBox(
            "Warning",
            mess,
            yesText: "Ok");
        }

        public void HandleDateToChanged(DateTime? newDate)
        {
            newto = newDate;

            TimeSpan? duration = newto - newfrom;

            if (duration.HasValue)
            {
                noofdays = (duration.Value.Days + 1).ToString();
            }
            else
            {
                Console.WriteLine();
            }
        }
        public void HandleDateToChangedFrom(DateTime? newDate)
        {
            newfrom = newDate;

            TimeSpan? duration = newto - newfrom;

            if (duration.HasValue)
            {
                noofdays = (duration.Value.Days + 1).ToString();
            }
            else
            {
                Console.WriteLine();
            }
        }

        private bool isVisible;
        public async void OpenOverlay()
        {
            isVisible = false;
            await Task.Delay(2000);
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
            var newList = LeaveHistoryService.Emp_LeaveHistoryTs.Where(d => d.Verify_Id == obj.Verify_Id && d.From?.Year == DateTime.Now.Year && d.To?.Year == DateTime.Now.Year).OrderBy(d => GetStatusOrder(d.Status)).ThenByDescending(d => d.To).ToList();
            StateService.SetState("UserLeaveHistoryList", newList);

            await SetValues();
            OpenDropDownlist();
        }
        #endregion

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
    }
}