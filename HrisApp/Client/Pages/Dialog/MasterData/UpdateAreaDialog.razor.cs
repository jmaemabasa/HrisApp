using HrisApp.Client.Pages.MasterData;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateAreaDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }

        private AreaT area = null;

        void Cancel() => MudDialog.Cancel();

        protected override async Task OnParametersSetAsync()
        {
            area = AreaService.AreaTs.Find(d => d.Id == Id);
            //area = await AreaService.GetSingleArea((int)Id);
        }

        async Task UpdateArea()
        {
            if (area == null)
                return;

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
                await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "AreaT", $"AreaId: {area.Id} updated successfully.", JsonConvert.SerializeObject(area), DateTime.Now);

                _toastService.ShowSuccess(area.Name + " Updated Successfully!");
                await Task.Delay(1000);

                await jsRuntime.InvokeVoidAsync("location.reload");
                navigationManager.NavigateTo("/area");

            }
        }
    }
}
