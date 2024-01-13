namespace HrisApp.Client.Pages.Applicant
{
#nullable disable
    public partial class ApplicantDetails : ComponentBase
    {
        [Parameter]
        public int id { get; set; }
        string VerifyCode;

        #region variables
        ApplicantT employee = new();
        App_AddressT _address = new();
        App_SelfDeclarationT _selfdec = new();

        private List<GenderT> GendersL = new();
        private List<CivilStatusT> CivilStatusL = new();
        private List<ReligionT> ReligionsL = new();
        private List<EmerRelationshipT> EmerRelationshipsL = new();

        #region self dec variables
        public bool YesCB1 { get; set; } = false;
        public bool NoCB1 { get; set; } = false;
        public bool YesCB2 { get; set; } = false;
        public bool NoCB2 { get; set; } = false;
        public bool YesCB3 { get; set; } = false;
        public bool NoCB3 { get; set; } = false;
        public bool YesCB4 { get; set; } = false;
        public bool NoCB4 { get; set; } = false;
        public bool YesCB5 { get; set; } = false;
        public bool NoCB5 { get; set; } = false;
        public bool YesCB6 { get; set; } = false;
        public bool NoCB6 { get; set; } = false;
        public bool YesCB7 { get; set; } = false;
        public bool NoCB7 { get; set; } = false;
        #endregion
        #endregion

        protected override async Task OnInitializedAsync()
        {
            await StaticService.GetGenderList();
            GendersL = StaticService.GenderTs;
            await StaticService.GetCivilStatusList();
            CivilStatusL = StaticService.CivilStatusTs;
            await StaticService.GetReligionList();
            ReligionsL = StaticService.ReligionTs;
            await StaticService.GetEmerRelationshipList();
            EmerRelationshipsL = StaticService.EmerRelationshipTs;
        }

        protected override async Task OnParametersSetAsync()
        {
            employee = await AppService.GetSingleApplicant(id);
            _address = await AppAddressService.GetSingleAddress(id);
            _selfdec = await AppLicenseTrainingService.GetSingleSelfDeclaration(id);

            YesCB1 = _selfdec.Q1Ans == "true";
            NoCB1 = !YesCB1;
            YesCB2 = _selfdec.Q2Ans == "true";
            NoCB2 = !YesCB1;
            YesCB3 = _selfdec.Q3Ans == "true";
            NoCB3 = !YesCB1;
            YesCB4 = _selfdec.Q4Ans == "true";
            NoCB4 = !YesCB1;
            YesCB5 = _selfdec.Q5Ans == "true";
            NoCB5 = !YesCB1;
            YesCB6 = _selfdec.Q6Ans == "true";
            NoCB6 = !YesCB1;
            YesCB7 = _selfdec.Q7Ans == "true";
            NoCB7 = !YesCB1;




            VerifyCode = employee.App_VerifyId;
        }

        #region TAB CLASS
        //TAB PANEL
        MudTabs tabs;
        private string slectClasss = "frmselect";
        int activeIndex;

        RenderFragment tabHeader(int tabId)
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
                    builder.AddContent(6, "Personal Data");
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
            };
        }

        string GetTabChipClass(int tabId)
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

        string GetTabTextClass(int tabId)
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
        #endregion
    }
}
