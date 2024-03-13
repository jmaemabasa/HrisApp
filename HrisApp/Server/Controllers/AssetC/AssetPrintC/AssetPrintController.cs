using Microsoft.Reporting.NETCore;
using QRCoder;
using System.Text;

namespace HrisApp.Server.Controllers.AssetC.AssetPrintC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetPrintController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DataContext _context;

        public AssetPrintController(IWebHostEnvironment webHostEnvironment, DataContext context)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            System.Text.Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [HttpGet("QRPrintMain")]
        public async Task<IActionResult> GetReport([FromQuery] string AssetCode)
        {
            var MasterList = await _context.AssetMasterT.Include(e => e.AssetStatus)
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.Employee)
                .Include(e => e.Employee!.Division)
                .Include(e => e.Employee!.Department)
                .Include(e => e.Area)
                .ToListAsync();

            var sortlist = MasterList.Where(e => e.AssetCode.Equals(AssetCode)).FirstOrDefault();

            byte[] qrCodeBytes = GenerateQRCode($"http://sonicsales.net:1112/main-asset/details/{sortlist?.Id}");

            if (qrCodeBytes == null)
            {
                return StatusCode(500, "Failed to generate QR code");
            }

            string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);

            var path = $"{this._webHostEnvironment.WebRootPath}\\EmpDetails\\PrintAssetQR.rdlc";

            var reportParameters = new List<ReportParameter>
        {
            new ReportParameter("ImgQR", qrCodeBase64)
        };

            byte[] pdfBytes = await RenderReportWithParameters(reportParameters);

            return File(pdfBytes, "application/pdf");
        }

        private async Task<byte[]> RenderReportWithParameters(List<ReportParameter> parameters)
        {
            // Path to your RDLC report file
            string reportPath = Path.Combine(_webHostEnvironment.WebRootPath, "EmpDetails", "PrintAssetQR.rdlc");

            // Create a local report object
            var localReport = new LocalReport();
            localReport.ReportPath = reportPath;

            // Set the report parameters
            localReport.SetParameters(parameters);

            // Render the report as PDF
            return await Task.Run(() => localReport.Render("PDF"));
        }

        private byte[] GenerateQRCode(string content)
        {
            var qrGenerator = new QRCodeGenerator();
            var qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new PngByteQRCode(qrCodeData);
            return qrCode.GetGraphic(20);
        }

        [HttpGet("QRPrintAccess")]
        public async Task<IActionResult> QRPrintAccess([FromQuery] string AssetCode)
        {
            var MasterList = await _context.AssetAccessoryT.Include(e => e.AssetStatus)
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .ToListAsync();

            var sortlist = MasterList.Where(e => e.AssetCode.Equals(AssetCode)).FirstOrDefault();

            byte[] qrCodeBytes = GenerateQRCode($"http://sonicsales.net:1112/asset-accessories/details/{sortlist?.Id}");

            if (qrCodeBytes == null)
            {
                return StatusCode(500, "Failed to generate QR code");
            }

            string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes);

            var path = $"{this._webHostEnvironment.WebRootPath}\\EmpDetails\\PrintAssetQR.rdlc";

            var reportParameters = new List<ReportParameter>
        {
            new ReportParameter("ImgQR", qrCodeBase64)
        };

            byte[] pdfBytes = await RenderReportWithParameters(reportParameters);

            return File(pdfBytes, "application/pdf");
        }
    }
}