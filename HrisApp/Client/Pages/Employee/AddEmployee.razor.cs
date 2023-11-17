﻿using System.Net.Security;

namespace HrisApp.Client.Pages.Employee
{
#nullable disable
    public partial class AddEmployee : ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> authState { get; set; }
        string _sectionnull = string.Empty;

        #region MUDTABS
        MudTabs tabs;
        private string slectClasss = "frmselect";
        private string imguploadclass = "btnimage";
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
                    imguploadclass = "btnimage";
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
        private string _slectClasssGender = "frmselect";
        private string _slectClasssCV = "frmselect";
        private string _slectClasssReli = "frmselect";
        private string _slectClasssRela = "frmselect";
        private string _txfieldClasssNat = "txf1";
        private string _txfieldClasssMN = "txf";
        private string _txfieldClasssEN = "txf1";
        private string _txfieldClasssEA = "txf1";
        private string _txfieldClasssEMN = "txf";

        private async void ActivateAddressField()
        {
            _slectClasssGender = (employee.GenderId == 0) ? "frmselecterror" : "frmselect";
            _slectClasssCV = (employee.CivilStatusId == 0) ? "frmselecterror" : "frmselect";
            _slectClasssReli = (employee.ReligionId == 0) ? "frmselecterror" : "frmselect";
            _slectClasssRela = (employee.EmerRelationshipId == 0) ? "frmselecterror" : "frmselect";
            _txfieldClasssNat = (String.IsNullOrWhiteSpace(employee.Nationality)) ? "txf1error" : "txf1";
            _txfieldClasssMN = (String.IsNullOrWhiteSpace(employee.MobileNumber)) ? "txf1error" : "txf";
            _txfieldClasssEN = (String.IsNullOrWhiteSpace(employee.EmerName)) ? "txf1error" : "txf1";
            _txfieldClasssEA = (String.IsNullOrWhiteSpace(employee.EmerAddress)) ? "txf1error" : "txf1";
            _txfieldClasssEMN = (String.IsNullOrWhiteSpace(employee.EmerMobNum)) ? "txf1error" : "txf";

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

        [Parameter]
        public int? Id { get; set; }

        EmployeeT employee = new();
        Emp_AddressT address = new();
        Emp_EmploymentDateT employmentDate = new();
        Emp_PayrollT payroll = new();
        Emp_LicenseT license = new();


        //bool success;
        
        #region LIST VARIABLES
        //FK
        private List<AreaT> AreasL = new();
        private List<StatusT> StatusL = new();
        private List<EmploymentStatusT> EmploymentStatusL = new();

        private List<DivisionT> DivisionsL = new();
        private List<DepartmentT> DepartmentsL = new();
        private List<SectionT> SectionsL = new();
        private List<PositionT> PositionsL = new();

        private List<GenderT> GendersL = new();
        private List<CivilStatusT> CivilStatusL = new();
        private List<ReligionT> ReligionsL = new();
        private List<EmerRelationshipT> EmerRelationshipsL = new();

        //PAYROLL
        private List<CashBondT> CashbondL = new();
        private List<ScheduleTypeT> ScheduleTypeL = new();
        private List<RateTypeT> RateTypeL = new();
        private List<RestDayT> RestDayL = new();
        #endregion

        #region EDUCATION VARIABLE
        //EDUCATION
        List<Emp_CollegeT> listOfCollege = new();
        List<Emp_OtherEducT> listOfOthers = new();
        List<Emp_SecondaryT> listOfSecondary = new();
        List<Emp_DoctorateT> listOfDoctorate = new();
        List<Emp_PrimaryT> listOfPrimary = new();
        List<Emp_MasteralT> listOfMasteral = new();
        List<Emp_SeniorHST> listOfShs = new();
        List<Emp_TrainingT> listOfTrainings = new();
        List<Emp_LicenseT> listofLicense = new();
        List<DocumentT> listOfDocuments = new();

        private bool IsListaddshs;
        private bool IsListaddcoll;
        private bool IsListaddmas;
        private bool IsListaddothers;
        private bool IsListadddoc;
        #endregion

        #region DATE VARIBALE
        private DateTime? bday { get; set; }
        private DateTime? Date = DateTime.Today;
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
        private DateTime? ResignationDate = DateTime.Today;
        #endregion

        #region IMAGE VARIABLE
        //attachment
        private string PDFBase64 { get; set; }
        private string PDFUrl { get; set; }
        private string PDFFileName { get; set; }
        private string PDFContentType { get; set; }
        private byte[] pdfData { get; set; }
        private bool pdfbool12 { get; set; }
        private bool PDFbool12 { get; set; }
        IList<IBrowserFile> pdffile = new List<IBrowserFile>();
        private List<MultipartFormDataContent> DocuEmployees = new();

        public class DocumentT
        {
            public IList<IBrowserFile> PdfFile { get; set; } = new List<IBrowserFile>();
        }

        //image
        private string imgBase64 { get; set; }
        private string ImageUrl { get; set; }
        private string ImgFileName { get; set; }
        private string ImgContentType { get; set; }
        private string verifyId { get; set; }

        MultipartFormDataContent EmpImage = new();
        IList<IBrowserFile> Imagesfile = new List<IBrowserFile>();
        #endregion

        private string userRole;

        #region ONINITIALIZEDASYNC
        protected override async Task OnInitializedAsync()
        {
            await AreaService.GetAreaList();
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
            AddNewDocument();

            var auth = await authState;

            userRole = auth.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        }
        #endregion

        private string slectClasssRT = "frmselect";
        private string slectClasssCB = "frmselect";
        private string slectClasssST = "frmselect";
        private string slectClasssRD = "frmselect";
        async Task CreateEmployee()
        {
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
                _toastService.ShowError("Fill out all fields.");
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
                    employee.InactiveStatusId = 1;
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

                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model",  DateTime.Now);
                    NavigationManager.NavigateTo("employee");

                    var swal = await Swal.FireAsync(new SweetAlertOptions
                    {
                        Text = "Created Successfully!",
                        Icon = SweetAlertIcon.Success
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _toastService.ShowError(ex.Message);
                }
            }
        }

        #region FUNCTIONS / BUTTONS
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

        //private void OnValidSubmit(EditContext context)
        //{
        //    success = true;
        //    StateHasChanged();
        //}

        void backbtn()
        {
            NavigationManager.NavigateTo("/employee");
        }
        #endregion

        #region IMAGE
        //IMAGE
        async Task uploadImage(InputFileChangeEventArgs e)
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
        private async Task UpPdfSec12(InputFileChangeEventArgs e, int index)
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

        private async Task OnsavingImg(string EmployeeId, int division, int department, string lastname, string verify)
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

        private async Task OnPDFSaving(string EmployeeId, int division, int department, string lastname, string verify)
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

        #region EDUCATION
        async Task CreatePrimaryRecords(string employeeVerifyId)
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


        async Task CreateSecondaryRecords(string employeeVerifyId)
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

        async Task CreateSeniorHSRecords(string employeeVerifyId)
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

        async Task CreateCollegeRecords(string employeeVerifyId)
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

        async Task CreateMasteralRecords(string employeeVerifyId)
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

        async Task CreateDoctorateRecords(string employeeVerifyId)
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

        async Task CreateOtherEducRecords(string employeeVerifyId)
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

        async Task CreateLicenses(string employeeVerifyId)
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

        async Task CreateTrainings(string employeeVerifyId)
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
                StateHasChanged();
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

        public void AddNewDocument()
        {
            if (listOfDocuments.Count <= 9)
            {
                listOfDocuments.Add(new DocumentT());
            }
        }
        #endregion

        #region TAB CLASS
        //TAB PANEL
        int activeIndex;

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
                    builder.AddContent(6, "Job");
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
                    builder.AddContent(6, "Personal");
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
        #endregion
    }
}
