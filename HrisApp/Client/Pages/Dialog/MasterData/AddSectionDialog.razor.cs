using Microsoft.JSInterop;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddSectionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private List<DepartmentT> Department = new List<DepartmentT>();
        private List<DivisionT> Division = new List<DivisionT>();
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
            MudDialog.Close();
            if (notApplicableChecked)
            {
                newSection = "No Section";
            }
            if (notApplicableChecked)
            {
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

                    await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "SectionT", $"Section: {newSection}, Department: {selectedDepartment} created successfully.", "_", DateTime.Now);

                    _toastService.ShowSuccess(newSection + " Created Successfully!");

                    await SectionService.GetSection();
                    var newList = SectionService.SectionTs;
                    StateService.SetState("SectionList", newList);
                }
            }
            else if (string.IsNullOrWhiteSpace(newSection))
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Warning",
                    Text = "Please enter a valid section!",
                    Icon = SweetAlertIcon.Warning
                });
            }
            else
            {
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

                    await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "SectionT", $"Section: {newSection}, Department: {selectedDepartment} created successfully.", "_", DateTime.Now);

                    _toastService.ShowSuccess(newSection + " Created Successfully!");

                    await SectionService.GetSection();
                    var newList = SectionService.SectionTs;
                    StateService.SetState("SectionList", newList);
                }
            }
        }
    }
}
