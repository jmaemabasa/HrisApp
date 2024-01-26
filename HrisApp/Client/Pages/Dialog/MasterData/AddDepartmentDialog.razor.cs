namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddDepartmentDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private readonly Dictionary<string, List<DepartmentT>> Department = new();
        private List<DivisionT> Division = new();
        private int selectedDivision;
        private string newDepartment = "";

        void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            await DivisionService.GetDivision();
            Division = DivisionService.DivisionTs;
        }

        public async Task ConfirmCreateDepartment()
        {
            if (string.IsNullOrWhiteSpace(newDepartment))
            {
                //await ShowErrorMessageBox("Please enter a valid department!");
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
        private async Task ShowErrorMessageBox(string mess)
        {
            bool? result = await _dialogService.ShowMessageBox(
            "Warning",
            mess,
            yesText: "Ok");
        }
    }
}
