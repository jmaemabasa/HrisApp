using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace HrisApp.Client.Pages.Employee
{
#nullable disable
    public partial class AddEmployee: ComponentBase
    {
        [CascadingParameter]
        private Task<AuthenticationState> authState { get; set; }


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
        private string txfieldClasss = "txf1";
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

        [Parameter]
        public int? id { get; set; }

        EmployeeT employee = new();
        AddressT address = new();
        PayrollT payroll = new();
        LicenseT license = new();
        DocumentT document = new();


        bool success;
        #region LIST VARIABLES
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
        #endregion

        #region EDUCATION VARIABLE
        //EDUCATION
        List<CollegeT> listOfCollege = new();
        List<OtherEducT> listOfOthers = new();
        List<SecondaryT> listOfSecondary = new();
        List<DoctorateT> listOfDoctorate = new();
        List<PrimaryT> listOfPrimary = new();
        List<MasteralT> listOfMasteral = new();
        List<SeniorHST> listOfShs = new();
        List<TrainingT> listOfTrainings = new();
        List<LicenseT> listofLicense = new();
        List<DocumentT> listOfDocuments = new();
        #endregion

        private bool IsListaddshs;
        private bool IsListaddcoll;
        private bool IsListaddmas;
        private bool IsListaddothers;
        private bool IsListadddoc;

        string VerifyCode;

        #region DATA VARIBALE
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
        private List<MultipartFormDataContent> DocuEmployees = new List<MultipartFormDataContent>();

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

        MultipartFormDataContent EmpImage = new MultipartFormDataContent();
        IList<IBrowserFile> Imagesfile = new List<IBrowserFile>();
        #endregion

        private string userRole;

        #region ONINITIALIZEDASYNC
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
            try
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
                if (payroll.RateTypeId == 0 || payroll.CashbondId == 0 || payroll.ScheduleTypeId == 0 || payroll.RestDayId == 0 )
                {
                    _toastService.ShowError("Fill out all fields.");
                }
                else
                {
                    Console.WriteLine("Saving Page");
                    var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");

                    employee.Verify_Id = verifyCode;

                    employee.Birthdate = Convert.ToDateTime(bday);
                    employee.DateHired = Convert.ToDateTime(DateHired);
                    license.Date = Convert.ToDateTime(Date);


                    if (!string.IsNullOrEmpty(employee.InactiveStatusId.ToString()))
                    {
                        employee.InactiveStatusId = 1;
                    }

                    var verifyId = await EmployeeService.CreateEmployee(employee);

                    address.Verify_Id = verifyId;
                    var adres = await AddressService.CreateAddress(address);


                    payroll.Salary = "212";
                    payroll.Paytype = "test";
                    payroll.Verify_Id = verifyId;
                    var savepayroll = await PayrollService.CreatePayroll(payroll);

                    var divisionString = employee.DivisionId;
                    var divisionPDF = employee.DivisionId;

                    var departmentString = employee.DepartmentId;
                    var departmentPDF = employee.DepartmentId;

                    await OnsavingImg(employee.EmployeeNo, divisionString, departmentString, employee.LastName, verifyId);
                    await OnPDFSaving(employee.EmployeeNo, divisionPDF, departmentPDF, employee.LastName, verifyId);

                    await CreatePrimaryRecords(verifyCode);
                    await CreateSecondaryRecords(verifyCode);
                    await CreateSeniorHSRecords(verifyCode);
                    await CreateCollegeRecords(verifyCode);
                    await CreateMasteralRecords(verifyCode);
                    await CreateDoctorateRecords(verifyCode);
                    await CreateOtherEducRecords(verifyCode);
                    await CreateLicenses(verifyCode);
                    await CreateTrainings(verifyCode);

                    NavigationManager.NavigateTo("employee");

                    var swal = await Swal.FireAsync(new SweetAlertOptions
                    {
                        Text = "Created Successfully!",
                        Icon = SweetAlertIcon.Success
                    });
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _toastService.ShowError(ex.Message);
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
            _contentImg.Add(EmpImage.LastOrDefault());
            await ImageService.AttachFile(_contentImg, EmployeeId, division, department, lastname, verify);
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
                    !string.IsNullOrEmpty(license.ProfMembership) ||
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
                    || !string.IsNullOrEmpty(train.Remarks))
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
                listOfPrimary.Add(new PrimaryT { Verify_Id = employee.Verify_Id });
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
                listOfSecondary.Add(new SecondaryT { Verify_Id = employee.Verify_Id });
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
                listOfShs.Add(new SeniorHST { Verify_Id = employee.Verify_Id });
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
                listOfCollege.Add(new CollegeT { Verify_Id = employee.Verify_Id });
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
                listOfMasteral.Add(new MasteralT { Verify_Id = employee.Verify_Id });
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
                listOfDoctorate.Add(new DoctorateT { Verify_Id = employee.Verify_Id });
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
                listOfOthers.Add(new OtherEducT { Verify_Id = employee.Verify_Id });
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
                listofLicense.Add(new LicenseT { Verify_Id = employee.Verify_Id });
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
                listOfTrainings.Add(new TrainingT { Verify_Id = employee.Verify_Id });
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

        string GetTabClass(int tabId)
        {
            if (activeIndex > tabId)
            {
                return "mud-tabs-afterindex";
            }
            else
            {
                return "mud-tabs-defaultindex";
            }
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
                    builder.AddContent(6, "Payroll");
                    builder.CloseComponent();
                }

            };
        }
        #endregion
    }
}
