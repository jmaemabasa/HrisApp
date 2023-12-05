using NPOI.OpenXmlFormats.Spreadsheet;
using OfficeOpenXml;

namespace HrisApp.Client.ViewModel
{
    public class DTOEmployeeExport
    {
        public async Task<byte[]> createExcelPackage(List<EmployeeT> crr)
        {
            await Task.Delay(1);
            List<EmployeeT> Denomination = crr;
            var package = new ExcelPackage();
            package.Workbook.Properties.Title = "EMPLOYEES";
            package.Workbook.Properties.Author = "SSDI";
            package.Workbook.Properties.Subject = "EMPLOYEES";
            package.Workbook.Properties.Keywords = "EMPLOYEES";

            var worksheet = package.Workbook.Worksheets.Add("EMPLOYEES");

            worksheet.Cells[1, 1].Value = "EMPLOYEES AS OF " + DateTime.Now.ToString("MM/dd/yyyy");

            //First add the headers
            worksheet.Cells[2, 1].Value = "#";
            worksheet.Cells[2, 2].Value = "FULL NAME";
            worksheet.Cells[2, 3].Value = "ID NO.";
            worksheet.Cells[2, 4].Value = "DIVISION";
            worksheet.Cells[2, 5].Value = "DEPARTMENT";
            worksheet.Cells[2, 6].Value = "POSITION";
            worksheet.Cells[2, 7].Value = "AREA OF DESIGNATION";
            worksheet.Cells[2, 8].Value = "DATE OF BIRTH";
            worksheet.Cells[2, 9].Value = "CONTACT NUMBER";
            worksheet.Cells[2, 10].Value = "DATE HIRED";
            worksheet.Cells[2, 11].Value = "STATUS";
            //add Value
            var numberFomat = "#,##0.00";
            var dataCellStyleName = "TableNumber";
            var numStyle = package.Workbook.Styles.CreateNamedStyle(dataCellStyleName);
            numStyle.Style.Numberformat.Format = numberFomat;
            int c = 3;
            int i = 1;

            foreach (var r in crr)
            {
                worksheet.Cells[c, 1].Value = i;
                worksheet.Cells[c, 2].Value = r.FirstName + " " + r.MiddleName + " " + r.LastName;
                worksheet.Cells[c, 3].Value = r.EmployeeNo;
                worksheet.Cells[c, 4].Value = r.Division?.Name;
                worksheet.Cells[c, 5].Value = r.Department?.Name;
                worksheet.Cells[c, 6].Value = r.Position?.Name;
                worksheet.Cells[c, 7].Value = r.Area?.Name;
                worksheet.Cells[c, 8].Value = r.Birthdate.ToString("MM-dd-yyyy");
                worksheet.Cells[c, 9].Value = r.MobileNumber;
                worksheet.Cells[c, 10].Value = r.DateHired.ToString("MM-dd-yyyy");
                worksheet.Cells[c, 11].Value = r.Status?.Name;
                i++;
                c++;
            }

            //Merge
            worksheet.Cells["A1:K1"].Merge = true;

            //Alignment
            worksheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            // Add background color to the cell
            worksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(OfficeOpenXml.Drawing.eThemeSchemeColor.Accent1);

            //Font
            worksheet.Row(1).Style.Font.Size = 13;
            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Row(2).Style.Font.Size = 13;
            worksheet.Row(2).Style.Font.Bold = true;

            //add to table / add summary row
            var maxrow = crr.Count() + 2;
            var crrTbl = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 2, fromCol: 1, toRow: maxrow, toColumn: 11), "data");
            crrTbl.ShowHeader = true;
            crrTbl.TableStyle = OfficeOpenXml.Table.TableStyles.Light16;
            //crrTbl.ShowTotal = true;
            //Autofilcolumn
            //worksheet.Cells[2, 1, 2, 11].AutoFitColumns();
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            return package.GetAsByteArray();
        }

    }
}
