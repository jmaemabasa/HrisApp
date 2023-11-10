namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddScheduleDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private string newSchedule = "";
        private string timein = "";
        private string timeout = "";

        void Cancel() => MudDialog.Cancel();


        private async Task ConfirmCreateSchedule()
        {
            MudDialog.Close();

            if (string.IsNullOrWhiteSpace(newSchedule) || string.IsNullOrWhiteSpace(timein) || string.IsNullOrWhiteSpace(timeout))
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
                    Text = "Are you sure you want to add " + newSchedule + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    string strTimein = DateTime.Parse(timein).ToString(@"hh\:mm tt");
                    string strTimeout = DateTime.Parse(timeout).ToString(@"hh\:mm tt");
                    await ScheduleService.CreateSchedule(newSchedule, strTimein, strTimeout);

                    await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "ScheduleT", $"Schedule: {newSchedule} created successfully.", "_", DateTime.Now);
                    _toastService.ShowSuccess(newSchedule + " Created Successfully!");

                    await Task.Delay(1000);

                    await jsRuntime.InvokeVoidAsync("location.reload");
                    NavigationManager.NavigateTo("/schedule");
                }
            }
        }
    }
}
