using Blazored.Toast.Services;

namespace HrisApp.Client.ViewModel.EmployeeViewModel.EmployeeViewModel
{
    public class AddEmployeeVM : BaseViewModel
    {
#nullable disable
        IEmployeeService EmployeeService = new EmployeeService();
        IEducationService EducationService = new EducationService();
        ILicenseTrainingService LicenseTrainingService = new LicenseTrainingService();
        IAddressService AddressService = new AddressService();
        IPayrollService PayrollService = new PayrollService();
        IEmploymentDateService EmploymentDateService = new EmploymentDateService();
        IImageService ImageService = new ImageService();
        IAuditlogService AuditlogService = new AuditlogService();
        IToastService _toastService = new ToastService();
        IAreaService AreaService = new AreaService();
        IDivisionService DivisionService = new DivisionService();
        IDepartmentService DepartmentService = new DepartmentService();
        ISectionService SectionService = new SectionService();
        IPositionService PositionService = new PositionService();
        IStaticService StaticService = new StaticService();
        IEmpHistoryService EmpHistoryService = new EmpHistoryService();
        IForEvalService ForEvalService = new ForEvalService();

        public SweetAlertService Swal { get; set; }

        private readonly GlobalConfigService GlobalConfigService;
        private readonly NavigationManager _navigationManager;
        public AddEmployeeVM(NavigationManager navigationManager, GlobalConfigService globalConfigService)
        {
            _navigationManager = navigationManager;
            GlobalConfigService = globalConfigService;
        }

        [CascadingParameter]
        public Task<AuthenticationState> authState { get; set; }
        string _sectionnull = string.Empty;

        [Parameter]
        public int? Id { get; set; }

        public EmployeeT employee = new();
        public Emp_AddressT address = new();
        public Emp_EmploymentDateT employmentDate = new();
        public Emp_PayrollT payroll = new();
        public Emp_LicenseT license = new();
        public Emp_PosHistoryT empHistory = new();
        public Emp_EvaluationT empEvaluation = new();

        public async Task OnRefreshPage()
        {
            await AreaService.GetArea();
            AreasL = AreaService.AreaTs;
            await StaticService.GetStatusList();
            StatusL = StaticService.StatusTs;
            await StaticService.GetEmploymentStatusList();
            EmploymentStatusL = StaticService.EmploymentStatusTs;
            await DivisionService.GetDivision();
            DivisionsL = DivisionService.DivisionTs;
            await DepartmentService.GetDepartment();
            DepartmentsL = DepartmentService.DepartmentTs;
            await SectionService.GetSection();
            SectionsL = SectionService.SectionTs;
            await PositionService.GetPosition();
            PositionsL = PositionService.PositionTs;
            await StaticService.GetGenderList();
            GendersL = StaticService.GenderTs;
            await StaticService.GetCivilStatusList();
            CivilStatusL = StaticService.CivilStatusTs;
            await StaticService.GetReligionList();
            ReligionsL = StaticService.ReligionTs;
            await StaticService.GetEmerRelationshipList();
            EmerRelationshipsL = StaticService.EmerRelationshipTs;
            await StaticService.GetRateType();
            RateTypeL = StaticService.RateTypeTs;
            await PayrollService.GetScheduleType();
            ScheduleTypeL = PayrollService.ScheduleTypeTs;
            await StaticService.GetCashbond();
            CashbondL = StaticService.CashBondTs;
            await StaticService.GetRestDay();
            RestDayL = StaticService.RestDayTs;

            imgBase64 = "./images/addIconImage.png";

            AddNewPrimary(employee.Verify_Id);
            AddNewSecondary(employee.Verify_Id);
            AddNewShs(employee.Verify_Id);
            AddNewCollege(employee.Verify_Id);
            AddNewMasteral(employee.Verify_Id);
            AddNewDoctorate(employee.Verify_Id);
            AddNewOthers(employee.Verify_Id);
            AddNewLicense(employee.Verify_Id);
            AddNewTrainings(employee.Verify_Id);
            AddNewProfBg(employee.Verify_Id);
            AddNewDocument();

        }

        #region LIST VARIABLES
        //FK
        public List<AreaT> AreasL = new();
        public List<StatusT> StatusL = new();
        public List<EmploymentStatusT> EmploymentStatusL = new();

        public List<DivisionT> DivisionsL = new();
        public List<DepartmentT> DepartmentsL = new();
        public List<SectionT> SectionsL = new();
        public List<PositionT> PositionsL = new();

        public List<GenderT> GendersL = new();
        public List<CivilStatusT> CivilStatusL = new();
        public List<ReligionT> ReligionsL = new();
        public List<EmerRelationshipT> EmerRelationshipsL = new();

        //PAYROLL
        public List<CashBondT> CashbondL = new();
        public List<ScheduleTypeT> ScheduleTypeL = new();
        public List<RateTypeT> RateTypeL = new();
        public List<RestDayT> RestDayL = new();
        #endregion

        #region EDUCATION VARIABLE
        //EDUCATION
        public List<Emp_CollegeT> listOfCollege = new();
        public List<Emp_OtherEducT> listOfOthers = new();
        public List<Emp_SecondaryT> listOfSecondary = new();
        public List<Emp_DoctorateT> listOfDoctorate = new();
        public List<Emp_PrimaryT> listOfPrimary = new();
        public List<Emp_MasteralT> listOfMasteral = new();
        public List<Emp_SeniorHST> listOfShs = new();
        public List<Emp_TrainingT> listOfTrainings = new();
        public List<Emp_LicenseT> listofLicense = new();
        public List<Emp_ProfBackgroundT> listofProfbg = new();
        public List<DocumentT> listOfDocuments = new();

        public bool IsListaddshs;
        public bool IsListaddcoll;
        public bool IsListaddmas;
        public bool IsListaddothers;
        public bool IsListadddoc;
        #endregion

        #region DATE VARIBALE
        public DateTime? bday { get; set; }
        public DateTime? Date = DateTime.Today;
        public DateTime? ProbStart = DateTime.Today;
        public DateTime? ProbEnd = DateTime.Today;
        public DateTime? CasualStart = DateTime.Today;
        public DateTime? CasualEnd = DateTime.Today;
        public DateTime? FixedStart = DateTime.Today;
        public DateTime? FixedEnd = DateTime.Today;
        public DateTime? ProjStart = DateTime.Today;
        public DateTime? ProjEnd = DateTime.Today;
        public DateTime? DateHired = DateTime.Today;
        public DateTime? RegularDate = DateTime.Today;
        public DateTime? ResignationDate = DateTime.Today;
        #endregion

        #region IMAGE VARIABLE
        //attachment
        public string PDFBase64 { get; set; }
        public string PDFUrl { get; set; }
        public string PDFFileName { get; set; }
        public string PDFContentType { get; set; }
        public byte[] pdfData { get; set; }
        public bool pdfbool12 { get; set; }
        public bool PDFbool12 { get; set; }
        IList<IBrowserFile> pdffile = new List<IBrowserFile>();
        public List<MultipartFormDataContent> DocuEmployees = new();

        public class DocumentT
        {
            public IList<IBrowserFile> PdfFile { get; set; } = new List<IBrowserFile>();
        }

        //image
        public string imgBase64 { get; set; }
        public string ImageUrl { get; set; }
        public string ImgFileName { get; set; }
        public string ImgContentType { get; set; }
        public string verifyId { get; set; }

        MultipartFormDataContent EmpImage = new();
        IList<IBrowserFile> Imagesfile = new List<IBrowserFile>();
        #endregion

        public string userRole;



        public string slectClasssRT = "frmselect";
        public string slectClasssCB = "frmselect";
        public string slectClasssST = "frmselect";
        public string slectClasssRD = "frmselect";
        public async Task<string> CreateEmployee()
        {
            payroll.ScheduleTypeId = 1;
            payroll.RestDayId = 1;
            if (bday.HasValue)
            {
                DateTime currentDate = DateTime.Today;
                int age = currentDate.Year - bday.Value.Year;

                if (bday.Value > currentDate.AddYears(-age))
                    age--;

                employee.Age = age;
            }

            slectClasssRT = (payroll.RateTypeId == 0) ? "frmselecterror" : "frmselect";
            slectClasssCB = (payroll.CashbondId == 0) ? "frmselecterror" : "frmselect";
            slectClasssST = (payroll.ScheduleTypeId == 0) ? "frmselecterror" : "frmselect";
            slectClasssRD = (payroll.RestDayId == 0) ? "frmselecterror" : "frmselect";
            if (payroll.RateTypeId == 0 || payroll.CashbondId == 0 || payroll.ScheduleTypeId == 0 || payroll.RestDayId == 0)
            {
                string message = "Fill out all fields.";
                return $"{TokenConst.AlertError}xxx{message}";
            }
            else
            {
                try
                {
                    Console.WriteLine("Saving Page");
                    var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");

                    //CREATE EMPLOYEE
                    employee.Verify_Id = verifyCode;
                    employee.Birthdate = Convert.ToDateTime(bday);
                    employee.DateHired = Convert.ToDateTime(DateHired);
                    //employee.InactiveStatusId = 1;
                    license.Date = Convert.ToDateTime(Date);
                    var verifyId = await EmployeeService.CreateEmployee(employee);

                    //CREATE ADDRESS
                    address.Verify_Id = verifyId;
                    var adres = await AddressService.CreateAddress(address);

                    //CREATE EMPLOYMENT DATE
                    employmentDate.Verify_Id = verifyId;
                    employmentDate.EmpmentStatusId = employee.EmploymentStatusId;

                    employmentDate.ProbationStartDate = Convert.ToDateTime(ProbStart);
                    employmentDate.ProbationEndDate = Convert.ToDateTime(ProbEnd);

                    employmentDate.CasualStartDate = Convert.ToDateTime(CasualStart);
                    employmentDate.CasualEndDate = Convert.ToDateTime(CasualEnd);

                    employmentDate.FixedStartDate = Convert.ToDateTime(FixedStart);
                    employmentDate.FixedEndDate = Convert.ToDateTime(FixedEnd);

                    employmentDate.ProjStartDate = Convert.ToDateTime(ProjStart);
                    employmentDate.ProjEndDate = Convert.ToDateTime(ProjEnd);

                    employmentDate.RegularizationDate = Convert.ToDateTime(RegularDate);
                    employmentDate.ResignationDate = Convert.ToDateTime(ResignationDate);
                    var empDate = await EmploymentDateService.CreateEmploymentDate(employmentDate);

                    //CREATE PAYROLL
                    payroll.Salary = "";
                    payroll.Paytype = "";
                    payroll.Verify_Id = verifyId;
                    var savepayroll = await PayrollService.CreatePayroll(payroll);

                    //CREATE EMPLOYEE HISTORY
                    empHistory.Verify_Id = verifyId;
                    empHistory.EmployeeId = employee.Id;
                    empHistory.DateStarted = employee.DateHired;
                    empHistory.NewAreaId = employee.AreaId;
                    empHistory.NewDivisionId = employee.DivisionId;
                    empHistory.NewDepartmentId = employee.DepartmentId;
                    empHistory.NewSectionId = employee.SectionId;
                    empHistory.NewPositionId = employee.PositionId;
                    var saveemphistory = await EmpHistoryService.CreateEmpHistory(empHistory);

                    //CREATE EMP EVAL
                    var generateEval = await ForEvalService.GenerateStatus(verifyCode, employee.DateHired, "Pending");
                    var saveeval = await ForEvalService.CreateForEval(generateEval);

                    //CREATE FILES AND IMAGE
                    var divisionString = employee.DivisionId;
                    var departmentString = employee.DepartmentId;

                    await OnsavingImg(employee.EmployeeNo, divisionString, departmentString, employee.LastName, verifyId);
                    await OnPDFSaving(employee.EmployeeNo, divisionString, departmentString, employee.LastName, verifyId);

                    //CREATE EDUCATIONS
                    await CreatePrimaryRecords(verifyCode);
                    await CreateSecondaryRecords(verifyCode);
                    await CreateSeniorHSRecords(verifyCode);
                    await CreateCollegeRecords(verifyCode);
                    await CreateMasteralRecords(verifyCode);
                    await CreateDoctorateRecords(verifyCode);
                    await CreateOtherEducRecords(verifyCode);
                    await CreateLicenses(verifyCode);
                    await CreateTrainings(verifyCode);
                    await CreateProfBg(verifyCode);

                    var user_id = Convert.ToInt32(GlobalConfigService.User_Id);
                    await AuditlogService.CreateLog(user_id, "CREATE", "Model", DateTime.Now);
                    _navigationManager.NavigateTo("employee");

                    string message = "Successfully Created.";
                    return $"{TokenConst.AlertSuccess}xxx{message}";

                }
                catch (Exception ex)
                {
                    return $"{TokenConst.AlertError}xxx{ex.Message}";
                }
            }
        }

        #region IMAGE
        //IMAGE
        public async Task uploadImage(InputFileChangeEventArgs e)
        {
            long lngImage = long.MaxValue;
            var brwModel = e.File;
            var imgFilename = e.File.Name;
            var imgContent = e.File.ContentType;
            var imgBuffer = new byte[e.File.Size];
            var imgURL = $"data:{imgContent};base64,{Convert.ToBase64String(imgBuffer)}";

            using (var _stream = brwModel.OpenReadStream(lngImage))
            {
                await _stream.ReadAsync(imgBuffer);
            }

            if (e.File.Name is null)
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Error",
                    Text = "No image uploaded!",
                    Icon = SweetAlertIcon.Error
                });
                return;
            }
            else
            {
                using var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(brwModel.OpenReadStream(lngImage));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imgContent);

                ImageUrl = imgURL;
                ImgContentType = imgContent;
                ImgFileName = imgFilename;
                EmpImage.Add(content: fileContent, name: imgFilename, fileName: imgFilename);

                var base642 = Convert.ToBase64String(imgBuffer);
                imgBase64 = string.Format("data:image/*;base64,{0}", base642);
            }
        }

        //documents
        public async Task UpPdfSec12(InputFileChangeEventArgs e, int index)
        {
            long maxPDFSize = long.MaxValue;
            var _pdfModel = e.File;
            var _pdfFilename = e.File.Name;
            var _pdfContent = e.File.ContentType;
            var _pdfBuffer = new byte[e.File.Size];
            var _pdfURL = $"data:{_pdfContent};base64,{Convert.ToBase64String(_pdfBuffer)}";

            using (var _stream = _pdfModel.OpenReadStream(maxPDFSize))
            {
                await _stream.ReadAsync(_pdfBuffer);
            }
            if (e.File.Name is null)
            {
                imgBase64 = "Images/empty1.png";
            }
            else
            {
                var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(_pdfModel.OpenReadStream(maxPDFSize));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(_pdfContent);

                PDFFileName = _pdfFilename;
                PDFUrl = _pdfURL;
                pdfData = _pdfBuffer;

                var streamContent = new StreamContent(_pdfModel.OpenReadStream(maxPDFSize));
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(_pdfContent);

                content.Add(streamContent, "\"files\"", _pdfFilename);

                var pdfbase64 = Convert.ToBase64String(_pdfBuffer);
                PDFBase64 = string.Format("data:application/pdf;base64,{0}", pdfbase64);

                pdfbool12 = false;
                PDFbool12 = true;
                listOfDocuments[index].PdfFile.Add(e.File);
                DocuEmployees.Add(content);
            }
        }

        public async Task OnsavingImg(string EmployeeId, int division, int department, string lastname, string verify)
        {
            using var _contentImg = new MultipartFormDataContent();

            //_contentImg.Add(EmpImage.LastOrDefault());
            //await ImageService.AttachFile(_contentImg, EmployeeId, division, department, lastname, verify);
            if (EmpImage.Any())
            {
                _contentImg.Add(EmpImage.LastOrDefault());
                await ImageService.AttachFile(_contentImg, EmployeeId, division, department, lastname, verify);
            }
            else
            {
                //string defaultImagePath = "images/imgholder.jpg";
                //using (FileStream fs = new FileStream(defaultImagePath, FileMode.Open))
                //{
                //    using (var streamContent = new StreamContent(fs))
                //    {
                //        streamContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

                //        _contentImg.Add(streamContent, "default_image", "imgholder.jpg");

                //        await ImageService.AttachFile(_contentImg, EmployeeId, division, department, lastname, verify);
                //    }
                //}
            }
        }

        public async Task OnPDFSaving(string EmployeeId, int division, int department, string lastname, string verify)
        {
            Console.WriteLine($"EmployeeId: {EmployeeId}");
            Console.WriteLine($"division: {division}");
            Console.WriteLine($"department: {department}");
            Console.WriteLine($"lastname: {lastname}");
            Console.WriteLine($"verify: {verify}");

            foreach (var formdata in DocuEmployees)
            {
                await ImageService.AttachedFile(formdata, EmployeeId, division, department, lastname, verify);
            }
        }
        #endregion

        #region FUNCTIONS / BUTTONS
        public void HandleDateHiredChanged(DateTime? newDate)
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
                        break;
                }
            }
            else
            {
                // If DateHired is not set, clear RegularDate.
                RegularDate = null;
            }
        }

        public string CalculateAge(DateTime? selectedDate)
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

        //private void OnValidSubmit(EditContext context)
        //{
        //    success = true;
        //    StateHasChanged();
        //}

        public void backbtn()
        {
            _navigationManager.NavigateTo("/employee");
        }
        #endregion

        #region MUDTABS
        public MudTabs tabs;
        public string slectClasss = "frmselect";
        public string imguploadclass = "btnimage";
        public string clsBday = "txf";
        public string mesBday;
        public string clsGender = "frmselect";
        public string mesGender;
        public void Activate(int index)
        {
            clsBday = (bday.ToString() == "") ? "mud-input-error txf" : "txf";
            mesBday = (bday.ToString() == "") ? "Birthdate is required" : string.Empty;
            _slectClasssGender = (employee.GenderId == 0) ? "frmselecterror" : "frmselect";
            _slectClasssCV = (employee.CivilStatusId == 0) ? "frmselecterror" : "frmselect";
            _slectClasssReli = (employee.ReligionId == 0) ? "frmselecterror" : "frmselect";
            _slectClasssRela = (employee.EmerRelationshipId == 0) ? "frmselecterror" : "frmselect";
        }
        public void Activate2(int index)
        {
            tabs.ActivatePanel(index);

        }
        #endregion

        #region TAB CLASS
        //TAB PANEL
        public int activeIndex;

        public string GetTabChipClass(int tabId)
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

        public string GetTabTextClass(int tabId)
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

        public RenderFragment tabHeader(int tabId)
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
            };
        }
        #endregion

        #region PERSONAL TAB ERROR TRAP
        public string _slectClasssGender = "frmselect";
        public string _slectClasssCV = "frmselect";
        public string _slectClasssReli = "frmselect";
        public string _slectClasssRela = "frmselect";
        public string _txfieldClasssNat = "txf1";
        public string _txfieldClasssMN = "txf";
        public string _txfieldClasssEN = "txf1";
        public string _txfieldClasssEA = "txf1";
        public string _txfieldClasssEMN = "txf";


        #endregion

        #region EDUCATION
        public async Task CreatePrimaryRecords(string employeeVerifyId)
        {
            //primary
            var validRecords = listOfPrimary
                .Where
                (pri => !string.IsNullOrEmpty(pri.PriSchoolName) || !string.IsNullOrEmpty(pri.PriSchoolLoc)
                     || !string.IsNullOrEmpty(pri.PriAward) || !string.IsNullOrEmpty(pri.PriSchoolYear))
                .ToList();
            if (validRecords.Count == 0)
            {
                return;
            }
            foreach (var pri in validRecords)
            {
                pri.Verify_Id = employeeVerifyId;
                await EducationService.CreatePrimary(pri);
            }

            listOfPrimary.Clear();
            AddNewPrimary(employeeVerifyId);
        }


        public async Task CreateSecondaryRecords(string employeeVerifyId)
        {
            //secondary
            var validSecodary = listOfSecondary
               .Where
               (sec => !string.IsNullOrEmpty(sec.SecSchoolName) || !string.IsNullOrEmpty(sec.SecSchoolLoc)
                    || !string.IsNullOrEmpty(sec.SecAward) || !string.IsNullOrEmpty(sec.SecSchoolYear))
               .ToList();
            if (validSecodary.Count == 0)
            {
                return;
            }
            foreach (var sec in validSecodary)
            {
                sec.Verify_Id = employeeVerifyId;
                await EducationService.CreateSecondary(sec);
            }

            listOfSecondary.Clear();
            AddNewSecondary(employeeVerifyId);
        }

        public async Task CreateSeniorHSRecords(string employeeVerifyId)
        {  //shs
            var validShs = listOfShs
               .Where
               (shs => !string.IsNullOrEmpty(shs.ShsSchoolName) || !string.IsNullOrEmpty(shs.ShsSchoolLoc)
                    || !string.IsNullOrEmpty(shs.ShsAward) || !string.IsNullOrEmpty(shs.ShsSchoolYear))
               .ToList();
            if (validShs.Count == 0)
            {
                return;
            }
            foreach (var shs in validShs)
            {
                shs.Verify_Id = employeeVerifyId;
                await EducationService.CreateSeniorHS(shs);
            }

            listOfShs.Clear();
            AddNewShs(employeeVerifyId);
        }

        public async Task CreateCollegeRecords(string employeeVerifyId)
        {
            //college
            var validCollege = listOfCollege
               .Where
               (coll => !string.IsNullOrEmpty(coll.CollSchoolName) || !string.IsNullOrEmpty(coll.CollSchoolLoc)
                    || !string.IsNullOrEmpty(coll.CollAward) || !string.IsNullOrEmpty(coll.CollSchoolYear)
                    || !string.IsNullOrEmpty(coll.CollCourse))
               .ToList();
            if (validCollege.Count == 0)
            {
                return;
            }
            foreach (var coll in validCollege)
            {
                coll.Verify_Id = employeeVerifyId;
                await EducationService.CreateCollege(coll);
            }

            listOfCollege.Clear();
            AddNewCollege(employeeVerifyId);

        }

        public async Task CreateMasteralRecords(string employeeVerifyId)
        {
            //masteral
            var validMasteral = listOfMasteral
               .Where
               (mas => !string.IsNullOrEmpty(mas.MasSchoolName) || !string.IsNullOrEmpty(mas.MasSchoolLoc)
                    || !string.IsNullOrEmpty(mas.MasAward) || !string.IsNullOrEmpty(mas.MasSchoolYear)
                    || !string.IsNullOrEmpty(mas.MasCourse))
               .ToList();
            if (validMasteral.Count == 0)
            {
                return;
            }
            foreach (var mas in validMasteral)
            {
                mas.Verify_Id = employeeVerifyId;
                await EducationService.CreateMasteral(mas);
            }

            listOfMasteral.Clear();
            AddNewMasteral(employeeVerifyId);
        }

        public async Task CreateDoctorateRecords(string employeeVerifyId)
        {
            //doctorate
            var validDoctorate = listOfDoctorate
               .Where
               (doc => !string.IsNullOrEmpty(doc.DocSchoolName) || !string.IsNullOrEmpty(doc.DocSchoolLoc)
                    || !string.IsNullOrEmpty(doc.DocAward) || !string.IsNullOrEmpty(doc.DocSchoolYear)
                    || !string.IsNullOrEmpty(doc.DocCourse))
               .ToList();
            if (validDoctorate.Count == 0)
            {
                return;
            }
            foreach (var doc in validDoctorate)
            {
                doc.Verify_Id = employeeVerifyId;
                await EducationService.CreateDoctorate(doc);
            }

            listOfDoctorate.Clear();
            AddNewDoctorate(employeeVerifyId);
        }

        public async Task CreateOtherEducRecords(string employeeVerifyId)
        {
            //othereduc
            var validothers = listOfOthers
               .Where
               (other => !string.IsNullOrEmpty(other.OthersSchoolType) || !string.IsNullOrEmpty(other.OthersSchoolName)
                    || !string.IsNullOrEmpty(other.OthersSchoolLoc) || !string.IsNullOrEmpty(other.OthersAward)
                    || !string.IsNullOrEmpty(other.OthersSchoolYear) || !string.IsNullOrEmpty(other.OthersCourse))
               .ToList();
            if (validothers.Count == 0)
            {
                return;
            }
            foreach (var others in validothers)
            {
                others.Verify_Id = employeeVerifyId;
                await EducationService.CreateOtherEduc(others);
            }

            listOfOthers.Clear();
            AddNewOthers(employeeVerifyId);
        }

        public async Task CreateLicenses(string employeeVerifyId)
        {
            //training
            var validLicenses = listofLicense
               .Where
               (license =>
                    !string.IsNullOrEmpty(license.Examination) ||
                    !string.IsNullOrEmpty(license.Rating) ||
                    !string.IsNullOrEmpty(license.LicenseNo))
               .ToList();
            if (validLicenses.Count == 0)
            {
                return;
            }
            foreach (var license in validLicenses)
            {
                license.Verify_Id = employeeVerifyId;
                await LicenseTrainingService.CreateLicense(license);
            }

            listofLicense.Clear();
            AddNewLicense(employeeVerifyId);
        }

        public async Task CreateTrainings(string employeeVerifyId)
        {
            //training
            var validtraining = listOfTrainings
               .Where
               (train => !string.IsNullOrEmpty(train.TrainingName)
                    || !string.IsNullOrEmpty(train.SponsorSpeaker))
               .ToList();
            if (validtraining.Count == 0)
            {
                return;
            }
            foreach (var train in validtraining)
            {
                train.Verify_Id = employeeVerifyId;
                await LicenseTrainingService.CreateTraining(train);
            }

            listOfTrainings.Clear();
            AddNewTrainings(employeeVerifyId);
        }

        public async Task CreateProfBg(string employeeVerifyId)
        {
            //training
            var validBg = listofProfbg
               .Where
               (item => !string.IsNullOrEmpty(item.CompanyName)
                    || !string.IsNullOrEmpty(item.Position))
               .ToList();
            if (validBg.Count == 0)
            {
                return;
            }
            foreach (var bg in validBg)
            {
                bg.Verify_Id = employeeVerifyId;
                await LicenseTrainingService.CreateProfBg(bg);
            }

            listOfTrainings.Clear();
            AddNewTrainings(employeeVerifyId);
        }

        public void AddNewPrimary(string employeeVerifyId)
        {
            if (listOfPrimary.Count <= 5)
            {
                listOfPrimary.Add(new Emp_PrimaryT { Verify_Id = employee.Verify_Id });
            }
        }

        public void RemovePrimary()
        {
            if (listOfPrimary.Count > 0)
            {
                listOfPrimary.RemoveAt(listOfPrimary.Count - 1);
            }
        }
        public void AddNewSecondary(string employeeVerifyId)
        {
            if (listOfSecondary.Count <= 3)
            {
                listOfSecondary.Add(new Emp_SecondaryT { Verify_Id = employee.Verify_Id });
            }
        }
        public void RemoveSecondary()
        {
            if (listOfSecondary.Count <= 1) { }
            else
            {
                listOfSecondary.RemoveAt(listOfSecondary.Count - 1);
            }
        }

        public void AddNewShs(string employeeVerifyId)
        {
            if (listOfShs.Count <= 2)
            {
                listOfShs.Add(new Emp_SeniorHST { Verify_Id = employee.Verify_Id });
            }
        }
        public void RemoveShs()
        {
            if (listOfShs.Count <= 1) { }
            else
            {
                listOfShs.RemoveAt(listOfShs.Count - 1);
            }
        }

        public void AddNewCollege(string employeeVerifyId)
        {
            if (listOfCollege.Count <= 2)
            {
                listOfCollege.Add(new Emp_CollegeT { Verify_Id = employee.Verify_Id });
            }
        }
        public void RemoveCollege()
        {
            if (listOfCollege.Count <= 1) { }
            else
            {
                listOfCollege.RemoveAt(listOfCollege.Count - 1);
            }
        }

        public void AddNewMasteral(string employeeVerifyId)
        {
            if (listOfMasteral.Count <= 2)
            {
                listOfMasteral.Add(new Emp_MasteralT { Verify_Id = employee.Verify_Id });
            }
        }
        public void RemoveMasteral()
        {
            if (listOfMasteral.Count <= 1) { }
            else
            {
                listOfMasteral.RemoveAt(listOfMasteral.Count - 1);
            }
        }

        public void AddNewDoctorate(string employeeVerifyId)
        {
            if (listOfDoctorate.Count <= 2)
            {
                listOfDoctorate.Add(new Emp_DoctorateT { Verify_Id = employee.Verify_Id });
            }
        }
        public void RemoveDoctorate()
        {
            if (listOfDoctorate.Count <= 1) { }
            else
            {
                listOfDoctorate.RemoveAt(listOfDoctorate.Count - 1);
            }
        }

        public void AddNewOthers(string employeeVerifyId)
        {
            if (listOfOthers.Count <= 4)
            {
                listOfOthers.Add(new Emp_OtherEducT { Verify_Id = employee.Verify_Id });
            }
        }
        public void RemoveOthers()
        {
            if (listOfOthers.Count <= 1) { }
            else
            {
                listOfOthers.RemoveAt(listOfOthers.Count - 1);
            }
        }

        public void AddNewLicense(string employeeVerifyId)
        {
            if (listofLicense.Count <= 5)
            {
                listofLicense.Add(new Emp_LicenseT { Verify_Id = employee.Verify_Id });
                //StateHasChanged();
            }
        }

        public void RemoveLicense()
        {
            if (listofLicense.Count <= 1) { }
            else
            {
                listofLicense.RemoveAt(listofLicense.Count - 1);
            }
        }

        public void AddNewTrainings(string employeeVerifyId)
        {
            if (listOfTrainings.Count <= 5)
            {
                listOfTrainings.Add(new Emp_TrainingT { Verify_Id = employee.Verify_Id });
            }
        }
        public void RemoveTrainings()
        {
            if (listOfTrainings.Count <= 1) { }
            else
            {
                listOfTrainings.RemoveAt(listOfTrainings.Count - 1);
            }
        }

        public void AddNewProfBg(string employeeVerifyId)
        {
            if (listofProfbg.Count <= 15)
            {
                listofProfbg.Add(new Emp_ProfBackgroundT { Verify_Id = employee.Verify_Id });
            }
        }
        public void RemoveProfBg()
        {
            if (listofProfbg.Count <= 1) { }
            else
            {
                listofProfbg.RemoveAt(listofProfbg.Count - 1);
            }
        }

        public void AddNewDocument()
        {
            if (listOfDocuments.Count <= 9)
            {
                listOfDocuments.Add(new DocumentT());
            }
        }
        #endregion
    }
}
