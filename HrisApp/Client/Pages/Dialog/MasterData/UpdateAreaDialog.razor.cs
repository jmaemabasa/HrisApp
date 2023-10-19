using Microsoft.JSInterop;

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

                _toastService.ShowSuccess(area.Name + " Created Successfully!");
                await Task.Delay(1000);

                await jsRuntime.InvokeVoidAsync("location.reload");
                navigationManager.NavigateTo("/area");

            }
        }
    }
}
