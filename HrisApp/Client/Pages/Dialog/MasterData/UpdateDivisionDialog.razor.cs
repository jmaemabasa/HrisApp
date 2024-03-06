using HrisApp.Client.Pages.MasterData;
using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateDivisionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public int Id { get; set; }

        private DivisionT division = new();

        private void Cancel() => MudDialog.Cancel();

        protected override async Task OnParametersSetAsync()
        {
            //division = DivisionService.DivisionTs.Find(d => d.Id == Id);
            division = await DivisionService.GetSingleDivision(Id);
        }

        private async Task UpdateArea()
        {
            if (division == null)
                return;

            if (string.IsNullOrWhiteSpace(division.Name))
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
                    Text = "Are you sure you want to update the " + division.Name + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    await DivisionService.UpdateDivision(division);
                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                    _toastService.ShowSuccess(division.Name + " Updated Successfully!");

                    await DivisionService.GetDivision();
                    var newList = DivisionService.DivisionTs;
                    StateService.SetState("DivisionList", newList);
                }
            }
        }
    }
}