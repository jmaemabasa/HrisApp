using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddDivisionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private string newDivision = "";

        [CascadingParameter]
        private Task<AuthenticationState> authState { get; set; }
        string? userId;

        void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            var auth = await authState;
            userId = auth.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        }

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

                    await AuditLogService.CreateAudit(Int32.Parse(userId), "DivisionT", "Create");

                    await Task.Delay(1000);

                    await jsRuntime.InvokeVoidAsync("location.reload");
                    NavigationManager.NavigateTo("/division");

                }
            }
        }
    }
}
