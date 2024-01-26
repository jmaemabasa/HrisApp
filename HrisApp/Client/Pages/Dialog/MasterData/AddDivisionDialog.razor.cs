using System.Xml.Linq;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddDivisionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private string newDivision = "";

        void Cancel() => MudDialog.Cancel();

        private async Task ConfirmCreateDivision()
        {
            if (string.IsNullOrWhiteSpace(newDivision))
            {
                //await ShowErrorMessageBox("Please fill up the division name!");
                GlobalConfigService.OpenWarningDialog("Please fill up the division name.");
            }
            else
            {
                MudDialog.Close();
                var confirmResult = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Confirmation",
                    Text = "Are you sure you want to add " + newDivision + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    await DivisionService.CreateDivision(newDivision);

                    _toastService.ShowSuccess(newDivision + " Created Successfully!");

                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                    await DivisionService.GetDivision();
                    var newList = DivisionService.DivisionTs;
                    StateService.SetState("DivisionList", newList);

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
