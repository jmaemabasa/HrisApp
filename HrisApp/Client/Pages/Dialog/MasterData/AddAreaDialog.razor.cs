namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddAreaDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private string newArea = "";

        void Cancel() => MudDialog.Cancel();


        private async Task ConfirmCreateArea()
        {
            if (string.IsNullOrWhiteSpace(newArea))
            {
                await ShowErrorMessageBox("Please fill up the area name!");
            }
            else
            {
                MudDialog.Close();
                var confirmResult = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Confirmation",
                    Text = "Are you sure you want to add " + newArea + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    await AreaService.CreateArea(newArea);

                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                    _toastService.ShowSuccess(newArea + " Created Successfully!");

                    // Update the areaList using the StateService
                    await AreaService.GetArea();
                    var newAreaList =  AreaService.AreaTs;
                    StateService.SetState("AreaList", newAreaList);
                }
            }
        }
        private async Task ShowErrorMessageBox(string mess)
        {
            bool? result = await _dialogService.ShowMessageBox(
            "Warning",
            mess,
            yesText: "Ok");
        }

    }
}
