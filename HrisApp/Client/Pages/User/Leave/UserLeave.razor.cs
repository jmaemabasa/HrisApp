using HrisApp.Client.Pages.Dialog.Attendance;
using System.Collections;

namespace HrisApp.Client.Pages.User.Leave
{
#nullable disable
    public partial class UserLeave : ComponentBase
    {
        Emp_LeaveCreditT empLeaveCred = new();

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
        private string VERIFY {get;set;}

        protected override async Task OnInitializedAsync()
        {
            await LeaveService.GetLeave();
            leavelist = LeaveService.LeaveTypesTs;
            await Task.Delay(1);
            VERIFY = GlobalConfigService.VerifyId;
            empLeaveCred = await LeaveCredService.GetSingleLeaveCredByVerId(VERIFY);

            //await LeaveHistoryService.GetLeaveHistory();
            //leaveHistoryList = LeaveHistoryService.Emp_LeaveHistoryTs.Where(d => d.Verify_Id == VERIFY && d.From?.Year == DateTime.Now.Year && d.To?.Year == DateTime.Now.Year).OrderByDescending(d => d.To).ToList();
            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (leaveHistoryList == null || leaveHistoryList.Count == 0)
            {
                OpenOverlay();
            };

            await SetValues();
        }

        private async Task LoadList()
        {
            await LeaveHistoryService.GetLeaveHistory();
            StateService.SetState("UserLeaveHistoryList", LeaveHistoryService.Emp_LeaveHistoryTs.Where(d => d.Verify_Id == VERIFY && d.From?.Year == DateTime.Now.Year && d.To?.Year == DateTime.Now.Year).OrderByDescending(d => d.To).ToList());
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
                if (GlobalConfigService.Role == "HR" || GlobalConfigService.Role == "System Administrator") {
                    await LeaveHistoryService.CreateLeaveHistory(VERIFY, newLeaveType, newfrom, newto, noofdays, newpurpose, "Approved", DateTime.Now, "Read");
                }
                else
                {
                    await LeaveHistoryService.CreateLeaveHistory(VERIFY, newLeaveType, newfrom, newto, noofdays, newpurpose, "Pending", DateTime.Now, "Unread");
                    if (GlobalConfigService.Role == "HR" || GlobalConfigService.Role == "System Administrator")
                    {
                        await jsRuntime.InitializeNotif(DotNetObjectReference.Create(this));
                    }
                }

                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                _toastService.ShowSuccess(newLeaveType + " Leave Created Successfully!");

                AddHistoryOpen = false;

                await LeaveHistoryService.GetLeaveHistory();
                var newList = LeaveHistoryService.Emp_LeaveHistoryTs.Where(d => d.Verify_Id == VERIFY && d.From?.Year == DateTime.Now.Year && d.To?.Year == DateTime.Now.Year).OrderByDescending(d => d.To).ToList();
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
        private void OpenViewLeaveDetails(int id)
        {
            var parameters = new DialogParameters<ViewLeaveDetailsDialog>
            {
                { x => x.Id, id }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall, NoHeader = true };
            DialogService.Show<ViewLeaveDetailsDialog>("", parameters, options);
        }
        async Task SetValues()
        {
            countSl = await LeaveCredService.GetCountExistCredits(VERIFY, "Sick");
            countEl = await LeaveCredService.GetCountExistCredits(VERIFY, "Emergency");
            countMl = await LeaveCredService.GetCountExistCredits(VERIFY, "Maternity");
            countPl = await LeaveCredService.GetCountExistCredits(VERIFY, "Paternity");
            countVl = await LeaveCredService.GetCountExistCredits(VERIFY, "Vacation");
            countOl = await LeaveCredService.GetCountExistCredits(VERIFY, "Other");

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
            await Task.Delay(1000);
            isVisible = true;
            StateHasChanged();
        }
        #endregion
    }
}
