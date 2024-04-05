namespace HrisApp.Client.Pages.Employee
{
#nullable disable

    public partial class TechnicalEmployeeDetails : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        #region TABLE VARIABLES

        private EmployeeT employee = new();
        private PositionT _position = new();
        private SubPositionT _subposition = new();
        private SubPositionT _newsubposition = new();

        #endregion TABLE VARIABLES

        private List<SubPositionT> SubPositionsL = new();

        private string ImageData { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await PositionService.GetSubPosition();
            SubPositionsL = PositionService.SubPositionTs;
        }

        protected override async Task OnParametersSetAsync()
        {
            employee = await EmployeeService.GetSingleEmployee(Id);
            _subposition = await PositionService.GetSingleSubPosition(employee.PositionId);
            _position = await PositionService.GetSinglePositionByCode(_subposition.PosCode);

            await ImageService.GetNewPDF(employee.Verify_Id, employee.EmployeeNo);

            try
            {
                await EmployeeImg(employee.Verify_Id);//image
            }
            catch (Exception)
            {
                if (employee.GenderId == 1)
                {
                    ImageData = string.Format("images/avatarmaleholder.jpg");
                }
                else
                {
                    ImageData = string.Format("images/avatarfemaleholder.jpg");
                }
            }
        }

        #region MUDTABS

        private MudTabs tabs;
        private string slectClasss = "frmselect";

        #endregion MUDTABS

        #region TAB CLASS

        //TAB PANEL
        private int activeIndex;

        private RenderFragment TabHeader(int tabId)
        {
            return builder =>
            {
                if (tabId == 0)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(0));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(0));
                    builder.AddContent(6, "Assets");
                    builder.CloseComponent();
                }
                else if (tabId == 1)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(1));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(1));
                    builder.AddContent(6, "Work Data");
                    builder.CloseComponent();
                }
                else if (tabId == 2)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(2));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(2));
                    builder.AddContent(6, "Education");
                    builder.CloseComponent();
                }
                else if (tabId == 3)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(3));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(3));
                    builder.AddContent(6, "Professional Background");
                    builder.CloseComponent();
                }
                else if (tabId == 4)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(4));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(4));
                    builder.AddContent(6, "Attachment");
                    builder.CloseComponent();
                }
                else if (tabId == 5)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(5));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(5));
                    builder.AddContent(6, "Attendance");
                    builder.CloseComponent();
                }
                else if (tabId == 6)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(6));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(6));
                    builder.AddContent(6, "Assets");
                    builder.CloseComponent();
                }
            };
        }

        private string GetTabChipClass(int tabId)
        {
            if (activeIndex > tabId)
            {
                if (tabId == 0)
                    return "mud-chip-after0";
                else if (tabId == 1)
                    return "mud-chip-after1";
                else if (tabId == 2)
                    return "mud-chip-after2";
                else if (tabId == 3)
                    return "mud-chip-after3";
                else if (tabId == 4)
                    return "mud-chip-after4";
                else if (tabId == 5)
                    return "mud-chip-after5";
                else
                    return "mud-chip-after";
            }
            else if (activeIndex == tabId)
            {
                return "mud-chip-active";
            }
            else
            {
                return "mud-chip-default";
            }
        }

        private string GetTabTextClass(int tabId)
        {
            if (activeIndex > tabId)
            {
                return "mud-text-after";
            }
            else if (activeIndex == tabId)
            {
                return "mud-text-active";
            }
            else
            {
                return "mud-text-default";
            }
        }

        #endregion TAB CLASS

        #region FUNCTIONS

        private void Backbtn() => NavigationManager.NavigateTo("/employee");

        private static string StatusChipColor(string status)
        {
            return status switch
            {
                "Active" => "statusActiveChip",
                "Awol" => "statusAwolChip",
                "Inactive" => "statusInactiveChip",
                "Resigned" => "statusResignedChip",
                "Terminated" => "statusTerminatedChip",
                "Retired" => "statusRetiredChip",
                _ => "statusRetiredChip",
            };
        }

        private static string StatusAvatarColor(string status)
        {
            return status switch
            {
                "Regular" => "statusRegular",
                "Probationary" => "statusProbationary",
                "Casual" => "statusCasual",
                "Fixed Term" => "statusFixedTerm",
                "Project Based" => "statusProjectBased",
                _ => "",
            };
        }

        private static string StatusTextColor(string status)
        {
            return status switch
            {
                "Regular" => "statusTextRegular",
                "Probationary" => "statusTextProbationary",
                "Casual" => "statusTextCasual",
                "Fixed Term" => "statusTextFixedTerm",
                "Project Based" => "statusTextProjectBased",
                _ => "",
            };
        }

        private async Task EmployeeImg(string verifyCode)
        {
            var imagemodel = await ImageService.GetImageData(verifyCode);
            if (imagemodel != null)
            {
                var base642 = Convert.ToBase64String(imagemodel);
                ImageData = string.Format("data:image/png;base64,{0}", base642);
            }
        }

        #endregion FUNCTIONS
    }
}