using NPOI.OpenXmlFormats.Wordprocessing;
using OfficeOpenXml;

namespace HrisApp.Client.ViewModel
{
    public class DTOEmpHeadcountExport
    {
        public async Task<byte[]> createExcelHeadcount(List<EmployeeT> crr, string cmbRangeDate, List<SubPositionT> subpos)
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
            var position = "";

            foreach (var r in crr)
            {
                foreach (var item in subpos)
                {
                    if (item.Id == r.PositionId)
                    {
                        position = item.Description;
                    }
                }
                worksheet.Cells[c, 1].Value = i;
                worksheet.Cells[c, 2].Value = r.FirstName + " " + r.MiddleName + " " + r.LastName;
                worksheet.Cells[c, 3].Value = r.EmployeeNo;
                worksheet.Cells[c, 4].Value = r.Division?.Name;
                worksheet.Cells[c, 5].Value = r.Department?.Name;
                worksheet.Cells[c, 6].Value = position;
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


        public async Task<byte[]> createExcelPayrollAssists(List<EmployeeT> crr, List<SubPositionT> subpos)
        {
            await Task.Delay(1);
            List<EmployeeT> empList = crr;
            var package = new ExcelPackage();
            package.Workbook.Properties.Title = "EMPLOYEES";
            package.Workbook.Properties.Author = "SSDI";
            package.Workbook.Properties.Subject = "EMPLOYEES";
            package.Workbook.Properties.Keywords = "EMPLOYEES";

            var worksheet = package.Workbook.Worksheets.Add("WORK_INFORMATION");


            //Merge
            #region MERGE CELLS
            worksheet.Cells["A1:AR1"].Merge = true;
            worksheet.Cells["A2:AR2"].Merge = true;
            worksheet.Cells["A3:AR3"].Merge = true;
            worksheet.Cells["A4:A6"].Merge = true;
            worksheet.Cells["B4:B6"].Merge = true;
            worksheet.Cells["C4:E4"].Merge = true;
            worksheet.Cells["C5:C6"].Merge = true;
            worksheet.Cells["D5:D6"].Merge = true;
            worksheet.Cells["E5:E6"].Merge = true;
            worksheet.Cells["F4:F6"].Merge = true;
            worksheet.Cells["G4:G6"].Merge = true;
            worksheet.Cells["H4:O4"].Merge = true;
            worksheet.Cells["H5:H6"].Merge = true;
            worksheet.Cells["I5:I6"].Merge = true;
            worksheet.Cells["J5:J6"].Merge = true;
            worksheet.Cells["K5:K6"].Merge = true;
            worksheet.Cells["L5:L6"].Merge = true;
            worksheet.Cells["M5:M6"].Merge = true;
            worksheet.Cells["N5:N6"].Merge = true;
            worksheet.Cells["O5:O6"].Merge = true;
            worksheet.Cells["P4:Q4"].Merge = true;
            worksheet.Cells["P5:P6"].Merge = true;
            worksheet.Cells["Q5:Q6"].Merge = true;
            worksheet.Cells["R4:R6"].Merge = true;
            worksheet.Cells["S4:S6"].Merge = true;
            worksheet.Cells["T4:T6"].Merge = true;
            worksheet.Cells["U4:U6"].Merge = true;
            worksheet.Cells["V4:V6"].Merge = true;
            worksheet.Cells["W4:W6"].Merge = true;
            worksheet.Cells["X4:AH4"].Merge = true;
            worksheet.Cells["X5:Y5"].Merge = true;
            worksheet.Cells["Z5:AA5"].Merge = true;
            worksheet.Cells["AB5:AD5"].Merge = true;
            worksheet.Cells["AE5:AH5"].Merge = true;
            worksheet.Cells["AI4:AI6"].Merge = true;
            worksheet.Cells["AJ4:AJ6"].Merge = true;
            worksheet.Cells["AK4:AK6"].Merge = true;
            worksheet.Cells["AL4:AL6"].Merge = true;
            worksheet.Cells["AM4:AP4"].Merge = true;
            worksheet.Cells["AM5:AM6"].Merge = true;
            worksheet.Cells["AN5:AN6"].Merge = true;
            worksheet.Cells["AO5:AO6"].Merge = true;
            worksheet.Cells["AP5:AP6"].Merge = true;
            worksheet.Cells["AQ4:AQ6"].Merge = true;
            worksheet.Cells["AR4:AR6"].Merge = true;
            #endregion

            #region TEXT VALUES - TITLE
            worksheet.Cells[1, 1].Value = "EMPLOYEE MASTERFILE (Work Information) UPLOADING FACILITY";
            worksheet.Cells[3, 1].Value = "NOTE: Required fields are marked as red.";
            worksheet.Cells[4, 1].Value = "Company Code";

            var richText = worksheet.Cells[4, 2].RichText;
            var empNo = richText.Add("Employee No");
            empNo.Bold = true;
            empNo.Color = System.Drawing.Color.FromArgb(192, 0, 0); // red

            var maxChar = richText.Add("\n(Max. of 20 char.)");
            maxChar.Size = 8;
            maxChar.Color = System.Drawing.Color.Black;

            worksheet.Cells[4, 3].Value = "EMPLOYEE NAME (Optional)";
            worksheet.Cells[5, 3].Value = "LAST NAME";
            worksheet.Cells[5, 4].Value = "FIRST NAME";
            worksheet.Cells[5, 5].Value = "MIDDLE NAME";

            var richTextC6 = worksheet.Cells[4, 6].RichText;
            var c6 = richTextC6.Add("BIOMETRIC ID");
            c6.Bold = true;
            c6.Color = System.Drawing.Color.FromArgb(0, 176, 240); //BLUE

            var maxCharc6 = richTextC6.Add("\n(Numbers Only)");
            maxCharc6.Size = 8;
            maxCharc6.Color = System.Drawing.Color.Black;

            var richTextC7 = worksheet.Cells[4, 7].RichText;
            var c7 = richTextC7.Add("ACTIVE");
            c7.Bold = true;
            c7.Color = System.Drawing.Color.Black;

            var maxCharc7 = richTextC7.Add("\n(YES/NO)");
            maxCharc7.Size = 8;
            maxCharc7.Color = System.Drawing.Color.Black;

            worksheet.Cells[4, 8].Value = "SALARY INFORMATION";

            var richTextC8 = worksheet.Cells[5, 8].RichText;
            var c8 = richTextC8.Add("EMPLOYEE TYPE");
            c8.Bold = true;
            c8.Color = System.Drawing.Color.FromArgb(192, 0, 0); // red

            var maxCharc8 = richTextC8.Add("\n(Regular, Probationary, Contractual or Piece Rate)");
            maxCharc8.Size = 8;
            maxCharc8.Color = System.Drawing.Color.Black;

            worksheet.Cells[5, 9].Value = "SHIFT";

            var richTextC10 = worksheet.Cells[5, 10].RichText;
            var c10 = richTextC10.Add("REGULAR HOURS IN SHIFT");
            c10.Bold = true;
            c10.Color = System.Drawing.Color.FromArgb(192, 0, 0); // red

            var maxCharc10 = richTextC10.Add("\n(0 and Negative Value not Accepted)");
            maxCharc10.Size = 8;
            maxCharc10.Color = System.Drawing.Color.Black;

            var richTextC11 = worksheet.Cells[5, 11].RichText;
            var c11 = richTextC11.Add("WORKING DAYS IN A MONTH ");
            c11.Bold = true;
            c11.Color = System.Drawing.Color.FromArgb(192, 0, 0); // red

            var maxCharc11 = richTextC11.Add("\n(0 and Negative Value not Accepted)");
            maxCharc11.Size = 8;
            maxCharc11.Color = System.Drawing.Color.Black;

            var richTextC12 = worksheet.Cells[5, 12].RichText;
            var c12 = richTextC12.Add("Frequency");
            c12.Bold = true;
            c12.Color = System.Drawing.Color.FromArgb(192, 0, 0); // red

            var maxCharc12 = richTextC12.Add("\n(Monthly, Semi-Monthly or Weekly)");
            maxCharc12.Size = 8;
            maxCharc12.Color = System.Drawing.Color.Black;

            worksheet.Cells[5, 13].Value = "BASIC SALARY";

            var richTextC14 = worksheet.Cells[5, 14].RichText;
            var c14 = richTextC14.Add("RATE TYPE");
            c14.Bold = true;
            c14.Color = System.Drawing.Color.FromArgb(192, 0, 0); // red

            var maxCharc14 = richTextC14.Add("\n(Monthly, Daily or Hourly)");
            maxCharc14.Size = 8;
            maxCharc14.Color = System.Drawing.Color.Black;

            var richTextC15 = worksheet.Cells[5, 15].RichText;
            var c15 = richTextC15.Add("PAY TYPE");
            c15.Bold = true;
            c15.Color = System.Drawing.Color.FromArgb(192, 0, 0); // red

            var maxCharc15 = richTextC15.Add("\n(Cash or Bank)");
            maxCharc15.Size = 8;
            maxCharc15.Color = System.Drawing.Color.Black;

            worksheet.Cells[4, 16].Value = "POSITION / RANK";
            worksheet.Cells[5, 16].Value = "POSITION";
            worksheet.Cells[5, 17].Value = "RANK";
            worksheet.Cells[4, 18].Value = "Supervisor No";

            var richTextC19 = worksheet.Cells[4, 19].RichText;
            var c19 = richTextC19.Add("HIRED DATE");
            c19.Bold = true;
            c19.Color = System.Drawing.Color.FromArgb(192, 0, 0); // red

            var maxCharc19 = richTextC19.Add("\n(MM/DD/YYYY)");
            maxCharc19.Size = 8;
            maxCharc19.Color = System.Drawing.Color.Black;

            var richTextC20 = worksheet.Cells[4, 20].RichText;
            var c20 = richTextC20.Add("REGULARIZATION DATE");
            c20.Bold = true;
            c20.Color = System.Drawing.Color.FromArgb(0, 176, 240);

            var maxCharc20 = richTextC20.Add("\n(Applicable if 'Employee Type' is 'Regular') \n(MM / DD / YYYY)");
            maxCharc20.Size = 8;
            maxCharc20.Color = System.Drawing.Color.Black;

            var richTextC21 = worksheet.Cells[4, 21].RichText;
            var c21 = richTextC21.Add("RESIGNATION DATE");
            c21.Bold = true;
            c21.Color = System.Drawing.Color.FromArgb(0, 176, 240);

            var maxCharc21 = richTextC21.Add("\n(Applicable for inactive employees) \n(MM/DD/YYYY)");
            maxCharc21.Size = 8;
            maxCharc21.Color = System.Drawing.Color.Black;

            var richTextC22 = worksheet.Cells[4, 22].RichText;
            var c22 = richTextC22.Add("MINIMUM WAGE EARNER");
            c22.Bold = true;
            c22.Color = System.Drawing.Color.Black;

            var maxCharc22 = richTextC22.Add("\n(YES/NO)");
            maxCharc22.Size = 8;
            maxCharc22.Color = System.Drawing.Color.Black;

            var richTextC23 = worksheet.Cells[4, 23].RichText;
            var c23 = richTextC23.Add("ALLOW OVERTIME");
            c23.Bold = true;
            c23.Color = System.Drawing.Color.Black;

            var maxCharc23 = richTextC23.Add("\n(YES/NO)");
            maxCharc23.Size = 8;
            maxCharc23.Color = System.Drawing.Color.Black;

            worksheet.Cells[4, 24].Value = "DEDUCTION AND ALLOWANCE INFORMATION";
            worksheet.Cells[5, 24].Value = "SSS";
            worksheet.Cells[5, 26].Value = "PhilHealth";
            worksheet.Cells[5, 28].Value = "Pag-IBIG";
            worksheet.Cells[5, 31].Value = "BIR";

            var richTextC25 = worksheet.Cells[6, 25].RichText;
            var c25 = richTextC25.Add("EXEMPT");
            c25.Bold = true;
            c25.Color = System.Drawing.Color.Black;

            var maxCharc25 = richTextC25.Add("\n(YES/NO)");
            maxCharc25.Size = 8;
            maxCharc25.Color = System.Drawing.Color.Black;

            worksheet.Cells[6, 24].Value = "SSS NUMBER";
            worksheet.Cells[6, 26].Value = "PHIC NUMBER)";

            var richTextC27 = worksheet.Cells[6, 27].RichText;
            var c27 = richTextC27.Add("EXEMPT");
            c27.Bold = true;
            c27.Color = System.Drawing.Color.Black;

            var maxCharc27 = richTextC27.Add("\n(YES/NO)");
            maxCharc27.Size = 8;
            maxCharc27.Color = System.Drawing.Color.Black;

            var richTextC28 = worksheet.Cells[6, 28].RichText;
            var c28 = richTextC28.Add("HDMF");
            c28.Bold = true;
            c28.Color = System.Drawing.Color.Black;

            var maxCharc28 = richTextC28.Add("\n(Amount)");
            maxCharc28.Size = 8;
            maxCharc28.Color = System.Drawing.Color.Black;

            worksheet.Cells[6, 29].Value = "HDMF NUMBER";

            var richTextC30 = worksheet.Cells[6, 30].RichText;
            var c30 = richTextC30.Add("EXEMPT");
            c30.Bold = true;
            c30.Color = System.Drawing.Color.Black;

            var maxCharc30 = richTextC30.Add("\n(YES/NO)");
            maxCharc30.Size = 8;
            maxCharc30.Color = System.Drawing.Color.Black;

            worksheet.Cells[6, 31].Value = "TIN NUMBER";

            var richTextC32 = worksheet.Cells[6, 32].RichText;
            var c32 = richTextC32.Add("EXEMPT");
            c32.Bold = true;
            c32.Color = System.Drawing.Color.Black;

            var maxCharc32 = richTextC32.Add("\n(YES/NO)");
            maxCharc32.Size = 8;
            maxCharc32.Color = System.Drawing.Color.Black;

            worksheet.Cells[6, 33].Value = "TAX CODE";
            worksheet.Cells[6, 34].Value = "REGION NUMBER";

            var richTextC35 = worksheet.Cells[4, 35].RichText;
            var c35 = richTextC35.Add("APPLY CONSULTANT TAX RATE");
            c35.Bold = true;
            c35.Color = System.Drawing.Color.Black;

            var maxCharc35 = richTextC35.Add("\n(YES/NO)");
            maxCharc35.Size = 8;
            maxCharc35.Color = System.Drawing.Color.Black;

            var richTextC36 = worksheet.Cells[4, 36].RichText;
            var c36 = richTextC36.Add("FIXED TAX RATE (%)");
            c36.Bold = true;
            c36.Color = System.Drawing.Color.Black;

            var maxCharc36 = richTextC36.Add("\n(Mandatory if consultant tax rate is 'YES')");
            maxCharc36.Size = 8;
            maxCharc36.Color = System.Drawing.Color.Black;

            worksheet.Cells[4, 37].Value = "TAX SHIELD AMOUNT";

            var richTextC38 = worksheet.Cells[4, 38].RichText;
            var c38 = richTextC38.Add("HOLD");
            c38.Bold = true;
            c38.Color = System.Drawing.Color.Black;

            var maxCharc38 = richTextC38.Add("\n(YES/NO)");
            maxCharc38.Size = 8;
            maxCharc38.Color = System.Drawing.Color.Black;

            worksheet.Cells[4, 39].Value = "CLUSTER";
            worksheet.Cells[5, 39].Value = "TOP MANAGEMENT";
            worksheet.Cells[5, 40].Value = "DEPARTMENT";
            worksheet.Cells[5, 41].Value = "N / A";
            worksheet.Cells[5, 42].Value = "N / A";

            var richTextC43 = worksheet.Cells[4, 43].RichText;
            var c43 = richTextC43.Add("CONFIDENTIAL");
            c43.Bold = true;
            c43.Color = System.Drawing.Color.Black;

            var maxCharc43 = richTextC43.Add("\n(YES/NO)");
            maxCharc43.Size = 8;
            maxCharc43.Color = System.Drawing.Color.Black;

            var richTextC44 = worksheet.Cells[4, 44].RichText;
            var c44 = richTextC44.Add("OVERWRITE DATA");
            c44.Bold = true;
            c44.Color = System.Drawing.Color.FromArgb(192, 0, 0); // red

            var maxCharc44 = richTextC44.Add("\n(YES/NO)");
            maxCharc44.Size = 8;
            maxCharc44.Color = System.Drawing.Color.Black;

            worksheet.Cells["A7:E7"].Value = "Default";
            worksheet.Cells[7, 6].Value = "Timekeeping";
            worksheet.Cells[7, 7].Value = "Default";
            worksheet.Cells[7, 8].Value = "Default";
            worksheet.Cells[7, 9].Value = "Timekeeping";
            worksheet.Cells["J7:L7"].Value = "Default";
            worksheet.Cells[7, 13].Value = "Payroll";
            worksheet.Cells[7, 14].Value = "Default";
            worksheet.Cells[7, 15].Value = "Payroll";
            worksheet.Cells["P7:U7"].Value = "Default";
            worksheet.Cells[7, 22].Value = "Payroll";
            worksheet.Cells[7, 23].Value = "Default";
            worksheet.Cells["X7:AK7"].Value = "Payroll";
            worksheet.Cells["AL7:AR7"].Value = "Default";

            //WRAP TEXT
            worksheet.Row(4).Style.WrapText = true;
            worksheet.Row(5).Style.WrapText = true;
            worksheet.Row(6).Style.WrapText = true;
            #endregion

            //Font
            #region FONTS AND COLORS
            worksheet.Row(1).Style.Font.Size = 16;
            worksheet.Row(1).Style.Font.Bold = true;

            worksheet.Row(3).Style.Font.Size = 11;
            worksheet.Row(3).Style.Font.Bold = true;
            worksheet.Row(4).Style.Font.Bold = true;
            worksheet.Row(5).Style.Font.Bold = true;
            worksheet.Row(6).Style.Font.Bold = true;
            worksheet.Row(7).Style.Font.Size = 9;
            worksheet.Cells[3, 1].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[3, 1].Style.Font.Name = "Calibri";

            worksheet.Cells[4, 1].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[4, 2].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 8].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 10].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 11].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 12].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 13].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 14].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 15].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 16].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 17].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[4, 19].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[6, 33].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 39].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 40].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 41].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[5, 42].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));
            worksheet.Cells[4, 44].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(192, 0, 0));

            worksheet.Cells[4, 3].Style.Font.Italic = true;
            worksheet.Cells[4, 8].Style.Font.Italic = true;
            worksheet.Cells[4, 16].Style.Font.Italic = true;
            worksheet.Cells[4, 24].Style.Font.Italic = true;
            worksheet.Cells[4, 39].Style.Font.Italic = true;

            worksheet.Cells[4, 6].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(0, 176, 240));
            worksheet.Cells[5, 9].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(0, 176, 240));
            worksheet.Cells[4, 20].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(0, 176, 240));
            worksheet.Cells[4, 21].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(0, 176, 240));

            // Add background color to the cell
            worksheet.Cells[1, 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[1, 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(31, 73, 125));
            worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.White);
            worksheet.Cells[1, 1].Style.Font.Name = "Times New Roman";
            worksheet.Row(1).Height = 36;
            worksheet.Row(6).Height = 45;

            worksheet.Cells[4, 3].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[4, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(149, 179, 215));
            worksheet.Cells[4, 8].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[4, 8].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(149, 179, 215));
            worksheet.Cells[4, 16].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[4, 16].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(149, 179, 215));
            worksheet.Cells[4, 24].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[4, 24].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(149, 179, 215));
            worksheet.Cells[5, 24].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[5, 24].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(220, 230, 241));
            worksheet.Cells[5, 26].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[5, 26].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(220, 230, 241));
            worksheet.Cells[5, 28].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[5, 28].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(220, 230, 241));
            worksheet.Cells[5, 31].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[5, 31].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(220, 230, 241));
            worksheet.Cells[6, 33].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[6, 33].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(196, 215, 155));
            worksheet.Cells[4, 39].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[4, 39].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(149, 179, 215));
            worksheet.Cells[5, 39].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[5, 39].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(196, 215, 155));
            worksheet.Cells[5, 40].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[5, 40].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(196, 215, 155));
            worksheet.Cells[5, 41].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[5, 41].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(196, 215, 155));
            worksheet.Cells[5, 42].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[5, 42].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(196, 215, 155));
            worksheet.Cells[5, 16].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[5, 16].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(196, 215, 155));
            worksheet.Cells[5, 17].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells[5, 17].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(196, 215, 155));
            worksheet.Cells["A7:AR7"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
            worksheet.Cells["A7:AR7"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(218, 238, 243));
            #endregion

            //width
            #region WIDTH AUTO FIT
            worksheet.Column(3).Width = 24;
            worksheet.Column(4).Width = 24;
            worksheet.Column(5).Width = 24;
            worksheet.Column(2).Width = 14;
            worksheet.Column(1).Width = 14;
            worksheet.Column(6).Width = 15;
            worksheet.Column(7).Width = 15;
            worksheet.Column(8).Width = 18;
            worksheet.Column(9).Width = 15;
            worksheet.Column(10).Width = 15;
            worksheet.Column(11).Width = 15;
            worksheet.Column(12).Width = 15;
            worksheet.Column(13).Width = 10;
            worksheet.Column(14).Width = 10;
            worksheet.Column(15).Width = 10;
            worksheet.Column(16).Width = 41;
            worksheet.Column(17).Width = 9;
            worksheet.Column(18).Width = 13;
            worksheet.Column(19).Width = 18;
            worksheet.Column(20).Width = 20;
            worksheet.Column(21).Width = 20;
            worksheet.Column(22).Width = 11;
            worksheet.Column(23).Width = 13;
            worksheet.Column(24).Width = 14;
            worksheet.Column(25).Width = 9;
            //worksheet.Column(25).AutoFit();
            worksheet.Column(26).Width = 16;
            worksheet.Column(27).Width = 9;
            //worksheet.Column(27).AutoFit();
            worksheet.Column(28).Width = 12;
            worksheet.Column(29).Width = 16;
            worksheet.Column(30).Width = 9;
            //worksheet.Column(30).AutoFit();
            worksheet.Column(31).Width = 16;
            worksheet.Column(32).Width = 9;
            //worksheet.Column(32).AutoFit();
            worksheet.Column(33).Width = 9;
            worksheet.Column(34).Width = 9;
            worksheet.Column(35).Width = 13;
            //worksheet.Column(35).AutoFit();
            worksheet.Column(36).Width = 14;
            worksheet.Column(37).Width = 9;
            //worksheet.Column(37).AutoFit();
            worksheet.Column(38).Width = 9;
            //worksheet.Column(38).AutoFit(); ;
            worksheet.Column(39).Width = 16;
            worksheet.Column(40).Width = 16;
            worksheet.Column(41).Width = 16;
            worksheet.Column(42).Width = 16;
            worksheet.Column(43).Width = 16;
            worksheet.Column(44).Width = 16;
            worksheet.Column(45).Width = 16;
            #endregion

            #region ALIGNMENTS
            //Alignments
            worksheet.Row(1).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            worksheet.Row(7).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Row(4).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Row(5).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Row(6).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            worksheet.Row(7).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            worksheet.Row(4).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            worksheet.Row(5).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            worksheet.Row(6).Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            #endregion

            //borders
            #region BORDERS
            worksheet.Cells["A4:AR4"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["A6:AR6"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["A4:A7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["B4:B7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["C4:E4"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["H4:Q4"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["X4:AH4"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["X5:AH5"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["C5:C7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["D5:D7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["E4:E7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["F4:F7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["G4:G7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["H5:H7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["I5:I7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["J5:J7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["K5:K7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["L5:L7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["M5:M7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["N5:N7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["O4:O7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["P5:P7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["Q4:Q7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["R4:R7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["S4:S7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["T4:T7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["U4:U7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["V4:V7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["W4:W7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["X6:X7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["Y5:Y7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["Z6:Z7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AA5:AA7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AB6:AB7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AC6:AC7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AD5:AD7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AE6:AE7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AF6:AF7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AG6:AG7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AH4:AH7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AI4:AI7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AJ4:AJ7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AK4:AK7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AL4:AL7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AM5:AM7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AN5:AN7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AO5:AO7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AP4:AP7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            worksheet.Cells["AQ4:AQ7"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            #endregion

            return package.GetAsByteArray();
        }
    }
}
