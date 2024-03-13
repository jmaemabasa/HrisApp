namespace HrisApp.Client.Pages.Dialog.Attendance
{
#nullable disable

    public partial class AddAttendanceRec : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        private AttendanceRecordT obj = new();
        private TimeSpan? time = DateTime.Now - DateTime.MinValue;
        // private Timer timer;

        private List<EmployeeT> empList = new();
        private List<Emp_PayrollT> payList = new();

        private void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            obj.Time = DateTime.Now;

            empList = await EmployeeService.GetEmployeeList();
            payList = await PayrollService.GetPayrollList();
            // timer = new Timer(UpdateCurrentTime, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private async Task OnValidSubmit(EditContext context)
        {
            StateHasChanged();

            var count = await AttRecSvc.GetExistingCount(obj.Time?.ToString("MM/dd/yyyy"), obj.AC_No, obj.State);
            if (count == 0)
            {
                var hours = time.Value.Hours;
                var minutes = time.Value.Minutes;

                // Combine date from MudDatePicker with time components
                obj.Time = new DateTime(obj.Time.Value.Year, obj.Time.Value.Month, obj.Time.Value.Day, hours, minutes, 0);

                obj.Exception = "OK";

                string verid = "";
                foreach (var item in payList)
                {
                    if (item.BiometricID == obj.AC_No)
                    {
                        verid = item.Verify_Id;
                    }
                }

                var emp = empList.FirstOrDefault(d => d.Verify_Id == verid);
                if (emp != null)
                {
                    obj.Name = $"{emp.LastName}";
                }

                await AttRecSvc.CreateAttendanceRec(obj);
                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
                _toastService.ShowSuccess(TokenCons.CREATESUCCESS);

                MudDialog.Close();
                StateService.SetState("AttendanceRecList", await AttRecSvc.GetAttendanceRecList());
            }
            else
            {
                _showAlert = true;
                _severity = Severity.Error;
                _message = TokenCons.ALREADYEXISTATT;
            }
        }

        // private void UpdateCurrentTime(object state)
        // {
        //     // Update the time to the current time
        //     time = DateTime.Now.TimeOfDay;

        //     // Notify Blazor that the state has changed
        //     InvokeAsync(StateHasChanged);
        // }

        #region ERROR TRAPPING

        private string _message = string.Empty;
        private Severity _severity;
        private bool _showAlert = false;

        public void CloseMe() => _showAlert = false;

        #endregion ERROR TRAPPING
    }
}