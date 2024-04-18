using HrisApp.Shared.Models.DummyModel;
using System.Net;

namespace HrisApp.Client.Pages.Dialog.Attendance
{
#nullable disable

    public partial class AddAttendanceRec : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        private BioModelT obj = new();
        private TimeSpan? time = DateTime.Now - DateTime.MinValue;
        // private Timer timer;

        private List<EmployeeT> empList = new();
        private List<Emp_PayrollT> payList = new();

        private DateTime? DateOnly = DateTime.Now;
        private void Cancel() => MudDialog.Cancel();

        private EmployeeT fieldObj;


        protected override async Task OnInitializedAsync()
        {
            obj.TimeOnlyRecord = DateTime.Now;
            obj.AttendanceType = "Manual Entry";

            empList = await EmployeeService.GetEmployeeList();
            payList = await PayrollService.GetPayrollList();
            // timer = new Timer(UpdateCurrentTime, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        }

        private async Task OnValidSubmit(EditContext context)
        {
            StateHasChanged();

            if (fieldObj == null)
            {
                _showAlert = true;
                _message = "Employee is required.";
                _severity = Severity.Error;
            }
            else
            {
                var hours = time.Value.Hours;
                var minutes = time.Value.Minutes;
                var seconds = time.Value.Seconds;

                // Combine date from MudDatePicker with time components
                obj.TimeOnlyRecord = new DateTime(obj.TimeOnlyRecord.Year, obj.TimeOnlyRecord.Month, obj.TimeOnlyRecord.Day, hours, minutes, seconds);
                obj.DateOnlyRecord = (DateTime)DateOnly.Value.Date;
                obj.DateTimeRecord = obj.TimeOnlyRecord.ToString("M/dd/yyyy hh:mm:ss tt");
                var biometricid = payList.Where(e => e.Verify_Id.Equals(fieldObj.Verify_Id)).FirstOrDefault();
                obj.IndRegID = Convert.ToInt32(biometricid.BiometricID);
                obj.Remarks = string.IsNullOrEmpty(obj.Remarks) ? "-" : obj.Remarks;
                obj.IPAddress = "-";

                await BioService.CreateAttendanceRec(obj);
                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
                _toastService.ShowSuccess(TokenCons.CREATESUCCESS);

                _showAlert = false;
                MudDialog.Close();

                await RELOADTABLE();
            }
        }
        private async Task<IEnumerable<EmployeeT>> SearchEmp(string value)
        {
            await Task.Delay(5);

            if (string.IsNullOrEmpty(value))
            {
                return empList;
            }
            else
            {
                var chk = empList.Where(x => x.FirstName.Contains(value, StringComparison.InvariantCultureIgnoreCase) ||
                                            x.LastName.Contains(value, StringComparison.InvariantCultureIgnoreCase) ||
                                            x.MiddleName.Contains(value, StringComparison.InvariantCultureIgnoreCase));

                return chk;
            }
        }


        private async Task RELOADTABLE()
        {

            List<BioAttendanceDummy> _attendanceList = new();
            var biorecord = await BioService.GetAttendanceRecList();
            _attendanceList.Clear();
            foreach (var item in biorecord)
            {
                EmployeeT emp = new();
                var pay = payList.Where(e => e.BiometricID.Equals(item.IndRegID.ToString())).FirstOrDefault();
                BioAttendanceDummy dummymodel = new();
                if (pay == null)
                {
                    dummymodel = new()
                    {
                        Id = item.Id,
                        Verify_Id = "",
                        FirstName = "",
                        LastName = "",
                        MachineNumber = item.MachineNumber,
                        IndRegID = item.IndRegID,
                        DateTimeRecord = item.DateTimeRecord,
                        DateOnlyRecord = item.DateOnlyRecord,
                        TimeOnlyRecord = item.TimeOnlyRecord,
                        AttendanceType = item.AttendanceType,
                        IPAddress = item.IPAddress,
                        Remarks = item.Remarks
                    };
                }
                else
                {
                    emp = empList.Where(e => e.Verify_Id.Equals(pay.Verify_Id)).FirstOrDefault();
                    dummymodel = new()
                    {
                        Id = item.Id,
                        Verify_Id = emp!.Verify_Id,
                        FirstName = emp!.FirstName,
                        LastName = emp!.LastName,
                        MachineNumber = item.MachineNumber,
                        IndRegID = item.IndRegID,
                        DateTimeRecord = item.DateTimeRecord,
                        DateOnlyRecord = item.DateOnlyRecord,
                        TimeOnlyRecord = item.TimeOnlyRecord,
                        AttendanceType = item.AttendanceType,
                        IPAddress = item.IPAddress,
                        Remarks = item.Remarks
                    };
                }


                _attendanceList.Add(dummymodel);
            }

            StateService.SetState("AttendanceRecList", _attendanceList.OrderByDescending(e => e.TimeOnlyRecord).ToList());
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