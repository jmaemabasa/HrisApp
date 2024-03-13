using Microsoft.Reporting.NETCore;
using System.Data;
using System.Text;

namespace HrisApp.Server.Controllers.ReportsC
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _context;

        public ReportController(IWebHostEnvironment webHostEnvironment, DataContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [HttpGet("GetReport")]
        public async Task<IActionResult> GetReport([FromQuery] string verid)
        {
            var sortedList = await _context.EmployeeT
                .Include(em => em.Status)
                .Include(em => em.EmploymentStatus)
                .Include(em => em.EmerRelationship)
                .Include(em => em.Gender)
                .Include(em => em.CivilStatus)
                .Include(em => em.Religion)
                .Include(em => em.Division)
                .Include(em => em.Department)
                .Include(em => em.Area)
                .Where(x => x.Verify_Id == verid).ToListAsync();

            var sortedPayroll = await _context.Emp_PayrollT
                .Include(em => em.Cashbond)
                .Include(em => em.RateType)
                .Where(x => x.Verify_Id == verid).ToListAsync();

            var sortedAddress = await _context.Emp_AddressT.Where(x => x.Verify_Id == verid).ToListAsync();
            var sortedProfbg = await _context.Emp_ProfBackgroundT.Where(x => x.Verify_Id == verid).OrderByDescending(x => x.DateTo).ToListAsync();
            var sortedPrimary = await _context.Emp_PrimaryT.Where(x => x.Verify_Id == verid).ToListAsync();
            var sortedSecondary = await _context.Emp_SecondaryT.Where(x => x.Verify_Id == verid).ToListAsync();
            var sortedSenior = await _context.Emp_SeniorHST.Where(x => x.Verify_Id == verid).ToListAsync();
            var sortedCollege = await _context.Emp_CollegeT.Where(x => x.Verify_Id == verid).ToListAsync();
            var sortedMasteral = await _context.Emp_MasteralT.Where(x => x.Verify_Id == verid).ToListAsync();
            var sortedDoctorate = await _context.Emp_DoctorateT.Where(x => x.Verify_Id == verid).ToListAsync();
            var sortedOtherEduc = await _context.Emp_OtherEducT.Where(x => x.Verify_Id == verid).ToListAsync();
            var sortedLicense = await _context.Emp_LicenseT.Where(x => x.Verify_Id == verid).OrderByDescending(x => x.Date).ToListAsync();
            var sortedTraining = await _context.Emp_TrainingT.Where(x => x.Verify_Id == verid).OrderByDescending(x => x.TrainingDate).ToListAsync();
            var sortedPosHistory = await _context.Emp_PosHistoryT.Where(x => x.Verify_Id == verid).OrderByDescending(x => x.DateEnded).ToListAsync();

            string? agency = "";
            string biometricid = "";

            foreach (var item in sortedList)
            {
                string? subposcode = await _context.SubPositionT.Where(x => x.Id == item.PositionId).Select(x => x.PosCode).FirstOrDefaultAsync();

                int? posMPExternalId = await _context.PositionT
                   .Where(x => x.PosCode == subposcode)
                   .Select(x => x.PosMPExternalId)
                   .FirstOrDefaultAsync();

                if (posMPExternalId != null)
                {
                    agency = await _context.PosMPExternalT.Where(x => x.Id == posMPExternalId).Select(x => x.External_Name).FirstOrDefaultAsync();
                }
            }

            foreach (var item in sortedPayroll)
            {
                biometricid = item.BiometricID;
            }

            DataTable dt = await CreateDataTable(sortedList);
            DataTable dtpayroll = CreateDataTablePayroll(sortedPayroll);
            DataTable dtAddress = CreateDataTableAddress(sortedAddress);
            DataTable dtProfbg = CreateDataTableProfBg(sortedProfbg);
            DataTable dtPrimary = CreateDataTablePrimary(sortedPrimary);
            DataTable dtSecondary = CreateDataTableSecondary(sortedSecondary);
            DataTable dtSenior = CreateDataTableSenior(sortedSenior);
            DataTable dtCollege = CreateDataTableCollege(sortedCollege);
            DataTable dtMasteral = CreateDataTableMasteral(sortedMasteral);
            DataTable dtDoctorate = CreateDataTableDoctorate(sortedDoctorate);
            DataTable dtOtherEduc = CreateDataTableOtherEduc(sortedOtherEduc);
            DataTable dtLicense = CreateDataTableLicense(sortedLicense);
            DataTable dtTraining = CreateDataTableTraining(sortedTraining);
            DataTable dtPosHistory = await CreateDataTablePosHistory(sortedPosHistory);
            int extension = (int)(DateTime.Now.Ticks >> 10);
            var path = $"{this._webHostEnvironment.WebRootPath}\\EmpDetails\\EmpDetails1.rdlc";

            Dictionary<string, string> parameter = new()
            {
                { "param", "RDLC Report in Balzor" },
                { "datenow", DateTime.Now.ToString("dddd, MMM dd, yyyy") }
            };

            LocalReport localReport = new()
            {
                ReportPath = path
            };
            localReport.DataSources.Add(new ReportDataSource("dsEmployeeT", dt));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_PayrollT", dtpayroll));
            localReport.DataSources.Add(new ReportDataSource("dsAddressT", dtAddress));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_ProfBackgroundT", dtProfbg));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_PrimaryT", dtPrimary));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_SecondaryT", dtSecondary));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_SeniorHST", dtSenior));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_CollegeT", dtCollege));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_MasteralT", dtMasteral));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_DoctorateT", dtDoctorate));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_OtherEducT", dtOtherEduc));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_LicenseT", dtLicense));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_TrainingT", dtTraining));
            localReport.DataSources.Add(new ReportDataSource("dsEmp_PosHistoryT", dtPosHistory));
            localReport.SetParameters(new[]
            {
                new ReportParameter("param", "dfdfsd"),
                new ReportParameter("datenow", DateTime.Now.ToString("dddd, MMM dd, yyyy")),
                new ReportParameter("agency", agency),
                new ReportParameter("biometricid", biometricid),
            });
            byte[] pdf = localReport.Render("PDF");
            return File(pdf, "application/pdf");
        }

        public async Task<DataTable> CreateDataTable(List<EmployeeT> listEMPDetails)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("MiddleName");
            dt.Columns.Add("Extension");
            dt.Columns.Add("ContactNo");
            dt.Columns.Add("Height");
            dt.Columns.Add("Weight");
            dt.Columns.Add("Birthdate");
            dt.Columns.Add("Age");
            dt.Columns.Add("Nationality");
            dt.Columns.Add("Gender");
            dt.Columns.Add("CivilStatus");
            dt.Columns.Add("Religion");
            dt.Columns.Add("EmerName");
            dt.Columns.Add("EmerRelationship");
            dt.Columns.Add("EmerAddress");
            dt.Columns.Add("EmerMobNum");
            dt.Columns.Add("EmployeeNo");
            dt.Columns.Add("DateHired");
            dt.Columns.Add("EmploymentStatus");
            dt.Columns.Add("Area");
            dt.Columns.Add("Division");
            dt.Columns.Add("Department");
            dt.Columns.Add("Section");
            dt.Columns.Add("Position");
            dt.Columns.Add("Status");

            var sec = await _context.SectionT.ToListAsync();
            string sectionc = "";

            var pos = await _context.SubPositionT.ToListAsync();
            string position = "";

            foreach (var emp in listEMPDetails)
            {
                DateTime currentDate = DateTime.Today;
                int age = currentDate.Year - emp.Birthdate.Year;

                if (emp.Birthdate > currentDate.AddYears(-age))
                    age--;

                emp.Age = age;

                foreach (var item in sec)
                {
                    if (emp.SectionId == item.Id)
                    {
                        sectionc = item.Name;
                    }
                }
                foreach (var item in pos)
                {
                    if (item.Id == emp.PositionId)
                    {
                        position = item.Description;
                    }
                }

                myDataRow = dt.NewRow();
                myDataRow["FirstName"] = emp.FirstName;
                myDataRow["LastName"] = emp.LastName;
                myDataRow["MiddleName"] = emp.MiddleName;
                myDataRow["Extension"] = emp.Extension;
                myDataRow["ContactNo"] = emp.MobileNumber;
                myDataRow["Height"] = emp.Height;
                myDataRow["Weight"] = emp.Weight;
                myDataRow["Birthdate"] = emp.Birthdate.ToString("MM/dd/yyyy");
                myDataRow["Age"] = emp.Age;
                myDataRow["Nationality"] = emp.Nationality;
                myDataRow["Gender"] = emp.Gender?.Name;
                myDataRow["CivilStatus"] = emp.CivilStatus?.Name;
                myDataRow["Religion"] = emp.Religion?.Name;
                myDataRow["EmerName"] = emp.EmerName;
                myDataRow["EmerRelationship"] = emp.EmerRelationship?.Name;
                myDataRow["EmerAddress"] = emp.EmerAddress;
                myDataRow["EmerMobNum"] = emp.EmerMobNum;
                myDataRow["EmployeeNo"] = emp.EmployeeNo;
                myDataRow["DateHired"] = emp.DateHired.ToString("MM/dd/yyyy");
                myDataRow["EmploymentStatus"] = emp.EmploymentStatus?.Name;
                myDataRow["Area"] = emp.Area?.Name;
                myDataRow["Division"] = emp.Division?.Name;
                myDataRow["Department"] = emp.Department?.Name;
                myDataRow["Section"] = sectionc;
                myDataRow["Position"] = position;
                myDataRow["Status"] = emp.Status?.Name;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTablePayroll(List<Emp_PayrollT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("Rate");
            dt.Columns.Add("RateType");
            dt.Columns.Add("Cashbond");
            dt.Columns.Add("MealAllowance");
            dt.Columns.Add("BiometricID");
            dt.Columns.Add("BankAcc");
            dt.Columns.Add("TINNum");
            dt.Columns.Add("SSSNum");
            dt.Columns.Add("PhilHealthNum");
            dt.Columns.Add("HDMFNum");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["Rate"] = emp.Rate;
                myDataRow["RateType"] = emp.RateType?.Name;
                myDataRow["Cashbond"] = emp.Cashbond?.Name;
                myDataRow["MealAllowance"] = emp.MealAllowance;
                myDataRow["BiometricID"] = emp.BiometricID;
                myDataRow["BankAcc"] = emp.BankAcc;
                myDataRow["TINNum"] = emp.TINNum;
                myDataRow["SSSNum"] = emp.SSSNum;
                myDataRow["PhilHealthNum"] = emp.PhilHealthNum;
                myDataRow["HDMFNum"] = emp.HDMFNum;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTableAddress(List<Emp_AddressT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("CurrentAdd");
            dt.Columns.Add("CurrentCity");
            dt.Columns.Add("CurrentProvince");
            dt.Columns.Add("CurrentZipCode");
            dt.Columns.Add("CurrentCountry");
            dt.Columns.Add("PermanentAdd");
            dt.Columns.Add("PermanentCity");
            dt.Columns.Add("PermanentProvince");
            dt.Columns.Add("PermanentZipCode");
            dt.Columns.Add("PermanentCountry");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["CurrentAdd"] = emp.CurrentAdd;
                myDataRow["CurrentCity"] = emp.CurrentCity;
                myDataRow["CurrentProvince"] = emp.CurrentProvince;
                myDataRow["CurrentZipCode"] = emp.CurrentZipCode;
                myDataRow["CurrentCountry"] = emp.CurrentCountry;
                myDataRow["PermanentAdd"] = emp.PermanentAdd;
                myDataRow["PermanentCity"] = emp.PermanentCity;
                myDataRow["PermanentProvince"] = emp.PermanentProvince;
                myDataRow["PermanentZipCode"] = emp.PermanentZipCode;
                myDataRow["PermanentCountry"] = emp.PermanentCountry;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTableProfBg(List<Emp_ProfBackgroundT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("DateFrom");
            dt.Columns.Add("DateTo");
            dt.Columns.Add("CompanyName");
            dt.Columns.Add("Position");
            dt.Columns.Add("BasicSalary");
            dt.Columns.Add("RSLeaving");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["DateFrom"] = emp.DateFrom?.ToString("MM/dd/yyyy");
                myDataRow["DateTo"] = emp.DateTo?.ToString("MM/dd/yyyy");
                myDataRow["CompanyName"] = emp.CompanyName;
                myDataRow["Position"] = emp.Position;
                myDataRow["BasicSalary"] = emp.BasicSalary;
                myDataRow["RSLeaving"] = emp.RSLeaving;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTablePrimary(List<Emp_PrimaryT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("PriSchoolName");
            dt.Columns.Add("PriSchoolLoc");
            dt.Columns.Add("PriAward");
            dt.Columns.Add("PriSchoolYear");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["PriSchoolName"] = emp.PriSchoolName;
                myDataRow["PriSchoolLoc"] = emp.PriSchoolLoc;
                myDataRow["PriAward"] = emp.PriAward;
                myDataRow["PriSchoolYear"] = emp.PriSchoolYear;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTableSecondary(List<Emp_SecondaryT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("SecSchoolName");
            dt.Columns.Add("SecSchoolLoc");
            dt.Columns.Add("SecAward");
            dt.Columns.Add("SecSchoolYear");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["SecSchoolName"] = emp.SecSchoolName;
                myDataRow["SecSchoolLoc"] = emp.SecSchoolLoc;
                myDataRow["SecAward"] = emp.SecAward;
                myDataRow["SecSchoolYear"] = emp.SecSchoolYear;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTableCollege(List<Emp_CollegeT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("CollSchoolName");
            dt.Columns.Add("CollSchoolLoc");
            dt.Columns.Add("CollAward");
            dt.Columns.Add("CollSchoolYear");
            dt.Columns.Add("CollCourse");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["CollSchoolName"] = emp.CollSchoolName;
                myDataRow["CollSchoolLoc"] = emp.CollSchoolLoc;
                myDataRow["CollAward"] = emp.CollAward;
                myDataRow["CollSchoolYear"] = emp.CollSchoolYear;
                myDataRow["CollCourse"] = emp.CollCourse;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTableSenior(List<Emp_SeniorHST> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("ShsSchoolName");
            dt.Columns.Add("ShsSchoolLoc");
            dt.Columns.Add("ShsAward");
            dt.Columns.Add("ShsSchoolYear");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["ShsSchoolName"] = emp.ShsSchoolName;
                myDataRow["ShsSchoolLoc"] = emp.ShsSchoolLoc;
                myDataRow["ShsAward"] = emp.ShsAward;
                myDataRow["ShsSchoolYear"] = emp.ShsSchoolYear;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTableMasteral(List<Emp_MasteralT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("MasSchoolName");
            dt.Columns.Add("CollSchoolLoc");
            dt.Columns.Add("CollAward");
            dt.Columns.Add("CollSchoolYear");
            dt.Columns.Add("CollCourse");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["MasSchoolName"] = emp.MasSchoolName;
                myDataRow["MasSchoolLoc"] = emp.MasSchoolLoc;
                myDataRow["MasAward"] = emp.MasAward;
                myDataRow["MasSchoolYear"] = emp.MasSchoolYear;
                myDataRow["MasCourse"] = emp.MasCourse;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTableDoctorate(List<Emp_DoctorateT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("DocSchoolName");
            dt.Columns.Add("DocSchoolLoc");
            dt.Columns.Add("DocAward");
            dt.Columns.Add("DocSchoolYear");
            dt.Columns.Add("DocCourse");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["DocSchoolName"] = emp.DocSchoolName;
                myDataRow["DocSchoolLoc"] = emp.DocSchoolLoc;
                myDataRow["DocAward"] = emp.DocAward;
                myDataRow["DocSchoolYear"] = emp.DocSchoolYear;
                myDataRow["DocCourse"] = emp.DocCourse;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTableOtherEduc(List<Emp_OtherEducT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("OthersSchoolType");
            dt.Columns.Add("OthersSchoolName");
            dt.Columns.Add("OthersSchoolLoc");
            dt.Columns.Add("OthersAward");
            dt.Columns.Add("OthersSchoolYear");
            dt.Columns.Add("OthersCourse");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["OthersSchoolType"] = emp.OthersSchoolType;
                myDataRow["OthersSchoolName"] = emp.OthersSchoolName;
                myDataRow["OthersSchoolLoc"] = emp.OthersSchoolLoc;
                myDataRow["OthersAward"] = emp.OthersAward;
                myDataRow["OthersSchoolYear"] = emp.OthersSchoolYear;
                myDataRow["OthersCourse"] = emp.OthersCourse;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTableLicense(List<Emp_LicenseT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("Examination");
            dt.Columns.Add("LicenseNo");
            dt.Columns.Add("Rating");
            dt.Columns.Add("Date");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["Examination"] = emp.Examination;
                myDataRow["LicenseNo"] = emp.LicenseNo;
                myDataRow["Rating"] = emp.Rating;
                myDataRow["Date"] = emp.Date?.ToString("MM/dd/yyyy");

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public DataTable CreateDataTableTraining(List<Emp_TrainingT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("TrainingName");
            dt.Columns.Add("SponsorSpeaker");
            dt.Columns.Add("TrainingDate");

            foreach (var emp in obj)
            {
                myDataRow = dt.NewRow();
                myDataRow["TrainingName"] = emp.TrainingName;
                myDataRow["SponsorSpeaker"] = emp.SponsorSpeaker;
                myDataRow["TrainingDate"] = emp.TrainingDate?.ToString("MM/dd/yyyy");

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }

        public async Task<DataTable> CreateDataTablePosHistory(List<Emp_PosHistoryT> obj)
        {
            DataTable dt = new();
            //DataColumn dtColumn;
            DataRow myDataRow;

            var emarea = "";
            var emdep = "";
            var emsubpos = "";

            var departmentList = await _context.DepartmentT.ToListAsync();
            var areaList = await _context.AreaT.ToListAsync();
            var subposList = await _context.SubPositionT.ToListAsync();

            dt.Columns.Add("NewArea");
            dt.Columns.Add("NewDepartment");
            dt.Columns.Add("NewPosition");
            dt.Columns.Add("DateStarted");
            dt.Columns.Add("DateEnded");

            foreach (var emp in obj.Where(x => x.DateEnded != null))
            {
                foreach (var item in areaList)
                {
                    if (item.Id == emp.NewAreaId)
                    {
                        emarea = item.Name;
                    }
                }

                foreach (var item in departmentList)
                {
                    if (item.Id == emp.NewDepartmentId)
                    {
                        emdep = item.Name;
                    }
                }

                foreach (var item in subposList)
                {
                    if (item.Id == emp.NewPositionId)
                    {
                        emsubpos = item.Description;
                    }
                }

                myDataRow = dt.NewRow();
                myDataRow["NewArea"] = emarea;
                myDataRow["NewDepartment"] = emdep;
                myDataRow["NewPosition"] = emsubpos;
                myDataRow["DateStarted"] = emp.DateStarted?.ToString("MM/dd/yyyy");
                myDataRow["DateEnded"] = emp.DateEnded?.ToString("MM/dd/yyyy");

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }
    }
}