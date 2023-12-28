using MudBlazor;
using Newtonsoft.Json;
using NPOI.HPSF;

namespace HrisApp.Client.Pages.Employee
{
    public partial class UpdateEmployee : ComponentBase
    {
#nullable disable
        [Parameter]
        public int id { get; set; }

        DateTime fiveYearsAgo = DateTime.Now.AddYears(-5);

        #region TABLE VARIABLES
        EmployeeT employee = new();
        Emp_AddressT _address = new();
        Emp_PayrollT _payroll = new();
        PositionT _position = new();
        SubPositionT _subposition = new();
        SubPositionT _newsubposition = new();
        //EmpPictureT _empPicture = new();
        Emp_EmploymentDateT _employmentDate = new();
        Emp_PosHistoryT _updateposHistory = new();
        public Emp_PosHistoryT empHistory = new();
        #endregion

        #region LIST TABLE VARIABLES
        //FK
        private List<AreaT> AreasL = new();
        private List<StatusT> StatusL = new();
        private List<EmploymentStatusT> EmploymentStatusL = new();

        private List<DivisionT> DivisionsL = new();
        private List<DepartmentT> DepartmentsL = new();
        //private List<SectionT> SectionsL = new();
        private List<PositionT> PositionsL = new();
        private List<SubPositionT> SubPositionsL = new();
        private List<PosMPExternalT> ExternalsL = new();
        private List<PosMPInternalT> InternalsL = new();

        private List<GenderT> GendersL = new();
        private List<CivilStatusT> CivilStatusL = new();
        private List<ReligionT> ReligionsL = new();
        private List<EmerRelationshipT> EmerRelationshipsL = new();

        //PAYROLL
        private List<CashBondT> CashbondL = new();
        private List<ScheduleTypeT> ScheduleTypeL = new();
        private List<RateTypeT> RateTypeL = new();
        private List<RestDayT> RestDayL = new();

        private List<DocumentT> pdffileList = new();
        private List<Emp_PosHistoryT> empHistoryList = new();

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
        bool ScheduleOpen;
        bool StatutoryOpen;
        Anchor anchor;
        string width = "500px", height = "100%";

        void OpenDrawer(Anchor anchor, string drawerx)
        {
            personalandjobOpen = (drawerx == "personalandjobOpen");
            workInfoOpen = (drawerx == "workInfoOpen");
            emerOpen = (drawerx == "emerOpen");
            addressOpen = (drawerx == "addressOpen");
            documentsOpen = (drawerx == "documentsOpen");
            StatutoryOpen = (drawerx == "StatutoryOpen");
            ScheduleOpen = (drawerx == "ScheduleOpen");
            this.anchor = anchor;
        }
        #endregion

        string VerifyCode;
        private string NoInformation = "No Information.";

        private string ImageData { get; set; }
        private List<string> PDFDataList = new();

        protected override async Task OnInitializedAsync()
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
            //SectionsL = SectionService.SectionTs;
            await PositionService.GetPosition();
            PositionsL = PositionService.PositionTs;
            await PositionService.GetSubPosition();
            SubPositionsL = PositionService.SubPositionTs;
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
            await ManpowerService.GetExternal();
            ExternalsL = ManpowerService.PosMPExternalTs;
        }

        protected override async Task OnParametersSetAsync()
        {
            employee = await EmployeeService.GetSingleEmployee(id);
            _address = await AddressService.GetSingleAddress(id);
            _payroll = await PayrollService.GetSinglePayroll(id);
            _subposition = await PositionService.GetSingleSubPosition(employee.PositionId);

            //_position = await PositionService.GetSinglePosition(employee.PositionId);
            _position = await PositionService.GetSinglePositionByCode(_subposition.PosCode);


            _employmentDate = await EmploymentDateService.GetSingleEmploymentDate(id);

            await PDFImage(employee.Verify_Id, employee.EmployeeNo);
            await ImageService.GetNewPDF(employee.Verify_Id, employee.EmployeeNo);
            pdffileList = ImageService.DocumentTs;

            VerifyCode = employee.Verify_Id;
            try
            {
                _updateposHistory = await EmpHistoryService.GetEmpLastHistory(VerifyCode);
                await EmployeeImg(employee.Verify_Id);//image
                Console.WriteLine($"{_updateposHistory.NewAreaId} {_updateposHistory.NewPositionId}");
            }
            catch (Exception)
            {
                ImageData = string.Format("images/imgholder.jpg");
            }

            bday = employee.Birthdate;
            DateHired = employee.DateHired;

           
        }

        public async Task OnExporttoPDF()
        {
            try
            {
                string url = await EmployeeService.EmpDetailsGenerate(employee.Verify_Id);
                await JSRuntime.InvokeAsync<object>("open", url, "_blank");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //NavigateError();
            }
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

            if (employee.StatusId == 1)
                employee.DateInactiveStatus = null;

            if (employee.StatusId != 1)
            {
                if (employee.DateInactiveStatus == null)
                {
                    workInfoOpen = false;
                    await Swal.FireAsync(new SweetAlertOptions
                    {
                        Title = "Warning",
                        Text = "Please fill up the Inactive Date!",
                        Icon = SweetAlertIcon.Warning
                    });
                    employee.StatusId = 1;
                }
                else
                {
                    employee.Birthdate = Convert.ToDateTime(bday);
                    employee.DateHired = Convert.ToDateTime(DateHired);


                    await EmployeeService.UpdateEmployee(employee);
                    await AddressService.UpdateAddress(_address);
                    await PayrollService.UpdatePayroll(_payroll);

                    //UPDATE EMPLOYMENT DATE
                    _employmentDate.EmpmentStatusId = employee.EmploymentStatusId;
                    _employmentDate.ProbationStartDate = Convert.ToDateTime(ProbStart);
                    _employmentDate.ProbationEndDate = Convert.ToDateTime(ProbEnd);
                    _employmentDate.CasualStartDate = Convert.ToDateTime(CasualStart);
                    _employmentDate.CasualEndDate = Convert.ToDateTime(CasualEnd);
                    _employmentDate.FixedStartDate = Convert.ToDateTime(FixedStart);
                    _employmentDate.FixedEndDate = Convert.ToDateTime(FixedEnd);
                    _employmentDate.ProjStartDate = Convert.ToDateTime(ProjStart);
                    _employmentDate.ProjEndDate = Convert.ToDateTime(ProjEnd);
                    _employmentDate.RegularizationDate = Convert.ToDateTime(RegularDate);
                    _employmentDate.ResignationDate = Convert.ToDateTime(ResignationDate);
                    await EmploymentDateService.UpdateEmploymentDate(_employmentDate);

                    //UPDATE THE LAST EMPLOYEE HISTORY END and MODIFIED DATE
                    if (_updateposHistory.NewAreaId != employee.AreaId || _updateposHistory.NewDivisionId != employee.DivisionId || _updateposHistory.NewDepartmentId != employee.DepartmentId || _updateposHistory.NewSectionId != employee.SectionId || _updateposHistory.NewPositionId != employee.PositionId)
                    {
                        _updateposHistory.DateModified = DateTime.Now;
                        _updateposHistory.DateEnded = DateTime.Now;
                        await EmpHistoryService.UpdateEmpHistory(_updateposHistory);

                        //CREATE EMPLOYEE HISTORY
                        empHistory.Verify_Id = VerifyCode;
                        empHistory.Id = 0;
                        empHistory.DateStarted = DateTime.Now;
                        empHistory.NewAreaId = employee.AreaId;
                        empHistory.NewDivisionId = employee.DivisionId;
                        empHistory.NewDepartmentId = employee.DepartmentId;
                        empHistory.NewSectionId = employee.SectionId;
                        empHistory.NewPositionId = employee.PositionId;
                        foreach (var item in SubPositionsL)
                        {
                            if (item.Id == employee.PositionId)
                            {
                                empHistory.newPositionCode = item.PosCode;
                            }
                        }
                        var saveemphistory = await EmpHistoryService.CreateEmpHistory(empHistory);
                    }

                    //UPDATE SUB POSITION INACTIVE EMPLOYEE
                    _subposition.Status = "Inactive";
                    _subposition.InActiveDate = employee.DateInactiveStatus;
                    await PositionService.UpdateSubPosition(_subposition);




                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);
                    _toastService.ShowSuccess("Information updated successfully!");

                    //NavigationManager.NavigateTo($"employee/edit/{employee.Id}", true);
                    employee = await EmployeeService.GetSingleEmployee((int)id);
                    _address = await AddressService.GetSingleAddress((int)id);
                    _payroll = await PayrollService.GetSinglePayroll((int)id);
                    _updateposHistory = await EmpHistoryService.GetEmpLastHistory(VerifyCode);
                    //_empPicture = await ImageService.GetSingleImage((int)id);
                    _employmentDate = await EmploymentDateService.GetSingleEmploymentDate((int)id);

                    personalandjobOpen = false;
                    workInfoOpen = false;
                    emerOpen = false;
                    addressOpen = false;
                    documentsOpen = false;
                    ScheduleOpen = false;
                    StatutoryOpen = false;
                    StateHasChanged();
                }
            }
            else
            {
                employee.Birthdate = Convert.ToDateTime(bday);
                employee.DateHired = Convert.ToDateTime(DateHired);

                await EmployeeService.UpdateEmployee(employee);
                await AddressService.UpdateAddress(_address);
                await PayrollService.UpdatePayroll(_payroll);

                //UPDATE EMPLOYMENT DATE
                _employmentDate.EmpmentStatusId = employee.EmploymentStatusId;
                _employmentDate.ProbationStartDate = Convert.ToDateTime(ProbStart);
                _employmentDate.ProbationEndDate = Convert.ToDateTime(ProbEnd);
                _employmentDate.CasualStartDate = Convert.ToDateTime(CasualStart);
                _employmentDate.CasualEndDate = Convert.ToDateTime(CasualEnd);
                _employmentDate.FixedStartDate = Convert.ToDateTime(FixedStart);
                _employmentDate.FixedEndDate = Convert.ToDateTime(FixedEnd);
                _employmentDate.ProjStartDate = Convert.ToDateTime(ProjStart);
                _employmentDate.ProjEndDate = Convert.ToDateTime(ProjEnd);
                _employmentDate.RegularizationDate = Convert.ToDateTime(RegularDate);
                _employmentDate.ResignationDate = Convert.ToDateTime(ResignationDate);
                await EmploymentDateService.UpdateEmploymentDate(_employmentDate);

                //UPDATE THE LAST EMPLOYEE HISTORY END and MODIFIED DATE
                if (_updateposHistory.NewAreaId != employee.AreaId || _updateposHistory.NewDivisionId != employee.DivisionId || _updateposHistory.NewDepartmentId != employee.DepartmentId || _updateposHistory.NewSectionId != employee.SectionId || _updateposHistory.NewPositionId != employee.PositionId)
                {
                    _updateposHistory.DateModified = DateTime.Now;
                    _updateposHistory.DateEnded = DateTime.Now;
                    await EmpHistoryService.UpdateEmpHistory(_updateposHistory);

                    //CREATE EMPLOYEE HISTORY
                    empHistory.Verify_Id = VerifyCode;
                    empHistory.Id = 0;
                    empHistory.DateStarted = DateTime.Now;
                    empHistory.NewAreaId = employee.AreaId;
                    empHistory.NewDivisionId = employee.DivisionId;
                    empHistory.NewDepartmentId = employee.DepartmentId;
                    empHistory.NewSectionId = employee.SectionId;
                    empHistory.NewPositionId = employee.PositionId;
                    foreach (var item in SubPositionsL)
                    {
                        if (item.Id == employee.PositionId)
                        {
                            empHistory.newPositionCode = item.PosCode;
                        }
                    }
                    var saveemphistory = await EmpHistoryService.CreateEmpHistory(empHistory);


                    var newList = await EmpHistoryService.GetEmpHistoryList(VerifyCode);
                    StateService.SetState("HistoryPosList", newList);
                }

                //UPDATE SUB POSITION
                if (employee.PositionId == _subposition.Id)
                {
                    
                }
                else
                {
                    _subposition.Status = "Inactive";
                    _subposition.Emp_VerifyId = string.Empty;
                    _subposition.ActiveDate = null;
                    await PositionService.UpdateSubPosition(_subposition);

                    _newsubposition = await PositionService.GetSingleSubPosition(employee.PositionId);
                    _newsubposition.Status = "Active";
                    _newsubposition.Emp_VerifyId = employee.Verify_Id;
                    _newsubposition.ActiveDate = DateTime.Now;
                    await PositionService.UpdateSubPosition(_newsubposition);
                    _subposition = await PositionService.GetSingleSubPosition(employee.PositionId);
                    await PositionService.GetSubPosition();
                    SubPositionsL = PositionService.SubPositionTs;
                }
               

                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);
                _toastService.ShowSuccess("Information updated successfully!");

                //NavigationManager.NavigateTo($"employee/edit/{employee.Id}", true);
                employee = await EmployeeService.GetSingleEmployee((int)id);
                _address = await AddressService.GetSingleAddress((int)id);
                _payroll = await PayrollService.GetSinglePayroll((int)id);
                _updateposHistory = await EmpHistoryService.GetEmpLastHistory(VerifyCode);
                //_empPicture = await ImageService.GetSingleImage((int)id);
                _employmentDate = await EmploymentDateService.GetSingleEmploymentDate((int)id);

                personalandjobOpen = false;
                workInfoOpen = false;
                emerOpen = false;
                addressOpen = false;
                documentsOpen = false;
                ScheduleOpen = false;
                StatutoryOpen = false;
                StateHasChanged();
            }
        }

        #region Image Update
        private string imgBase64 { get; set; }
        private string ImageUrl { get; set; }
        private string ImgFileName { get; set; }
        private string ImgContentType { get; set; }

        MultipartFormDataContent EmpImage = new();
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

                await OnsavingImg(employee.EmployeeNo, employee.DivisionId, employee.DepartmentId, employee.LastName, employee.Verify_Id);


            }
        }

        private async Task OnsavingImg(string EmployeeId, int division, int department, string lastname, string verify)
        {
            using var _contentImg = new MultipartFormDataContent
            {
                EmpImage.LastOrDefault()
            };
            await ImageService.AttachFile(_contentImg, EmployeeId, division, department, lastname, verify);
            await EmployeeImg(employee.Verify_Id);//image
        }
        #endregion

        public async Task DeleteEmployee(int id)
        {
            var result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Do you really want to delete the record?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"
            });

            if (result.IsConfirmed)
            {
                await AddressService.DeleteAddress(id);
                await PayrollService.DeletePayroll(id);
                await EmployeeService.DeleteEmployee(id);
                await EducationService.DeleteCollege(id);
                await EducationService.DeleteDoctorate(id);
                await EducationService.DeleteMasteral(id);
                await EducationService.DeleteOtherEduc(id);
                await EducationService.DeletePrimary(id);
                await EducationService.DeleteSecondary(id);
                await EducationService.DeleteSHS(id);
                await LicenseTrainingService.DeleteLicense(id);
                await LicenseTrainingService.DeleteTraining(id);

                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
                await BackUpDeletion.CreateBackUp(employee);
                NavigationManager.NavigateTo("/employee");

                _toastService.ShowSuccess("Deleted Successfully!");
            }
        }

        #region MUDTABS
        MudTabs tabs;
        private string slectClasss = "frmselect";
        #endregion

        #region PERSONAL TAB ERROR TRAP
        private string slectClasssGender = "frmselect";
        private string slectClasssRela = "frmselect";
        private string txfieldClasssMN = "txf";
        private string txfieldClasssEN = "txf1";
        private string txfieldClasssEA = "txf1";
        private string txfieldClasssEMN = "txf";
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

        #region FUNCTIONS / BUTTONS
        private void OpenPdf(string name)
        {
            TokenSetGet.Set_Employeemodel(employee);
            var options = new DialogOptions { CloseOnEscapeKey = true, MaxWidth = MaxWidth.Large, FullWidth = true };
            var parameters = new DialogParameters<PDFDialog>
            {
                { x => x.fileName, name }
            };

            DialogService.Show<PDFDialog>("", parameters, options);
        }

        private async Task PDFImage(string verifyCode, string EmployeeId)
        {
            var PdfmodelList = await ImageService.GetPDFData(verifyCode, EmployeeId);
            if (PdfmodelList != null && PdfmodelList.Count > 0)
            {
                foreach (var Pdfmodel in PdfmodelList)
                {
                    var base64 = Convert.ToBase64String(Pdfmodel);
                    var dataUrl = string.Format("data:application/pdf;base64,{0}", base64);
                    PDFDataList.Add(dataUrl);
                }
            }
            Console.WriteLine(PDFDataList.Count);
        }

        private async void RefreshPdfFileList()
        {
            await ImageService.GetNewPDF(employee.Verify_Id, employee.EmployeeNo);
            pdffileList = ImageService.DocumentTs;
            StateHasChanged();
        }

        private async Task CopyToClipboard(string text) => await JSRuntime.InvokeVoidAsync("copyToClipboard", text);

        private static string FUpper(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }

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
                //Console.WriteLine($"2nd Test: {verifyCode}");
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
        //bool success;
        //private void OnValidSubmit(EditContext context)
        //{
        //    success = true;
        //    StateHasChanged();
        //}


        void Backbtn() => NavigationManager.NavigateTo("/employee");
        #endregion

    }
}
