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

        int empPositionId;
        private string NewRate { get; set; }
        private DateTime? NewEffDate = DateTime.Now;

        private SubPositionT NewPreviousPositionObj;

        private string clsEffEndDate = "", clsNewRate = "", clsNewEffDate = "";
        private bool _showAlert = false;
        private string _message = "";

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
            if (string.IsNullOrEmpty(NewRate) || LastHistoryObj.EffEndDate == null || NewEffDate == null)
            {
                _showAlert = true;
                _message = "Fill out all fields";
                clsEffEndDate = LastHistoryObj.EffEndDate == null ? "mud-input-error" : "";
                clsNewRate = string.IsNullOrEmpty(NewRate) ? "mud-input-error" : "";
                clsNewEffDate = NewEffDate == null ? "mud-input-error" : "";
            }
            else if (LastHistoryObj.EffEndDate?.Date < LastHistoryObj.EffectivityDate?.Date)
            {
                _showAlert = true;
                _message = "End date should not be less than effectivity date";
                clsNewRate = string.IsNullOrEmpty(NewRate) ? "mud-input-error" : "";
                clsEffEndDate = LastHistoryObj.EffEndDate?.Date < LastHistoryObj.EffectivityDate?.Date ? "mud-input-error" : "";
            }
            else
            {
                _showAlert = false;
                clsEffEndDate = ""; clsNewRate = ""; clsNewEffDate = "";

                if ((NewEffDate?.Date >= LastHistoryObj.EffectivityDate?.Date && NewEffDate?.Date <= LastHistoryObj.EffEndDate?.Date) || // NewEffDate falls within the range
                NewEffDate?.Date == LastHistoryObj.EffectivityDate?.Date || // NewEffDate is the same as an existing effectivity date
                                NewEffDate?.Date == LastHistoryObj.EffEndDate?.Date) // NewEffDate is the same as an existing end date 
                {
                    _showAlert = true;
                    _message = "Effectivity date should not overlap to the current one";
                    clsNewEffDate = "mud-input-error";
                }
                else
                {
                    foreach (var item in RATEHISTORY)
                    {
                        if ((NewEffDate?.Date >= item.EffectivityDate?.Date && NewEffDate?.Date <= item.EffEndDate?.Date) || // NewEffDate falls within the range
                                NewEffDate?.Date == item.EffectivityDate?.Date || // NewEffDate is the same as an existing effectivity date
                                NewEffDate?.Date == item.EffEndDate?.Date) // NewEffDate is the same as an existing end date
                        {
                            _showAlert = true;
                            _message = "Effectivity date should not overlap to the existing one";
                            clsNewEffDate = "mud-input-error";
                            return;
                        }
                    }

                    LastHistoryObj.DateEnded = DateTime.Now;
                    await EmpRateHistoryService.UpdateHistory(LastHistoryObj);

                    Emp_RateHistoryT newupdaterate = new()
                    {
                        EmployeeId = EmployeeId,
                        Rate = NewRate,
                        DateStarted = DateTime.Now,
                        EffectivityDate = NewEffDate,
                        PositionId = empPositionId,
                        DateModified = DateTime.Now
                    };

                    await EmpRateHistoryService.CreateHistory(newupdaterate);
                    NewEffDate = DateTime.Now;
                    NewRate = "";
                    AddOpenDrawer = false; AddOldRateOpen = false;
                    _toastService.ShowSuccess("Successfully updated.");
                    RATEHISTORY = await EmpRateHistoryService.GetHistoryList(EmployeeId);
                    StateService.SetState("RateHistoryList", RATEHISTORY);
                    await OnSuccessUpdate.InvokeAsync();
                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);
                }
            }
        }

        private async Task SaveOldHistory()
        {
            if (string.IsNullOrEmpty(NewPreviousObj.Rate) || NewPreviousObj.EffectivityDate == null || NewPreviousObj.EffEndDate == null || NewPreviousPositionObj == null)
            {
                _showAlert = true;
                _message = "Fill out all fields";
                clsPRate = string.IsNullOrEmpty(NewPreviousObj.Rate) ? "mud-input-error" : "";
                clsPEffOn = NewPreviousObj.EffectivityDate == null ? "mud-input-error" : "";
                clsPEndDate = NewPreviousObj.EffEndDate == null ? "mud-input-error" : "";
                clsPPosition = NewPreviousPositionObj == null ? "mud-input-error" : "";
            }
            else if (NewPreviousObj.EffEndDate?.Date < NewPreviousObj.EffectivityDate?.Date)
            {
                _showAlert = true;
                _message = "End date should not be less than effectivity date";
                clsPRate = string.IsNullOrEmpty(NewPreviousObj.Rate) ? "mud-input-error" : "";
                clsPEffOn = NewPreviousObj.EffectivityDate == null ? "mud-input-error" : "";
                clsPPosition = NewPreviousPositionObj == null ? "mud-input-error" : "";
                clsPEndDate = NewPreviousObj.EffEndDate?.Date < NewPreviousObj.EffectivityDate?.Date ? "mud-input-error" : "";
            }
            else
            {
                _showAlert = false;
                clsPRate = ""; clsPEffOn = ""; clsPEndDate = ""; clsPPosition = "";

                foreach (var item in RATEHISTORY)
                {
                    if ((NewPreviousObj.EffectivityDate?.Date >= item.EffectivityDate?.Date && NewPreviousObj.EffectivityDate?.Date <= item.EffEndDate?.Date) ||
                            (NewPreviousObj.EffEndDate?.Date >= item.EffectivityDate?.Date && NewPreviousObj.EffEndDate?.Date <= item.EffEndDate?.Date) ||
                            (NewPreviousObj.EffectivityDate?.Date <= item.EffectivityDate?.Date && NewPreviousObj.EffEndDate?.Date >= item.EffEndDate?.Date))
                    {
                        Console.WriteLine(1);
                        _showAlert = true;
                        _message = "New object should not overlap to the existing one";
                        clsPEndDate = clsPEffOn = "mud-input-error";
                        return;
                    }
                }

                Console.WriteLine(2);

                NewPreviousObj.PositionId = NewPreviousPositionObj.Id;
                NewPreviousObj.DateStarted = DateTime.Now;
                NewPreviousObj.EmployeeId = EmployeeId;
                NewPreviousObj.DateEnded = NewPreviousObj.EffEndDate;

                await EmpRateHistoryService.CreateHistory(NewPreviousObj);
                await OnSuccessUpdate.InvokeAsync();
                AddOpenDrawer = false; AddOldRateOpen = false;
                _toastService.ShowSuccess("Successfully added.");
                RATEHISTORY = await EmpRateHistoryService.GetHistoryList(EmployeeId);
                StateService.SetState("RateHistoryList", RATEHISTORY);
                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
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
