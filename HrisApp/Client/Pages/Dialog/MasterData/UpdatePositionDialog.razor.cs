using HrisApp.Client.Pages.MasterData;
using HrisApp.Shared.Models.MasterData;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdatePositionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }


        private PositionT position = null;


        void Cancel() => MudDialog.Cancel();


        protected override async Task OnParametersSetAsync()
        {
            position = PositionService.PositionTs.Find(d => d.Id == Id);
        }

        async Task UpdateArea()
        {
            if (position == null)
                return;

            MudDialog.Close();

            var confirmResult = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmation",
                Text = "Are you sure you want to update the " + position.Name + "?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"
            });

            if (confirmResult.IsConfirmed)
            {
                await PositionService.UpdatePosition(position);
                await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "PositionT", $"PositionId: {position.Id} updated successfully.", JsonConvert.SerializeObject(position), DateTime.Now);

                _toastService.ShowSuccess(position.Name + " Updated Successfully!");
                await Task.Delay(1000);

                await jsRuntime.InvokeVoidAsync("location.reload");
                navigationManager.NavigateTo("/position");
            }
        }
    }
}
