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
