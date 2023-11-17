using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateDepartmentDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }


        private DepartmentT department = new();


        void Cancel() => MudDialog.Cancel();


        protected override async Task OnParametersSetAsync()
        {
            department = await DepartmentService.GetSingleDepartment(Id);
        }

        async Task UpdateArea()
        {
            if (department == null)
                return;

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
