using HrisApp.Client.Pages.MasterData;
using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateScheduleDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }


        private ScheduleTypeT schedule = null;

        void Cancel() => MudDialog.Cancel();


        protected override async Task OnParametersSetAsync()
        {
            schedule = ScheduleService.ScheduleTs.Find(d => d.Id == Id);
        }

        async Task UpdateArea()
        {
            if (schedule == null)
                return;

            MudDialog.Close();

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
                await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "ScheduleT", $"ScheduleId: {schedule.Id} updated successfully.", JsonConvert.SerializeObject(schedule), DateTime.Now);

                _toastService.ShowSuccess(schedule.Name + " Updated Successfully!");
                await Task.Delay(1000);

                await jsRuntime.InvokeVoidAsync("location.reload");
                NavigationManager.NavigateTo("/schedule");

            }
        }
    }
}
