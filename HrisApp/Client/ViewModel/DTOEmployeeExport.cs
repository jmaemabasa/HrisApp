using OfficeOpenXml;

namespace HrisApp.Client.ViewModel
{
    public class DTOEmployeeExport
    {
        public static string FullName = string.Empty;
        public static string IDno = string.Empty;
        public static string DateHired = string.Empty;
        public static string Status = string.Empty;

        public async Task<byte[]> createExcelPackage(List<EmployeeT> crr)
        {
            await Task.Delay(1);
            List<EmployeeT> Denomination = crr;
            var package = new ExcelPackage();
            package.Workbook.Properties.Title = "CRR";
            package.Workbook.Properties.Author = "SSDI";
            package.Workbook.Properties.Subject = "CRR";
            package.Workbook.Properties.Keywords = "CRR";

            var worksheet = package.Workbook.Worksheets.Add("EMPLOYEES");

            //First add the headers
            worksheet.Cells[1, 1].Value = "#";
            worksheet.Cells[1, 2].Value = "FULL NAME";
            worksheet.Cells[1, 3].Value = "ID NO.";
            worksheet.Cells[1, 4].Value = "DATE HIRED";
            worksheet.Cells[1, 5].Value = "STATUS";
            //add Value
            var numberFomat = "#,##0.00";
            var dataCellStyleName = "TableNumber";
            var numStyle = package.Workbook.Styles.CreateNamedStyle(dataCellStyleName);
            numStyle.Style.Numberformat.Format = numberFomat;
            int c = 6;
            int i = 1;

            foreach (var r in crr)
            {
                worksheet.Cells[c, 1].Value = i;
                worksheet.Cells[c, 2].Value = r.FirstName + r.MiddleName + r.LastName;
                worksheet.Cells[c, 3].Value = r.EmployeeNo;
                worksheet.Cells[c, 4].Value = r.DateHired.ToString("dd-MM-yyyy");
                worksheet.Cells[c, 5].Value = r.Status?.Name;
                i++;
                c++;
            }
           
            //Column width
            worksheet.Column(1).Width = 13;
            worksheet.Column(2).Width = 13;
            worksheet.Column(3).Width = 15;
            worksheet.Column(4).Width = 18;
            worksheet.Column(5).Width = 30;
            worksheet.Column(6).Width = 17;
            worksheet.Column(7).Width = 17;
            worksheet.Column(8).Width = 18;
            worksheet.Column(9).Width = 20;
            worksheet.Column(10).Width = 15;
            worksheet.Column(11).Width = 17;
            worksheet.Column(12).Width = 17;
            worksheet.Column(13).Width = 23;
            worksheet.Column(14).Width = 20;
            worksheet.Column(15).Width = 12;

            //Font
            worksheet.Row(1).Style.Font.Size = 13;
            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Row(2).Style.Font.Size = 13;
            worksheet.Row(2).Style.Font.Bold = true;
            worksheet.Row(3).Style.Font.Size = 13;
            worksheet.Row(3).Style.Font.Bold = true;
            worksheet.Row(4).Style.Font.Size = 13;
            worksheet.Row(4).Style.Font.Bold = true;
            worksheet.Row(5).Style.Font.Size = 13;
            worksheet.Row(5).Style.Font.Bold = true;

            //add to table / add summary row
            var crrTbl = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 5, fromCol: 1, toRow: 5, toColumn: 14), "data");
            crrTbl.ShowHeader = true;
            crrTbl.TableStyle = OfficeOpenXml.Table.TableStyles.Dark9;
            crrTbl.ShowTotal = true;
            //Autofilcolumn
            worksheet.Cells[1, 1, 2, 14].AutoFitColumns();
            return package.GetAsByteArray();
        }

    }
}
