using OfficeOpenXml;

namespace HrisApp.Client.ViewModel.Templates
{
    public class AttendanceImportTemplate
    {
        public async Task<byte[]> DownloadAttendanceTemplate()
        {
            await Task.Delay(100);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new();
            {
                package.Workbook.Properties.Title = "ATTENDANCE DATA TEMPLATE";
                package.Workbook.Properties.Author = "SSDI";
                package.Workbook.Properties.Subject = "Outlet uploader";
                package.Workbook.Properties.Keywords = "Export";

                var worksheet = package.Workbook.Worksheets.Add("Attendance_Template");

                //SETTING CPLUMN VALUES
                worksheet.Cells[1, 1].Value = "AC-No.";
                worksheet.Cells[1, 2].Value = "Name";
                worksheet.Cells[1, 3].Value = "Time";
                worksheet.Cells[1, 4].Value = "State";
                worksheet.Cells[1, 5].Value = "New State";
                worksheet.Cells[1, 6].Value = "Exception";
                worksheet.Cells[1, 7].Value = "Operation";

                //Font
                worksheet.Row(1).Style.Font.Size = 13;
                worksheet.Row(1).Style.Font.Bold = true;

                worksheet.Cells[1, 1, worksheet.Dimension.Rows, 7].AutoFitColumns();

            };
            return package.GetAsByteArray();
        }
    }
}
