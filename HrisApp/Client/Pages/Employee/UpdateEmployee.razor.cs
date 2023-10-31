using System;

namespace HrisApp.Client.Pages.Employee
{
    public partial class UpdateEmployee : ComponentBase
    {
#nullable disable
        [Parameter]
        public int? id { get; set; }

        #region TABLE VARIABLES
        EmployeeT employee = new();
        AddressT _address = new();
        TrainingT _trainings = new();
        PayrollT _payroll = new();
        PrimaryT _pri = new();
        SecondaryT _sec = new();
        SeniorHST _shs = new();
        CollegeT _coll = new();
        MasteralT _mas = new();
        DoctorateT _doc = new();
        OtherEducT _others = new();
        LicenseT _license = new();
        DocumentT _pdf = new();
        EmpPictureT _img = new();
        #endregion

        #region LIST TABLE VARIABLES
        //FK
        private List<AreaT> AreasL = new List<AreaT>();
        private List<StatusT> StatusL = new List<StatusT>();
        private List<EmploymentStatusT> EmploymentStatusL = new List<EmploymentStatusT>();

        private List<DivisionT> DivisionsL = new List<DivisionT>();
        private List<DepartmentT> DepartmentsL = new List<DepartmentT>();
        private List<SectionT> SectionsL = new List<SectionT>();
        private List<PositionT> PositionsL = new List<PositionT>();

        private List<GenderT> GendersL = new List<GenderT>();
        private List<CivilStatusT> CivilStatusL = new List<CivilStatusT>();
        private List<ReligionT> ReligionsL = new List<ReligionT>();
        private List<EmerRelationshipT> EmerRelationshipsL = new List<EmerRelationshipT>();

        //PAYROLL
        private List<CashBondT> CashbondL = new List<CashBondT>();
        private List<ScheduleTypeT> ScheduleTypeL = new List<ScheduleTypeT>();
        private List<RateTypeT> RateTypeL = new List<RateTypeT>();
        private List<RestDayT> RestDayL = new List<RestDayT>();

        private List<DocumentT> pdffile = new List<DocumentT>();

        List<PrimaryT> listOfPrimary = new List<PrimaryT>();
        List<SecondaryT> listOfSecondary = new List<SecondaryT>();
        List<SeniorHST> listOfShs = new List<SeniorHST>();
        List<CollegeT> listOfCollege = new List<CollegeT>();
        List<MasteralT> listOfMasteral = new List<MasteralT>();
        List<DoctorateT> listOfDoctorate = new List<DoctorateT>();
        List<OtherEducT> listOfOthers = new List<OtherEducT>();
        List<LicenseT> listofLicense = new List<LicenseT>();
        List<TrainingT> listOfTrainings = new List<TrainingT>();

        private bool IsListaddshs;
        private bool IsListaddcoll;
        private bool IsListaddmas;
        private bool IsListaddothers;
        private bool IsListadddoc;
        #endregion

        #region DATES VARIBALE
        private DateTime? bday { get; set; } 
        private DateTime? Date = DateTime.Today;
        private DateTime? ResignationDate = DateTime.Today;
        private DateTime? ProbStart = DateTime.Today;
        private DateTime? ProbEnd = DateTime.Today;
        private DateTime? CasualStart = DateTime.Today;
        private DateTime? CasualEnd = DateTime.Today;
        private DateTime? FixedStart = DateTime.Today;
        private DateTime? FixedEnd = DateTime.Today;
        private DateTime? ProjStart = DateTime.Today;
        private DateTime? ProjEnd = DateTime.Today;
        private DateTime? DateHired = DateTime.Today;
        private DateTime? RegularDate = DateTime.Today;
        #endregion 

        #region DRAWER VARIBALES AND FUNCTIONS
        bool personalandjobOpen;
        bool workInfoOpen;
        bool emerOpen;
        bool addressOpen;
        bool documentsOpen;
        bool PersonOpen;
        bool DocuOpen;
        bool ScheduleOpen;
        bool StatutoryOpen;
        bool RateOpen;
        Anchor anchor;
        string width = "500px", height = "100%";

        void OpenDrawer(Anchor anchor, string drawerx)
        {
            personalandjobOpen = (drawerx == "personalandjobOpen") ? true : false;
            workInfoOpen = (drawerx == "workInfoOpen") ? true : false;
            emerOpen = (drawerx == "emerOpen") ? true : false;
            addressOpen = (drawerx == "addressOpen") ? true : false;
            documentsOpen = (drawerx == "documentsOpen") ? true : false;
            StatutoryOpen = (drawerx == "StatutoryOpen") ? true : false;
            this.anchor = anchor;
        }
        #endregion

        string VerifyCode;

        private string ImageData;
        private List<string> PDFDataList = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            await AreaService.GetAreaList();
            AreasL = AreaService.AreaTs;
            await EmployeeService.GetStatusList();
            StatusL = EmployeeService.StatusTs;
            await EmployeeService.GetEmploymentStatusList();
            EmploymentStatusL = EmployeeService.EmploymentStatusTs;
            await DivisionService.GetDivision();
            DivisionsL = DivisionService.DivisionTs;
            await DepartmentService.GetDepartment();
            DepartmentsL = DepartmentService.DepartmentTs;
            await SectionService.GetSection();
            SectionsL = SectionService.SectionTs;
            await PositionService.GetPosition();
            PositionsL = PositionService.PositionTs;
            await EmployeeService.GetGenderList();
            GendersL = EmployeeService.GenderTs;
            await EmployeeService.GetCivilStatusList();
            CivilStatusL = EmployeeService.CivilStatusTs;
            await EmployeeService.GetReligionList();
            ReligionsL = EmployeeService.ReligionTs;
            await EmployeeService.GetEmerRelationshipList();
            EmerRelationshipsL = EmployeeService.EmerRelationshipTs;
            await PayrollService.GetRateType();
            RateTypeL = PayrollService.RateTypeTs;
            await PayrollService.GetScheduleType();
            ScheduleTypeL = PayrollService.ScheduleTypeTs;
            await PayrollService.GetCashbond();
            CashbondL = PayrollService.CashBondTs;
            await PayrollService.GetRestDay();
            RestDayL = PayrollService.RestDayTs;
        }

        protected override async Task OnParametersSetAsync()
        {
            employee = await EmployeeService.GetSingleEmployee((int)id);
            _address = await AddressService.GetSingleAddress((int)id);
            _payroll = await PayrollService.GetSinglePayroll((int)id);

            

            VerifyCode = employee.Verify_Id;
            await EmployeeImg(employee.Verify_Id);//image

            bday = employee.Birthdate;
            DateHired = employee.DateHired;
    }
        
        protected async Task SaveUpdateEmployee() 
        {
            if (bday.HasValue)
            {
                DateTime currentDate = DateTime.Today;
                int age = currentDate.Year - bday.Value.Year;

                if (bday.Value > currentDate.AddYears(-age))
                    age--;

                employee.Age = age;
            }

            employee.Birthdate = Convert.ToDateTime(bday);

            await EmployeeService.UpdateEmployee(employee);
            await AddressService.UpdateAddress(_address);
            await PayrollService.UpdatePayroll(_payroll);

            NavigationManager.NavigateTo($"employee/edit/{employee.Id}", true);
        }



        #region MUDTABS
        MudTabs tabs;
        private string slectClasss = "frmselect";
        void Activate(int index)
        {
            //tabs.ActivatePanel(index);
            if (index == 1)
            {
                if (employee.AreaId == 0 || employee.StatusId == 0 || employee.EmploymentStatusId == 0 || employee.DivisionId == 0 || employee.DepartmentId == 0 || employee.PositionId == 0)
                {
                    _toastService.ShowError("Fill out all fields.");
                    slectClasss = "frmselecterror";
                }
                else
                {
                    tabs.ActivatePanel(index);
                    slectClasss = "frmselect";
                }
            }
            else if (index == 2)
            {
                tabs.ActivatePanel(index);
            }
            else if (index == 0)
            {
                tabs.ActivatePanel(index);
            }
        }
        void Activate2(int index)
        {
            tabs.ActivatePanel(index);

        }
        #endregion

        #region PERSONAL TAB ERROR TRAP
        private string slectClasssGender = "frmselect";
        private string slectClasssCV = "frmselect";
        private string slectClasssReli = "frmselect";
        private string slectClasssRela = "frmselect";
        private string txfieldClasssNat = "txf1";
        private string txfieldClasssMN = "txf";
        private string txfieldClasssEN = "txf1";
        private string txfieldClasssEA = "txf1";
        private string txfieldClasssEMN = "txf";

        private async void ActivateAddressField()
        {
            slectClasssGender = (employee.GenderId == 0) ? "frmselecterror" : "frmselect";
            slectClasssCV = (employee.CivilStatusId == 0) ? "frmselecterror" : "frmselect";
            slectClasssReli = (employee.ReligionId == 0) ? "frmselecterror" : "frmselect";
            slectClasssRela = (employee.EmerRelationshipId == 0) ? "frmselecterror" : "frmselect";
            txfieldClasssNat = (String.IsNullOrWhiteSpace(employee.Nationality)) ? "txf1error" : "txf1";
            txfieldClasssMN = (String.IsNullOrWhiteSpace(employee.MobileNumber)) ? "txf1error" : "txf";
            txfieldClasssEN = (String.IsNullOrWhiteSpace(employee.EmerName)) ? "txf1error" : "txf1";
            txfieldClasssEA = (String.IsNullOrWhiteSpace(employee.EmerAddress)) ? "txf1error" : "txf1";
            txfieldClasssEMN = (String.IsNullOrWhiteSpace(employee.EmerMobNum)) ? "txf1error" : "txf";

            if (employee.GenderId == 0 || employee.CivilStatusId == 0 || employee.ReligionId == 0 || employee.EmerRelationshipId == 0 || String.IsNullOrWhiteSpace(employee.Nationality))
            {
                _toastService.ShowError("Fill out all fields.");
            }
            else
            {
                await JSRuntime.InvokeVoidAsync("scrollToDiv");
            }
        }
        #endregion

        #region TAB CLASS
        //TAB PANEL
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
                    builder.AddContent(6, "Personal and Job Data");
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
                    builder.AddContent(6, "Emergency and Address Data");
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
                    builder.AddContent(6, "Licences & Training");
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
                    builder.AddContent(6, "Documents");
                    builder.CloseComponent();
                }
            };
        }

        string GetTabChipClass(int tabId)
        {
            if (activeIndex > tabId)
            {
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

        #region FUNCTIONS / BUTTONS
        private void CopyToClipboard(string text)
        {
            JSRuntime.InvokeVoidAsync("copyToClipboard", text);
        }



        private string FUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input.Substring(1);
        }

        private string StatusChipColor(string status)
        {
            switch (status)
            {
                case "Active":
                    return "statusActiveChip";
                case "Awol":
                    return "statusAwolChip";
                case "Inactive":
                    return "statusInactiveChip";
                case "Resigned":
                    return "statusResignedChip";
                case "Terminated":
                    return "statusTerminatedChip";
                case "Retired":
                    return "statusRetiredChip";
                default:
                    return "statusRetiredChip";
            }
        }

        private async Task EmployeeImg(string verifyCode)
        {
            var imagemodel = await ImageService.GetImageData(verifyCode);
            if (imagemodel != null)
            {
                var base642 = Convert.ToBase64String(imagemodel);
                ImageData = string.Format("data:image/png;base64,{0}", base642);
                Console.WriteLine($"2nd Test: {verifyCode}");
            }
        }
        private void HandleDateHiredChanged(DateTime? newDate)
        {
            DateHired = newDate;
            Console.WriteLine(DateHired.ToString());
            if (DateHired.HasValue)
            {
                // Calculate the regularization date, which is 6 months after the DateHired.

                switch (employee.EmploymentStatusId)
                {
                    case 1:
                        RegularDate = DateHired.Value.AddMonths(6);
                        break;

                    case 2:
                        ProbStart = newDate;
                        ProbEnd = ProbStart.Value.AddMonths(3);
                        Console.WriteLine(ProbStart.ToString());
                        break;
                }
            }
            else
            {
                // If DateHired is not set, clear RegularDate.
                RegularDate = null;
            }
        }
        private string CalculateAge(DateTime? selectedDate)
        {
            if (selectedDate.HasValue)
            {
                DateTime currentDate = DateTime.Today;
                int age = currentDate.Year - selectedDate.Value.Year;

                if (selectedDate.Value > currentDate.AddYears(-age))
                    age--;

                return age.ToString();
            }

            return string.Empty;
        }
        bool success;
        private void OnValidSubmit(EditContext context)
        {
            success = true;
            StateHasChanged();
        }


        void backbtn()
        {
            NavigationManager.NavigateTo("/employee");
        }
        #endregion

    }
}
