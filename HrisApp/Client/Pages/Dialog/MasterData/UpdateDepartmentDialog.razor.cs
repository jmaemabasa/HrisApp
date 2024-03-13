namespace HrisApp.Client.Pages.Dialog.MasterData
{
#nullable disable

    public partial class UpdateDepartmentDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public int Id { get; set; }

        private DepartmentT department = new();

        private void Cancel() => MudDialog.Cancel();

        protected override async Task OnParametersSetAsync()
        {
            department = await DepartmentService.GetSingleDepartment(Id);
        }

        private async Task UpdateArea()
        {
            if (department == null)
                return;

            if (string.IsNullOrWhiteSpace(department.Name))
            {
                GlobalConfigService.OpenWarningDialog("Please enter a valid department.");
            }
            else
            {
                MudDialog.Close();

                var confirmResult = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Confirmation",
                    Text = "Are you sure you want to update the " + department.Name + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    await DepartmentService.UpdateDepartment(department);
                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                    _toastService.ShowSuccess(department.Name + " Updated Successfully!");

                    await DepartmentService.GetDepartment();
                    var newList = DepartmentService.DepartmentTs;
                    StateService.SetState("DepartmentList", newList);
                }
            }
        }
    }
}