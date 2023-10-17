using Microsoft.JSInterop;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddPositionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        private List<DepartmentT> Department = new List<DepartmentT>();
        private List<DivisionT> Division = new List<DivisionT>();
        private List<SectionT> Sections = new List<SectionT>();

        private int selectedDivision;
        private int selectedDepartment;
        private int selectedSection;
        private string newPosition = "";

        void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            await DivisionService.GetDivision();
            Division = DivisionService.DivisionTs;

            await DepartmentService.GetDepartment();
            Department = DepartmentService.DepartmentTs;

            await SectionService.GetSection();
            Sections = SectionService.SectionTs;
        }

        private async Task ConfirmCreatePositionAsync()
        {
            MudDialog.Close();

            if (string.IsNullOrWhiteSpace(newPosition))
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Warning",
                    Text = "Please enter a valid position!",
                    Icon = SweetAlertIcon.Warning
                });
            }
            else
            {
                var result = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Do you want to create " + newPosition + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (result.IsConfirmed)
                {
                    await CreatePositionPerDepOrSect();
                }
            }
        }

        private async Task CreatePositionPerDepOrSect()
        {
            var divisionId = selectedDivision;
            var departmentId = selectedDepartment;
            var sectionId = selectedSection;
            var positionName = newPosition;

            // Check if the selected department has sections
            var departmentHasSections = Sections.Any(s => s.DepartmentId == selectedDepartment);

            if (departmentHasSections)
            {
                // Create a position in the section
                await PositionService.CreatePositionPerSection(positionName, divisionId, departmentId, sectionId);
            }
            else
            {
                // Create a position in the department
                await PositionService.CreatePositionPerDept(positionName, divisionId, departmentId);
            }

            newPosition = "";

            Snackbar.Add(positionName + " Created Successfully!", Severity.Success);
            await Task.Delay(1000);

            await jsRuntime.InvokeVoidAsync("location.reload");
            navigationManager.NavigateTo("/position");
        }
    }
}
