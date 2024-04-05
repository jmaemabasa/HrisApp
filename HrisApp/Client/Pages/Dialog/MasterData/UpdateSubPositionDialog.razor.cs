namespace HrisApp.Client.Pages.Dialog.MasterData
{
#nullable disable

    public partial class UpdateSubPositionDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public int Id { get; set; }

        private SubPositionT obj = new();

        private string selecteReportToHolder = "Null";

        private List<DepartmentT> Department = new();
        private List<DivisionT> Division = new();
        private List<SectionT> Sections = new();
        private List<PositionT> Positions = new();
        private List<SubPositionT> SubPositions = new();

        protected override async Task OnInitializedAsync()
        {
            await DivisionService.GetDivision();
            Division = DivisionService.DivisionTs;

            await DepartmentService.GetDepartment();
            Department = DepartmentService.DepartmentTs;

            await SectionService.GetSection();
            Sections = SectionService.SectionTs;

            await PositionService.GetPosition();
            Positions = PositionService.PositionTs;

            await PositionService.GetSubPosition();
            SubPositions = PositionService.SubPositionTs;
        }

        protected override async Task OnParametersSetAsync()
        {
            obj = await PositionService.GetSingleSubPosition(Id);

            if (string.IsNullOrEmpty(obj.ReportingTo))
                obj.ReportingTo = selecteReportToHolder;
        }

        private void Cancel() => MudDialog.Cancel();

        private async Task UpdateObj()
        {
            if (obj.ReportingTo == "Null")
                obj.ReportingTo = "";

            if (obj.Status.Equals("Inactive"))
            {
                obj.DateInactive = DateTime.Now;
            }

            await PositionService.UpdateSubPosition(obj);

            Cancel();
            _toastService.ShowSuccess("Updated Successfully!");
            if (!string.IsNullOrEmpty(GlobalConfigService.Role))
                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

            await PositionService.GetSubPosition();
            var newList = PositionService.SubPositionTs;
            StateService.SetState("SubPositionList", newList);
        }

        private async Task DeletePosition()
        {
            var pos = PositionService.SubPositionTs.Where(x => x.Id == Id);
            foreach (var item in pos)
            {
                if (item.Status == "Active")
                {
                    GlobalConfigService.OpenErrorDialog("The action can't be completed because it has an active reference!");
                }
                else if (item.Status == "Inactive" && item.Emp_VerifyId != "")
                {
                    GlobalConfigService.OpenErrorDialog("The action can't be completed because it has an active reference!");
                }
                else if (item.Status == "Vacant" && item.Emp_VerifyId != "")
                {
                    GlobalConfigService.OpenErrorDialog("The action can't be completed because it has an active reference!");
                }
                else
                {
                    var confirmResult = await Swal.FireAsync(new SweetAlertOptions
                    {
                        Title = "Confirmation",
                        Text = "Pernamently delete this? You can't undo the action.",
                        Icon = SweetAlertIcon.Question,
                        ShowCancelButton = true,
                        ConfirmButtonText = "Yes",
                        CancelButtonText = "No"
                    });

                    if (confirmResult.IsConfirmed)
                    {
                        await PositionService.DeleteSubPosition(Id);
                        Cancel();

                        await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
                        await PositionService.GetSubPosition();
                        var newList = PositionService.SubPositionTs;
                        StateService.SetState("SubPositionList", newList);
                        _toastService.ShowSuccess("Deleted Successfully!");
                    }
                }
            }
        }
    }
}