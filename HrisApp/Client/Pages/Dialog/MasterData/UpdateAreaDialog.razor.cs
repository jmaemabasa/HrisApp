using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateAreaDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public int Id { get; set; }

        private AreaT area = new();

        private void Cancel() => MudDialog.Cancel();

        protected override async Task OnParametersSetAsync()
        {
            //area = AreaService.AreaTs.Find(d => d.Id == Id);
            area = await AreaService.GetSingleArea((int)Id);
        }

        private async Task UpdateArea()
        {
            if (area == null)
                return;

            if (string.IsNullOrWhiteSpace(area.Name))
            {
                GlobalConfigService.OpenWarningDialog("Please fill up the area name.");
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
    }
}