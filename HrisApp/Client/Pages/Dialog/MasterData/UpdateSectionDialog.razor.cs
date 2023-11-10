using HrisApp.Client.Pages.MasterData;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateSectionDialog : ComponentBase
    {

#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }


        private SectionT section = null;


        void Cancel() => MudDialog.Cancel();


        protected override async Task OnParametersSetAsync()
        {
            section = SectionService.SectionTs.Find(d => d.Id == Id);
        }

        async Task UpdateArea()
        {
            if (section == null)
                return;

            MudDialog.Close();

            var confirmResult = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmation",
                Text = "Are you sure you want to update the " + section.Name + "?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"
            });

            if (confirmResult.IsConfirmed)
            {
                await SectionService.UpdateSection(section);

                await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "SectionT", $"SectionId: {section.Id} updated successfully.", JsonConvert.SerializeObject(section), DateTime.Now);
                _toastService.ShowSuccess(section.Name + " Updated Successfully!");
                await Task.Delay(1000);

                await jsRuntime.InvokeVoidAsync("location.reload");
                navigationManager.NavigateTo("/section");
            }
        }
    }
}
