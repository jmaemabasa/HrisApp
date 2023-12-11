﻿using OfficeOpenXml;

namespace HrisApp.Client.ViewModel
{
    public class DTOEmpHeadcountExport
    {
        public async Task<byte[]> createExcelHeadcount(List<EmployeeT> crr, string cmbRangeDate)
        {
            await Task.Delay(1);
            List<EmployeeT> Denomination = crr;
            var package = new ExcelPackage();
            package.Workbook.Properties.Title = "EMPLOYEES";
            package.Workbook.Properties.Author = "SSDI";
            package.Workbook.Properties.Subject = "EMPLOYEES";
            package.Workbook.Properties.Keywords = "EMPLOYEES";

            var worksheet = package.Workbook.Worksheets.Add("EMPLOYEES");

            if (cmbRangeDate != null)
            {
                worksheet.Cells[1, 1].Value = "ACTIVE EMPLOYEE HEADCOUNT " + cmbRangeDate.ToUpper();
            }
            else if (cmbRangeDate == null)
            {
                worksheet.Cells[1, 1].Value = " ACTIVE EMPLOYEE HEADCOUNT AS OF TODAY - " + DateTime.Now.ToString("MMM dd, yyyy").ToUpper();
            }

            worksheet.Cells[1, 8].Value = "TOTAL EMPLOYEES: " + crr.Count();

            //First add the headers
            worksheet.Cells[2, 1].Value = "#";
            worksheet.Cells[2, 2].Value = "FULL NAME";
            worksheet.Cells[2, 3].Value = "ID NO.";
            worksheet.Cells[2, 4].Value = "DIVISION";
            worksheet.Cells[2, 5].Value = "DEPARTMENT";
            worksheet.Cells[2, 6].Value = "POSITION";
            worksheet.Cells[2, 7].Value = "AREA OF DESIGNATION";
            worksheet.Cells[2, 8].Value = "GENDER";
            worksheet.Cells[2, 9].Value = "DATE HIRED";
            //worksheet.Cells[2, 10].Value = "STATUS";

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
                worksheet.Cells[c, 8].Value = r.Gender?.Name;
                worksheet.Cells[c, 9].Value = r.DateHired.ToString("MM-dd-yyyy");
                //worksheet.Cells[c, 10].Value = r.Status?.Name;

                // Color the STATUS COLUMN based on the status
                //if (r.Status?.Name == "Active")
                //{
                //    worksheet.Cells[c, 12].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    worksheet.Cells[c, 12].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#AAC8A7"));
                //}
                //else if (r.Status?.Name == "Awol")
                //{
                //    worksheet.Cells[c, 12].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    worksheet.Cells[c, 12].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#888C4D"));
                //}
                //else if (r.Status?.Name == "Inactive")
                //{
                //    worksheet.Cells[c, 12].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    worksheet.Cells[c, 12].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#B7B7B7"));
                //}
                //else if (r.Status?.Name == "Terminated")
                //{
                //    worksheet.Cells[c, 12].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    worksheet.Cells[c, 12].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#E97777"));
                //}
                //else if (r.Status?.Name == "Retired")
                //{
                //    worksheet.Cells[c, 12].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    worksheet.Cells[c, 12].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#e0dfdc"));
                //}
                //else if (r.Status?.Name == "Resigned")
                //{
                //    worksheet.Cells[c, 12].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                //    worksheet.Cells[c, 12].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ebc878"));
                //}
                i++;
                c++;
            }

            //Merge
            worksheet.Cells["A1:G1"].Merge = true;
            worksheet.Cells["H1:I1"].Merge = true;

            //Alignment
            worksheet.Row(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            // Add background color to the cell
            worksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(OfficeOpenXml.Drawing.eThemeSchemeColor.Accent1);

            worksheet.Cells[1, 8].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[1, 8].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);

            //Font
            worksheet.Row(1).Style.Font.Size = 13;
            worksheet.Row(1).Style.Font.Bold = true;
            worksheet.Row(2).Style.Font.Size = 13;
            worksheet.Row(2).Style.Font.Bold = true;

            //add to table / add summary row
            var maxrow = crr.Count() + 2;
            var crrTbl = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 2, fromCol: 1, toRow: maxrow, toColumn: 9), "data");
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