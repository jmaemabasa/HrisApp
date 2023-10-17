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
                newSection = "Not Applicable";
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

                    newSection = "";
                    
                    Snackbar.Add(newSection + " Created Successfully!", Severity.Success);
                    await Task.Delay(1000);

                    await jsRuntime.InvokeVoidAsync("location.reload");
                    navigationManager.NavigateTo("/section");
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

                    newSection = "";

                    Snackbar.Add(newSection + " Created Successfully!", Severity.Success);
                    await Task.Delay(1000);

                    await jsRuntime.InvokeVoidAsync("location.reload");
                    navigationManager.NavigateTo("/");
                }
            }
        }
    }
}
