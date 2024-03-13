namespace HrisApp.Client.Pages.Dialog.MasterData
{
#nullable disable

    public partial class UpdateSectionDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SectionT section = new();

        private void Cancel() => MudDialog.Cancel();

        protected override async Task OnParametersSetAsync()
        {
            section = await SectionService.GetSingleSection(Id);
        }

        private async Task UpdateArea()
        {
            if (section == null)
                return;

            if (string.IsNullOrWhiteSpace(section.Name))
            {
                //await ShowErrorMessageBox("Please fill up the section name!");
                GlobalConfigService.OpenWarningDialog("Please fill up the section name.");
            }
            else
            {
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

                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);
                    _toastService.ShowSuccess(section.Name + " Updated Successfully!");

                    await SectionService.GetSection();
                    var newList = SectionService.SectionTs;
                    StateService.SetState("SectionList", newList);
                }
            }
        }
    }
}