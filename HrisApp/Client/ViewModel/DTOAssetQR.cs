using OfficeOpenXml;
using QRCoder;

namespace HrisApp.Client.ViewModel
{
    public class DTOAssetQR
    {
        public async Task<byte[]> createExcelPackage(string code)
        {
            await Task.Delay(1);
            List<AssetMasterT> assetlist = new();

            var package = new ExcelPackage();
            package.Workbook.Properties.Title = "EMPLOYEES";
            package.Workbook.Properties.Author = "SSDI";
            package.Workbook.Properties.Subject = "EMPLOYEES";
            package.Workbook.Properties.Keywords = "EMPLOYEES";

            var worksheet = package.Workbook.Worksheets.Add("EMPLOYEES");

            QRCodeGenerator qrGenerator = new();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);

            var qrCode = new PngByteQRCode(qrCodeData);

            byte[] imageByteArray = qrCode.GetGraphic(20);

            var base64Image = Convert.ToBase64String(imageByteArray);

            // Create an ExcelPicture object from the base64-encoded image
            //var excelImage = worksheet.Drawings.AddPicture("QRCode", new MemoryStream(Convert.FromBase64String(base64Image)));

            // Set the position of the image and anchor it to cell A1
            //excelImage.SetPosition(0, 0, 0, 0);
            //excelImage.SetSize(100, 100); // Set the size of the image

            // Set the value of cell A1 to empty since it's used for the image
            worksheet.Cells[1, 1].Value = "";

            // Adjust the column width to fit the image
            worksheet.Column(1).Width = 25;

            // Auto-fit other columns if needed
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            return package.GetAsByteArray();
        }
    }
}