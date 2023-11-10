using HrisApp.Client.Pages.MasterData;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateDepartmentDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }


        private DepartmentT department = null;


        void Cancel() => MudDialog.Cancel();


        protected override async Task OnParametersSetAsync()
        {
            department = DepartmentService.DepartmentTs.Find(d => d.Id == Id);
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
                await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "DepartmentT", $"DepartmentId: {department.Id} updated successfully.", JsonConvert.SerializeObject(department), DateTime.Now);

                _toastService.ShowSuccess(department.Name + " Updated Successfully!");
                await Task.Delay(1000);

                await jsRuntime.InvokeVoidAsync("location.reload");
                navigationManager.NavigateTo("/department");
            }
        }
    }
}
