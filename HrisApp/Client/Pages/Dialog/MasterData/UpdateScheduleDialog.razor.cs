using Newtonsoft.Json;
using System.Threading;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateScheduleDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }


        //private ScheduleTypeT schedule = null;
        private ScheduleTypeT schedule = new();

        void Cancel() => MudDialog.Cancel();


        protected override async Task OnParametersSetAsync()
        {
            //schedule = ScheduleService.ScheduleTs.Find(d => d.Id == Id);
            schedule = await ScheduleService.GetSingleSchedule(Id);
        }

        async Task UpdateArea()
        {
            if (schedule == null)
                return;
            MudDialog.Close();

            if (string.IsNullOrWhiteSpace(schedule.Name) || string.IsNullOrWhiteSpace(schedule.TimeIn) || string.IsNullOrWhiteSpace(schedule.TimeOut))
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Warning",
                    Text = "Please fill up the fields!",
                    Icon = SweetAlertIcon.Warning
                });
            }
            else
            {
                var confirmResult = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Confirmation",
                    Text = "Are you sure you want to update the " + schedule.Name + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    await ScheduleService.UpdateSchedule(schedule);
                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                    _toastService.ShowSuccess(schedule.Name + " Updated Successfully!");

                    await ScheduleService.GetScheduleList();
                    var newList = ScheduleService.ScheduleTs;
                    StateService.SetState("SchedList", newList);
                }
            }
        }
    }
}
