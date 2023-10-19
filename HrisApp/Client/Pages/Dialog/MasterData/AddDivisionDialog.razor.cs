using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

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
            MudDialog.Close();

            if (string.IsNullOrWhiteSpace(newDivision))
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Warning",
                    Text = "Please fill up the division name!",
                    Icon = SweetAlertIcon.Warning
                });
            }
            else
            {
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
                    newDivision = "";

                    _toastService.ShowSuccess(newDivision + " Created Successfully!");

                    await Task.Delay(1000);

                    await jsRuntime.InvokeVoidAsync("location.reload");
                    NavigationManager.NavigateTo("/division");

                }
            }
        }
    }
}
