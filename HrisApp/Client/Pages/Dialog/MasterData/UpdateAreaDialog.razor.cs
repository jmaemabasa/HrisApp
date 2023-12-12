using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateAreaDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }

        private AreaT area = new();

        void Cancel() => MudDialog.Cancel();

        protected override async Task OnParametersSetAsync()
        {
            //area = AreaService.AreaTs.Find(d => d.Id == Id);
            area = await AreaService.GetSingleArea((int)Id);
        }

        async Task UpdateArea()
        {
            if (area == null)
                return;

            if (string.IsNullOrWhiteSpace(area.Name))
            {
                await ShowErrorMessageBox("Please fill up the area name!");
            }
            else
            {
                MudDialog.Close();
                var confirmResult = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Confirmation",
                    Text = "Are you sure you want to update the " + area.Name + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    await AreaService.UpdateArea(area);
                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                    _toastService.ShowSuccess(area.Name + " Updated Successfully!");

                    // Update the areaList using the StateService
                    await AreaService.GetArea();
                    var newAreaList = AreaService.AreaTs;
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
