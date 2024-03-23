namespace HrisApp.Client.Pages.Dialog.MasterData
{
#nullable disable

    public partial class AddSubPositionDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        private int selectedPos = 0;
        private int selectedDivision = 0;
        private int selectedDepartment = 0;
        private int selectedSection = 0;
        private int selectedArea = 0;

        private string selecteReportToHolder = "Null";
        private string selecteReportTo;

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

            selecteReportTo = selecteReportToHolder;
        }

        private void Cancel() => MudDialog.Cancel();

        private async Task ConfirmCreatePositionAsync()
        {
            if (selectedDivision == 0)
            {
                GlobalConfigService.OpenWarningDialog("Please select a division.");
            }
            else if (selectedDepartment == 0)
            {
                GlobalConfigService.OpenWarningDialog("Please select a department.");
            }
            else if (selectedPos == 0)
            {
                GlobalConfigService.OpenWarningDialog("Please select a position.");
            }
            else
            {
                MudDialog.Close();
                if (selecteReportTo == "Null")
                    selecteReportTo = "";
                await PositionService.CreateSubPosition(Roles_Code, PosCode, Roles_Desc, "Inactive", selectedDivision, selectedDepartment, selectedSection, selectedArea, selecteReportTo);

                _toastService.ShowSuccess(Roles_Code + " Created Successfully!");
                if (!string.IsNullOrEmpty(GlobalConfigService.Role))
                {
                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
                }
                await PositionService.GetSubPosition();
                var newList = PositionService.SubPositionTs;
                StateService.SetState("SubPositionList", newList);
            }
        }

        private string Roles_Code = "";
        private string Roles_Desc = "";
        private string PosCode = "";

        private async Task OnGenerateCode()
        {
            string _rolesCode = string.Empty;
            var selectedposcode = Positions.Where(x => x.Id == selectedPos).Select(x => x.PosCode).FirstOrDefault();
            int _existCount = await PositionService.GetExistingSubPos(selectedposcode);
            var _rolesubcode = selectedposcode = Positions.Where(x => x.Id == selectedPos).Select(x => x.PosCode).FirstOrDefault();
            Roles_Code = Convert.ToString(_existCount);
            Roles_Desc = Positions.Where(x => x.Id == selectedPos).Select(x => x.Name).FirstOrDefault();
            PosCode = selectedposcode;
            selectedArea = Positions.Where(x => x.Id == selectedPos).Select(x => x.AreaId).FirstOrDefault();
            var _countLenght = _existCount.ToString().Length;

            if (_existCount.Equals(0))
            {
                var ifCounts = _existCount + 1;
                _rolesCode = $"{_rolesubcode}00{ifCounts}";
            }
            else
            {
                switch (_countLenght)
                {
                    default:
                        var _countDefault = _existCount + 1;
                        _rolesCode = $"{_rolesubcode}{_countDefault}";
                        break;

                    case 1:
                        var _countOne = _existCount + 1;
                        _rolesCode = $"{_rolesubcode}00{_countOne}";
                        break;

                    case 2:
                        var _countTwo = _existCount + 1;
                        _rolesCode = $"{_rolesubcode}0{_countTwo}";
                        break;
                }
            }

            Roles_Code = _rolesCode;
        }

        private async Task PosChange(int id)
        {
            await Task.Delay(10);
            selectedPos = id;
            await OnGenerateCode();
        }
    }
}