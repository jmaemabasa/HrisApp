using Microsoft.JSInterop;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddSectionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private List<DepartmentT> Department = new();
        private List<DivisionT> Division = new();
        private bool notApplicableChecked = false;
        private int selectedDivision;
        private int selectedDepartment;
        private string newSection = "";

        void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            await DivisionService.GetDivision();
            Division = DivisionService.DivisionTs;

            await DepartmentService.GetDepartment();
            Department = DepartmentService.DepartmentTs;
        }

        private async Task ConfirmCreateSectionAsync()
        {
            if (notApplicableChecked)
            {
                newSection = "No Section";
            }
            if (notApplicableChecked)
            {
                MudDialog.Close();
                var result = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Are you sure this department has no section?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (result.IsConfirmed)
                {
                    await SectionService.CreateSection(newSection, selectedDivision, selectedDepartment);

                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                    _toastService.ShowSuccess(newSection + " Created Successfully!");

                    await SectionService.GetSection();
                    var newList = SectionService.SectionTs;
                    StateService.SetState("SectionList", newList);
                }
            }
            else if (string.IsNullOrWhiteSpace(newSection))
            {
                //await ShowErrorMessageBox("Please enter a valid section!");
                GlobalConfigService.OpenWarningDialog("Please enter a valid section.");
            }
            else
            {
                MudDialog.Close();
                var result = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Do you want to create " + newSection + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (result.IsConfirmed)
                {
                    await SectionService.CreateSection(newSection, selectedDivision, selectedDepartment);

                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                    _toastService.ShowSuccess(newSection + " Created Successfully!");

                    await SectionService.GetSection();
                    var newList = SectionService.SectionTs;
                    StateService.SetState("SectionList", newList);
                }
            }
        }
        private async Task ShowErrorMessageBox(string mess)
        {
            bool? result = await _dialogService.ShowMessageBox(
            "Warning",
            mess,
            yesText: "Ok");
        }
    }
}
