namespace HrisApp.Client.Pages.Employee
{
#nullable disable
    public partial class EmployeeRateHistory : ComponentBase
    {
        [Parameter] public int EmployeeId { get; set; }
        [Parameter] public EventCallback OnSuccessUpdate { get; set; }

        private string ROLE { get; set; } = string.Empty;

        Emp_RateHistoryT LastHistoryObj = new();
        Emp_RateHistoryT NewPreviousObj = new();

        List<Emp_RateHistoryT> RATEHISTORY = new();
        List<SubPositionT> SUBPOSITIONS = new();

        int empPositionId;
        private string newRate { get; set; }
        private DateTime? newEffDate = DateTime.Now;

        private SubPositionT NewPreviousPositionObj;

        private string clsEffEndDate = "", clsNewRate = "", clsNewEffDate = "";
        private bool _showAlert = false;

        private string clsPRate = "", clsPEffOn = "", clsPEndDate = "", clsPPosition = "";
        protected override async Task OnParametersSetAsync()
        {
            try
            {
                await PositionService.GetSubPosition();
                await EmployeeService.GetEmployee();

                LastHistoryObj = await EmpRateHistoryService.GetLastHistoryWithoutDateEnded(EmployeeId);
                StateService.OnChange += OnStateChanged;
                await LoadList();
                ROLE = GlobalConfigService.Role;
                empPositionId = EmployeeService.EmployeeTs.Where(e => e.Id == EmployeeId).FirstOrDefault().PositionId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task LoadList()
        {
            RATEHISTORY = await EmpRateHistoryService.GetHistoryList(EmployeeId);
            StateService.SetState("RateHistoryList", RATEHISTORY);
        }

        private void OnStateChanged()
        {
            RATEHISTORY = StateService.GetState<List<Emp_RateHistoryT>>("RateHistoryList");
            StateHasChanged();
        }

        private async Task SaveUpdate()
        {
            if (string.IsNullOrEmpty(newRate) || LastHistoryObj.EffEndDate == null || newEffDate == null)
            {
                _showAlert = true;
                clsEffEndDate = LastHistoryObj.EffEndDate == null ? "mud-input-error" : ""; 
                clsNewRate = string.IsNullOrEmpty(newRate) ? "mud-input-error" :  ""; 
                clsNewEffDate = newEffDate == null ? "mud-input-error" : "";
            }
            else
            {
                _showAlert = false;
                clsEffEndDate = ""; clsNewRate = ""; clsNewEffDate = "";
                LastHistoryObj.DateEnded = DateTime.Now;
                await EmpRateHistoryService.UpdateHistory(LastHistoryObj);

                Emp_RateHistoryT newupdaterate = new()
                {
                    EmployeeId = EmployeeId,
                    Rate = newRate,
                    DateStarted = DateTime.Now,
                    EffectivityDate = newEffDate,
                    PositionId = empPositionId
                };

                await EmpRateHistoryService.CreateHistory(newupdaterate);

                AddOpenDrawer = false; AddOldRateOpen = false;
                _toastService.ShowSuccess("Successfully updated.");
                RATEHISTORY = await EmpRateHistoryService.GetHistoryList(EmployeeId);
                StateService.SetState("RateHistoryList", RATEHISTORY);
                await OnSuccessUpdate.InvokeAsync();
            }
        }

        private async Task SaveOldHistory()
        {
            if (string.IsNullOrEmpty(NewPreviousObj.Rate) || NewPreviousObj.EffectivityDate == null || NewPreviousObj.EffEndDate == null || NewPreviousPositionObj == null)
            {
                _showAlert = true;
                clsPRate = string.IsNullOrEmpty(NewPreviousObj.Rate) ? "mud-input-error" : "";
                clsPEffOn = NewPreviousObj.EffectivityDate == null ? "mud-input-error" : "";
                clsPEndDate = NewPreviousObj.EffEndDate == null ? "mud-input-error" : "";
                clsPPosition = NewPreviousPositionObj == null ? "mud-input-error" : "";
            }
            else
            {
                NewPreviousObj.PositionId = NewPreviousPositionObj.Id;
                NewPreviousObj.DateStarted = DateTime.Now;
                NewPreviousObj.EmployeeId = EmployeeId;
                NewPreviousObj.DateEnded = NewPreviousObj.EffEndDate;

                await EmpRateHistoryService.CreateHistory(NewPreviousObj);
                _showAlert = false;
                clsPRate = ""; clsPEffOn = ""; clsPEndDate = ""; clsPPosition = "";
                await OnSuccessUpdate.InvokeAsync();
                AddOpenDrawer = false; AddOldRateOpen = false;
                _toastService.ShowSuccess("Successfully added.");
                RATEHISTORY = await EmpRateHistoryService.GetHistoryList(EmployeeId);
                StateService.SetState("RateHistoryList", RATEHISTORY);
            }
        }


        private async Task<IEnumerable<SubPositionT>> SearchPosition(string value)
        {
            await Task.Delay(5);
            IEnumerable<SubPositionT> list;

            list = PositionService.SubPositionTs;

            if (string.IsNullOrEmpty(value))
            {
                return list;
            }
            else
            {
                var chk = list.Where(x => x.SubPosCode.Contains(value, StringComparison.InvariantCultureIgnoreCase) ||
                                            x.Description.Contains(value, StringComparison.InvariantCultureIgnoreCase));

                return chk;
            }
        }


        bool AddOpenDrawer, AddOldRateOpen;
        Anchor anchor;
        string width = "500px", height = "100%";

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            _showAlert = false;
            NewPreviousObj = new();
            clsPRate = ""; clsPEffOn = ""; clsPEndDate = ""; clsPPosition = "";
            clsEffEndDate = ""; clsNewRate = ""; clsNewEffDate = "";

            AddOpenDrawer = (drawerx == "rateOpen");
            AddOldRateOpen = (drawerx == "addOldRateOpen");
            this.anchor = anchor;
        }

        private async Task RemoveRateHistory(int id)
        {
            var confirmResult = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmation",
                Text = "Pernamently delete this? You can't undo the action.",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"
            });

            if (confirmResult.IsConfirmed)
            {
                await EmpRateHistoryService.DeleteHistory(id);

                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
                RATEHISTORY = await EmpRateHistoryService.GetHistoryList(EmployeeId);
                StateService.SetState("RateHistoryList", RATEHISTORY);
                _toastService.ShowSuccess("Deleted Successfully!");
            }
        }
    }
}
