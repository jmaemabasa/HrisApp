﻿namespace HrisApp.Client.Pages.Dialog.MasterData
{
#nullable disable

    public partial class AddDepartmentDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        private List<DivisionT> Division = new();
        private int selectedDivision;
        private string newDepartment = "";

        private void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            await DivisionService.GetDivision();
            Division = DivisionService.DivisionTs;
        }

        public async Task ConfirmCreateDepartment()
        {
            if (string.IsNullOrWhiteSpace(newDepartment))
            {
                GlobalConfigService.OpenWarningDialog("Please enter a valid department.");
            }
            else
            {
                MudDialog.Close();
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

                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                    _toastService.ShowSuccess(newDepartment + " Created Successfully!");

                    await DepartmentService.GetDepartment();
                    var newList = DepartmentService.DepartmentTs;
                    StateService.SetState("DepartmentList", newList);
                }
            }
        }
    }
}