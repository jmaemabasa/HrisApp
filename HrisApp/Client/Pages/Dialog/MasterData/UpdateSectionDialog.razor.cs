using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateSectionDialog : ComponentBase
    {

#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }


        private SectionT section = new();


        void Cancel() => MudDialog.Cancel();


        protected override async Task OnParametersSetAsync()
        {
            section = await SectionService.GetSingleSection(Id);
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

                await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "UPDATE Section", DateTime.Now);
                _toastService.ShowSuccess(section.Name + " Updated Successfully!");

                await SectionService.GetSection();
                var newList = SectionService.SectionTs;
                StateService.SetState("SectionList", newList);
            }
        }
    }
}
