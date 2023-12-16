using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [Route("GetReport")]
        public async Task<IActionResult> GetReport([FromQuery]string verid)
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
                .Include(em => em.Position)
                .Where(x => x.Verify_Id == verid).ToListAsync();

            DataTable dt = CreateDataTable(sortedList);
            int extension = (int)(DateTime.Now.Ticks >> 10);
            var path = $"{this._webHostEnvironment.WebRootPath}\\EmpDetails\\EmpDetails1.rdlc";

            Dictionary<string, string> parameter = new Dictionary<string, string>();
            parameter.Add("param", "RDLC Report in Balzor");
            parameter.Add("datenow", DateTime.Now.ToString("dddd, MMM dd, yyyy"));

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = path;
            localReport.DataSources.Add(new ReportDataSource("dsEmployeeT", dt));
            localReport.SetParameters(new[]
            {
                new ReportParameter("param", "dfdfsd"),
                new ReportParameter("datenow", DateTime.Now.ToString("dddd, MMM dd, yyyy"))
            });
            byte[] pdf = localReport.Render("PDF");
            return File(pdf, "application/pdf");
        }

        public DataTable CreateDataTable(List<EmployeeT> listEMPDetails)
        {
            DataTable dt = new DataTable();
            //DataColumn dtColumn;
            DataRow myDataRow;

            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("MiddleName");
            dt.Columns.Add("Extension");
            dt.Columns.Add("Height");
            dt.Columns.Add("Weight");
            dt.Columns.Add("Birthdate");
            dt.Columns.Add("Nationality");
            dt.Columns.Add("Gender");
            dt.Columns.Add("CivilStatus");
            dt.Columns.Add("Religion");

            foreach (var emp in listEMPDetails)
            {
                myDataRow = dt.NewRow();
                myDataRow["FirstName"] = emp.FirstName;
                myDataRow["LastName"] = emp.LastName;
                myDataRow["MiddleName"] = emp.MiddleName;
                myDataRow["Extension"] = emp.Extension;
                myDataRow["Height"] = emp.Height;
                myDataRow["Weight"] = emp.Weight;
                myDataRow["Birthdate"] = emp.Birthdate;
                myDataRow["Nationality"] = emp.Nationality;
                myDataRow["Gender"] = emp.Gender?.Name;
                myDataRow["CivilStatus"] = emp.CivilStatus?.Name;
                myDataRow["Religion"] = emp.Religion?.Name;

                dt.Rows.Add(myDataRow);
            }

            return dt;
        }
    }
}
