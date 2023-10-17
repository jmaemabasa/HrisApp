using Microsoft.JSInterop;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddDepartmentDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private Dictionary<string, List<DepartmentT>> Department = new Dictionary<string, List<DepartmentT>>();
        private List<DivisionT> Division = new List<DivisionT>();
        private int selectedDivision;
        private string newDepartment = "";

        void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            await DivisionService.GetDivision();
            Division = DivisionService.DivisionTs;
        }

        private async Task ConfirmCreateDepartment()
        {
            MudDialog.Close();
            if (string.IsNullOrWhiteSpace(newDepartment))
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Warning",
                    Text = "Please enter a valid department!",
                    Icon = SweetAlertIcon.Warning
                });
            }
            else
            {
                var result = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Do you want to create " + newDepartment + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (result.IsConfirmed)
                {
                    await DepartmentService.CreateDepartment(newDepartment, selectedDivision);
                    newDepartment = "";

                    Snackbar.Add(newDepartment + " Created Successfully!", Severity.Success);
                    await Task.Delay(1000);

                    await jsRuntime.InvokeVoidAsync("location.reload");
                    NavigationManager.NavigateTo("/department");


                }
            }
        }
    }
}
