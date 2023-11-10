using HrisApp.Client.Pages.MasterData;
using HrisApp.Shared.Models.MasterData;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateDivisionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }


        private DivisionT division = null;


        void Cancel() => MudDialog.Cancel();


        protected override async Task OnParametersSetAsync()
        {
            division = DivisionService.DivisionTs.Find(d => d.Id == Id);
        }

        async Task UpdateArea()
        {
            if (division == null)
                return;

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
                await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "DivisionT", $"DivisionId: {division.Id} updated successfully.", JsonConvert.SerializeObject(division), DateTime.Now);

                _toastService.ShowSuccess(division.Name + " Updated Successfully!");
                await Task.Delay(1000);

                await jsRuntime.InvokeVoidAsync("location.reload");
                navigationManager.NavigateTo("/division");
                
            }
        }
    }
}
