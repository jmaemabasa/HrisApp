using System.Text;
using Microsoft.Reporting.NETCore;
using System.Data;

namespace HrisApp.Server.Controllers.ReportsC
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainAssetReportController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _context;

        public MainAssetReportController(IWebHostEnvironment webHostEnvironment, DataContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [HttpGet("GetReport")]
        public async Task<IActionResult> GetReport([FromQuery] int assetid)
        {
            var assetmaster = await _context.AssetMasterT
               .Include(e => e.AssetStatus)
               .Include(e => e.Category)
               .Include(e => e.SubCategory)
               .Include(e => e.Type)
               .Include(e => e.Employee)
               .Include(e => e.Employee!.Division)
               .Include(e => e.Employee!.Department)
               .Include(e => e.Area)
               .Include(e => e.CreatedBy)
               .FirstOrDefaultAsync(e => e.Id == assetid);

            var accessories = await _context.MainAssetAccessoriesT.Where(e => e.AssetMasterId == assetid)
                .Include(e => e.AssetAccessory)
                .ToListAsync();
            var licenses = await _context.MainAssetLicensesT.Where(e => e.AssetMasterId == assetid)
                .Include(e => e.AssetLicense)
                .ToListAsync();

            DataTable dt = CreateDataTableMainAss(assetmaster!);
            DataTable dtaccessories = CreateDataTableAccess(accessories);
            DataTable dtLicenses = CreateDataTableLicense(licenses);
            int extension = (int)(DateTime.Now.Ticks >> 10);
            var path = $"{this._webHostEnvironment.WebRootPath}\\AssetMaster\\MainAssetReport.rdlc";

            LocalReport localReport = new()
            {
                ReportPath = path
            };
            localReport.DataSources.Add(new ReportDataSource("dsAss_AssetMasterT", dt));
            localReport.DataSources.Add(new ReportDataSource("dsAss_AccessoryT", dtaccessories));
            localReport.DataSources.Add(new ReportDataSource("dsAss_LicenseT", dtLicenses));

            double TOTALLICENSESAMOUNT=0;
            double TOTALACCESSAMOUNT=0;
            double TOTALAMOUNT=0;
            
            TOTALLICENSESAMOUNT = licenses
                    .Select(x => ConvertToDouble(x.AssetLicense!.PurchaseAmount))
                    .Sum();
             TOTALACCESSAMOUNT = accessories
                    .Select(x => ConvertToDouble(x.AssetAccessory!.PurchaseAmount))
                    .Sum();
             TOTALAMOUNT = TOTALACCESSAMOUNT + TOTALLICENSESAMOUNT + ConvertToDouble(assetmaster.PurchaseAmount);

            localReport.SetParameters(new[]
           {
                new ReportParameter("paramDatenow", DateTime.Now.ToString("dddd, MMM dd, yyyy")),
                new ReportParameter("paramTotalAmount", TOTALAMOUNT.ToString("N2")),
                new ReportParameter("paramTotalAccessA", TOTALACCESSAMOUNT.ToString("N2")),
                new ReportParameter("paramTotalLicenA", TOTALLICENSESAMOUNT.ToString("N2")),
            });

            byte[] pdf = localReport.Render("PDF");
            return File(pdf, "application/pdf");
        }

        public DataTable CreateDataTableMainAss(AssetMasterT mainAsset)
        {
            DataTable dt = new();
            DataRow myDataRow;

            dt.Columns.Add("AssetCode");
            dt.Columns.Add("Name");
            dt.Columns.Add("Brand");
            dt.Columns.Add("Model");
            dt.Columns.Add("Description");
            dt.Columns.Add("Type");
            dt.Columns.Add("Category");
            dt.Columns.Add("SubCategory");
            dt.Columns.Add("Area");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Serial");
            dt.Columns.Add("DeviceID");
            dt.Columns.Add("ProductID");
            dt.Columns.Add("Processor");
            dt.Columns.Add("RAM");
            dt.Columns.Add("Storage");
            dt.Columns.Add("StorageType");
            dt.Columns.Add("MacAddress");
            dt.Columns.Add("PurchaseDate");
            dt.Columns.Add("PurchaseAmount");
            dt.Columns.Add("EUF");
            dt.Columns.Add("Employee");
            dt.Columns.Add("EmpDivDep");
            dt.Columns.Add("AssignedDateReleased");
            dt.Columns.Add("AssetStatus");
            dt.Columns.Add("UsernameAdmin");
            dt.Columns.Add("PasswordAdmin");
            dt.Columns.Add("ClientIP");

            myDataRow = dt.NewRow();
            myDataRow["AssetCode"] = mainAsset.AssetCode;
            myDataRow["Name"] = mainAsset.Name;
            myDataRow["Brand"] = mainAsset.Brand;
            myDataRow["Model"] = mainAsset.Model;
            myDataRow["Description"] = mainAsset.Description;
            myDataRow["Type"] = mainAsset.Type?.AType_Name;
            myDataRow["Category"] = mainAsset.Category?.ACat_Name;
            myDataRow["SubCategory"] = mainAsset.SubCategory?.ASubCat_Name;
            myDataRow["Area"] = mainAsset.Area?.Name;
            myDataRow["Quantity"] = mainAsset.Quantity;
            myDataRow["Serial"] = mainAsset.Serial;
            myDataRow["DeviceID"] = mainAsset.DeviceID;
            myDataRow["ProductID"] = mainAsset.ProductID;
            myDataRow["Processor"] = mainAsset.Processor;
            myDataRow["RAM"] = mainAsset.RAM;
            myDataRow["Storage"] = mainAsset.Storage;
            myDataRow["StorageType"] = mainAsset.StorageType;
            myDataRow["MacAddress"] = mainAsset.MacAddress;
            myDataRow["PurchaseDate"] = mainAsset.PurchaseDate?.ToString("MMM dd yyyy");
            myDataRow["PurchaseAmount"] = ConvertToDouble(mainAsset.PurchaseAmount).ToString("N2");
            myDataRow["EUF"] = string.IsNullOrEmpty(mainAsset.EUF) ? "0 Month" : mainAsset.EUF + " Months";
            myDataRow["Employee"] = mainAsset.Employee?.FirstName + " " + mainAsset.Employee?.LastName;
            myDataRow["EmpDivDep"] = mainAsset.Employee?.Division?.Name + " / " + mainAsset.Employee?.Department?.Name;
            myDataRow["AssignedDateReleased"] = mainAsset.AssignedDateReleased?.ToString("MMM dd yyyy");
            myDataRow["AssetStatus"] = mainAsset.AssetStatus?.Name;
            myDataRow["UsernameAdmin"] = mainAsset.UsernameAdmin;
            myDataRow["PasswordAdmin"] = mainAsset.PasswordAdmin;
            myDataRow["ClientIP"] = mainAsset.ClientIP;

            dt.Rows.Add(myDataRow);
            return dt;
        }

        public DataTable CreateDataTableAccess(List<MainAssetAccessoriesT> accessL)
        {
            DataTable dt = new();
            DataRow myDataRow;

            dt.Columns.Add("AssetCode");
            dt.Columns.Add("Name");
            dt.Columns.Add("PurchaseOn");
            dt.Columns.Add("Amount");

            foreach (var item in accessL)
            {
                myDataRow = dt.NewRow();
                myDataRow["AssetCode"] = item.AssetAccessory?.AssetCode;
                myDataRow["Name"] = item.AssetAccessory?.Name;
                myDataRow["PurchaseOn"] = item.AssetAccessory?.PurchaseDate?.ToString("MMM dd yyyy");
                myDataRow["Amount"] = ConvertToDouble(item.AssetAccessory!.PurchaseAmount).ToString("N2");

                dt.Rows.Add(myDataRow);
            }
            return dt;
        }

        public DataTable CreateDataTableLicense(List<MainAssetLicensesT> licenseL)
        {
            DataTable dt = new();
            DataRow myDataRow;

            dt.Columns.Add("AssetCode");
            dt.Columns.Add("Name");
            dt.Columns.Add("PurchaseOn");
            dt.Columns.Add("Amount");

            foreach (var item in licenseL)
            {
                myDataRow = dt.NewRow();
                myDataRow["AssetCode"] = item.AssetLicense?.AssetCode;
                myDataRow["Name"] = item.AssetLicense?.Name;
                myDataRow["PurchaseOn"] = item.AssetLicense?.PurchaseDate?.ToString("MMM dd yyyy");
                myDataRow["Amount"] = ConvertToDouble(item.AssetLicense!.PurchaseAmount).ToString("N2");

                dt.Rows.Add(myDataRow);
            }
            return dt;
        }

        // Helper method to convert varchar purchase amount to double
        private double ConvertToDouble(string purchaseAmount)
        {
            if (string.IsNullOrEmpty(purchaseAmount))
            {
                // Return 0 if the purchase amount is null or empty
                return 0;
            }

            // Remove commas and parse the string to double
            if (double.TryParse(purchaseAmount.Replace(",", ""), out double result))
            {
                return result;
            }
            else
            {
                return 0;
            }
        }
    }
}