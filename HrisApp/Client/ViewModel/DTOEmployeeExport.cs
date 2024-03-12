using OfficeOpenXml;

namespace HrisApp.Client.ViewModel
{
    public class DTOEmployeeExport
    {
        public async Task<byte[]> createExcelPackage(List<EmployeeT> crr, string cmbStatus, string cmbRangeDate, List<SubPositionT> subpos)
        {
            await Task.Delay(1);
            List<EmployeeT> Denomination = crr;
            var package = new ExcelPackage();
            package.Workbook.Properties.Title = "EMPLOYEES";
            package.Workbook.Properties.Author = "SSDI";
            package.Workbook.Properties.Subject = "EMPLOYEES";
            package.Workbook.Properties.Keywords = "EMPLOYEES";

            var worksheet = package.Workbook.Worksheets.Add("EMPLOYEES");

            if (cmbStatus != "All Status" && cmbRangeDate != null)
            {
                worksheet.Cells[1, 1].Value = cmbStatus.ToUpper() + " EMPLOYEES HIRED FROM " + cmbRangeDate.ToUpper();
            }
            else if (cmbStatus != "All Status" && cmbRangeDate == null)
            {
                worksheet.Cells[1, 1].Value = "ALL " + cmbStatus.ToUpper() + " EMPLOYEES AS OF TODAY - " + DateTime.Now.ToString("MMM dd, yyyy").ToUpper();
            }
            else if (cmbStatus == "All Status" && cmbRangeDate != null)
            {
                worksheet.Cells[1, 1].Value = "EMPLOYEES HIRED FROM " + cmbRangeDate.ToUpper();
            }
            else
            {
                worksheet.Cells[1, 1].Value = "ALL EMPLOYEES AS OF TODAY - " + DateTime.Now.ToString("MMM dd, yyyy").ToUpper();
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
            worksheet.Cells[2, 10].Value = "STATUS";
            //add Value
            var numberFomat = "#,##0.00";
            var dataCellStyleName = "TableNumber";
            var numStyle = package.Workbook.Styles.CreateNamedStyle(dataCellStyleName);
            numStyle.Style.Numberformat.Format = numberFomat;
            int c = 3;
            int i = 1;
            var pos = "";
            foreach (var r in crr)
            {
                foreach (var item in subpos)
                {
                    if (item.Id == r.PositionId)
                    {
                        pos = item.Description;
                    }
                }
                worksheet.Cells[c, 1].Value = i;
                worksheet.Cells[c, 2].Value = r.FirstName + " " + r.MiddleName + " " + r.LastName;
                worksheet.Cells[c, 3].Value = r.EmployeeNo;
                worksheet.Cells[c, 4].Value = r.Division?.Name;
                worksheet.Cells[c, 5].Value = r.Department?.Name;
                worksheet.Cells[c, 6].Value = pos;
                worksheet.Cells[c, 7].Value = r.Area?.Name;
                worksheet.Cells[c, 8].Value = r.Gender?.Name;
                worksheet.Cells[c, 9].Value = r.DateHired.ToString("MM-dd-yyyy");
                worksheet.Cells[c, 10].Value = r.Status?.Name;

                // Color the STATUS COLUMN based on the status
                if (r.Status?.Name == "Active")
                {
                    worksheet.Cells[c, 10].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[c, 10].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#AAC8A7"));
                }
                else if (r.Status?.Name == "Awol")
                {
                    worksheet.Cells[c, 10].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[c, 10].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#888C4D"));
                }
                else if (r.Status?.Name == "Inactive")
                {
                    worksheet.Cells[c, 10].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[c, 10].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#B7B7B7"));
                }
                else if (r.Status?.Name == "Terminated")
                {
                    worksheet.Cells[c, 10].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[c, 10].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#E97777"));
                }
                else if (r.Status?.Name == "Retired")
                {
                    worksheet.Cells[c, 10].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[c, 10].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#e0dfdc"));
                }
                else if (r.Status?.Name == "Resigned")
                {
                    worksheet.Cells[c, 10].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    worksheet.Cells[c, 10].Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ebc878"));
                }
                i++;
                c++;
            }

            //Merge
            worksheet.Cells["A1:G1"].Merge = true;
            worksheet.Cells["H1:J1"].Merge = true;

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
            var crrTbl = worksheet.Tables.Add(new ExcelAddressBase(fromRow: 2, fromCol: 1, toRow: maxrow, toColumn: 10), "data");
            crrTbl.ShowHeader = true;
            crrTbl.TableStyle = OfficeOpenXml.Table.TableStyles.Light16;
            //crrTbl.ShowTotal = true;
            //Autofilcolumn
            //worksheet.Cells[2, 1, 2, 11].AutoFitColumns();
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            return package.GetAsByteArray();
        }

        public async Task<byte[]> DownloadEmpTemplate(List<DepartmentT> departmentTs, List<AreaT> areaTs, List<DivisionT> divisionTs, List<SectionT> sectionTs, List<GenderT> genderTs, List<CivilStatusT> civilStatusTs, List<ReligionT> religionTs, List<StatusT> statusTs, List<EmploymentStatusT> employmentStatusTs, List<RateTypeT> rateTypeTs, List<CashBondT> cashBondTs, List<EmerRelationshipT> emerRelationshipTs, List<SubPositionT> subPositionTs)
        {
            await Task.Delay(100);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage package = new();
            {
                package.Workbook.Properties.Title = "EMPLOYEES DATA";
                package.Workbook.Properties.Author = "SSDI";
                package.Workbook.Properties.Subject = "Outlet uploader";
                package.Workbook.Properties.Keywords = "Export";

                var worksheet = package.Workbook.Worksheets.Add("Employee_Data");
                var worksheetMD = package.Workbook.Worksheets.Add("Master_Data");

                #region WORKSHEET EMP

                worksheet.Cells[1, 1].Value = "LAST NAME";
                worksheet.Cells[1, 2].Value = "FIRST NAME";
                worksheet.Cells[1, 3].Value = "MIDDLE NAME";
                worksheet.Cells[1, 4].Value = "SUFFIX";
                worksheet.Cells[1, 5].Value = "DATE OF BIRTH";
                worksheet.Cells[1, 6].Value = "AGE";
                worksheet.Cells[1, 7].Value = "GENDER";
                worksheet.Cells[1, 8].Value = "CIVIL STATUS";
                worksheet.Cells[1, 9].Value = "NATIONALITY";
                worksheet.Cells[1, 10].Value = "RELIGION";
                worksheet.Cells[1, 11].Value = "MOBILE NO.";
                worksheet.Cells[1, 12].Value = "EMAIL";
                worksheet.Cells[1, 13].Value = "SSS #";
                worksheet.Cells[1, 14].Value = "PHILHEALTH #";
                worksheet.Cells[1, 15].Value = "HDMF #";
                worksheet.Cells[1, 16].Value = "PAGIBIG #";
                worksheet.Cells[1, 17].Value = "TIN #";
                worksheet.Cells[1, 18].Value = "COMPANY ID NO.";
                worksheet.Cells[1, 19].Value = "BIOMETRIC ID NO.";
                worksheet.Cells[1, 20].Value = "AREA OF ASSIGNMENT";
                worksheet.Cells[1, 21].Value = "STATUS";
                worksheet.Cells[1, 22].Value = "EMPLOYMENT STATUS";
                worksheet.Cells[1, 23].Value = "DATE HIRED";
                worksheet.Cells[1, 24].Value = "REGULARIZATION DATE";
                worksheet.Cells[1, 25].Value = "DIVISION";
                worksheet.Cells[1, 26].Value = "DEPARTMENT";
                worksheet.Cells[1, 27].Value = "SECTION";
                worksheet.Cells[1, 28].Value = "POSITION";
                worksheet.Cells[1, 29].Value = "BASIC SALARY";
                worksheet.Cells[1, 30].Value = "RATE TYPE";
                worksheet.Cells[1, 31].Value = "CASH BOND";
                worksheet.Cells[1, 32].Value = "EMER NAME";
                worksheet.Cells[1, 33].Value = "EMER RELATIONSHIP";
                worksheet.Cells[1, 34].Value = "EMER ADDRESS";
                worksheet.Cells[1, 35].Value = "EMER MOBILENO";

                worksheet.Cells[1, 36].Value = "CURRENT ADD";
                worksheet.Cells[1, 37].Value = "CURRENT CITY";
                worksheet.Cells[1, 38].Value = "CURRENT PROVINCE";
                worksheet.Cells[1, 39].Value = "CURRENT ZIPCODE";
                worksheet.Cells[1, 40].Value = "CURRENT COUNTRY";
                worksheet.Cells[1, 41].Value = "PERMANENT ADD";
                worksheet.Cells[1, 42].Value = "PERMANENT CITY";
                worksheet.Cells[1, 43].Value = "PERMANENT PROVINCE";
                worksheet.Cells[1, 44].Value = "PERMANENT ZIPCODE";
                worksheet.Cells[1, 45].Value = "PERMANENT COUNTRY";

                #endregion WORKSHEET EMP

                int iDep = 1, iArea = 1, iDiv = 1, iSec = 2, iGen = 1, iCS = 1, iRL = 1, iStatus = 1, iEmpStatus = 1, iRateT = 1, iCBond = 1, iEmerR = 1, iPos = 1;
                worksheetMD.Cells[1, 4].Value = "None";

                #region Set data validation for the "DEPARTMENT" column

                // Set data validation for the "DEPARTMENT" column
                foreach (var item in departmentTs)
                {
                    worksheetMD.Cells[iDep, 1].Value = item.Name;
                    iDep++;
                }
                var lastRow = iDep - 1;
                var departmentColumn = worksheet.DataValidations.AddListValidation("Z2:Z500");
                departmentColumn.ShowErrorMessage = true;
                departmentColumn.ErrorTitle = "Invalid Department";
                departmentColumn.Error = "Please select a department from the dropdown list.";
                departmentColumn.Formula.ExcelFormula = $"Master_Data!$A$1:$A${lastRow}";

                #endregion Set data validation for the "DEPARTMENT" column

                #region Set data validation for the "Area" column

                foreach (var item in areaTs)
                {
                    worksheetMD.Cells[iArea, 2].Value = item.Name;
                    iArea++;
                }
                var areaColumn = worksheet.DataValidations.AddListValidation("T2:T500");
                areaColumn.ShowErrorMessage = true;
                areaColumn.ErrorTitle = "Invalid Area";
                areaColumn.Error = "Please select an area from the dropdown list.";
                areaColumn.Formula.ExcelFormula = $"Master_Data!$B$1:$B${iArea - 1}";

                #endregion Set data validation for the "Area" column

                #region Set data validation for the "DIVISION" column

                foreach (var item in divisionTs)
                {
                    worksheetMD.Cells[iDiv, 3].Value = item.Name;
                    iDiv++;
                }
                var divColumn = worksheet.DataValidations.AddListValidation("Y2:Y500");
                divColumn.ShowErrorMessage = true;
                divColumn.ErrorTitle = "Invalid Division";
                divColumn.Error = "Please select a division from the dropdown list.";
                divColumn.Formula.ExcelFormula = $"Master_Data!$C$1:$C${iDiv - 1}";

                #endregion Set data validation for the "DIVISION" column

                #region Set data validation for the "SECTION" column

                foreach (var item in sectionTs)
                {
                    worksheetMD.Cells[iSec, 4].Value = item.Name;
                    iSec++;
                }
                var secColumn = worksheet.DataValidations.AddListValidation("AA2:AA500");
                secColumn.ShowErrorMessage = true;
                secColumn.ErrorTitle = "Invalid Section";
                secColumn.Error = "Please select a section from the dropdown list.";
                secColumn.Formula.ExcelFormula = $"Master_Data!$D$1:$D${iSec - 1}";

                #endregion Set data validation for the "SECTION" column

                #region Set data validation for the "GENDER" column

                foreach (var item in genderTs)
                {
                    worksheetMD.Cells[iGen, 5].Value = item.Name;
                    iGen++;
                }
                var genColumn = worksheet.DataValidations.AddListValidation("G2:G500");
                genColumn.ShowErrorMessage = true;
                genColumn.ErrorTitle = "Invalid Gender";
                genColumn.Error = "Please select a gender from the dropdown list.";
                genColumn.Formula.ExcelFormula = $"Master_Data!$E$1:$E${iGen - 1}";

                #endregion Set data validation for the "GENDER" column

                #region Set data validation for the "CIVIL STATUS" column

                foreach (var item in civilStatusTs)
                {
                    worksheetMD.Cells[iCS, 6].Value = item.Name;
                    iCS++;
                }
                var csColumn = worksheet.DataValidations.AddListValidation("H2:H500");
                csColumn.ShowErrorMessage = true;
                csColumn.ErrorTitle = "Invalid Civil Status";
                csColumn.Error = "Please select a civil status from the dropdown list.";
                csColumn.Formula.ExcelFormula = $"Master_Data!$F$1:$F${iCS - 1}";

                #endregion Set data validation for the "CIVIL STATUS" column

                #region Set data validation for the "RELIGION" column

                foreach (var item in religionTs)
                {
                    worksheetMD.Cells[iRL, 7].Value = item.Name;
                    iRL++;
                }
                var rlColumn = worksheet.DataValidations.AddListValidation("J2:J500");
                rlColumn.ShowErrorMessage = true;
                rlColumn.ErrorTitle = "Invalid Religion";
                rlColumn.Error = "Please select a religion from the dropdown list.";
                rlColumn.Formula.ExcelFormula = $"Master_Data!$G$1:$G${iRL - 1}";

                #endregion Set data validation for the "RELIGION" column

                #region Set data validation for the "STATUS" column

                foreach (var item in statusTs)
                {
                    worksheetMD.Cells[iStatus, 8].Value = item.Name;
                    iStatus++;
                }
                var statusColumn = worksheet.DataValidations.AddListValidation("U2:U500");
                statusColumn.ShowErrorMessage = true;
                statusColumn.ErrorTitle = "Invalid Status";
                statusColumn.Error = "Please select a status from the dropdown list.";
                statusColumn.Formula.ExcelFormula = $"Master_Data!$H$1:$H${iStatus - 1}";

                #endregion Set data validation for the "STATUS" column

                #region Set data validation for the "EMPLOYMENT STATUS" column

                foreach (var item in employmentStatusTs)
                {
                    worksheetMD.Cells[iEmpStatus, 9].Value = item.Name;
                    iEmpStatus++;
                }
                var empstatusColumn = worksheet.DataValidations.AddListValidation("V2:V500");
                empstatusColumn.ShowErrorMessage = true;
                empstatusColumn.ErrorTitle = "Invalid Employment Status";
                empstatusColumn.Error = "Please select a employment status from the dropdown list.";
                empstatusColumn.Formula.ExcelFormula = $"Master_Data!$I$1:$I${iEmpStatus - 1}";

                #endregion Set data validation for the "EMPLOYMENT STATUS" column

                #region Set data validation for the "RATE TYPE" column

                foreach (var item in rateTypeTs)
                {
                    worksheetMD.Cells[iRateT, 10].Value = item.Name;
                    iRateT++;
                }
                var ratetColumn = worksheet.DataValidations.AddListValidation("AD2:AD500");
                ratetColumn.ShowErrorMessage = true;
                ratetColumn.ErrorTitle = "Invalid Rate Type";
                ratetColumn.Error = "Please select a Rate Type from the dropdown list.";
                ratetColumn.Formula.ExcelFormula = $"Master_Data!$J$1:$J${iRateT - 1}";

                #endregion Set data validation for the "RATE TYPE" column

                #region Set data validation for the "CASH BOND" column

                foreach (var item in cashBondTs)
                {
                    worksheetMD.Cells[iCBond, 11].Value = item.Name;
                    iCBond++;
                }
                var cbondColumn = worksheet.DataValidations.AddListValidation("AE2:AE500");
                cbondColumn.ShowErrorMessage = true;
                cbondColumn.ErrorTitle = "Invalid Cash Bond";
                cbondColumn.Error = "Please select a cash bond from the dropdown list.";
                cbondColumn.Formula.ExcelFormula = $"Master_Data!$K$1:$K${iCBond - 1}";

                #endregion Set data validation for the "CASH BOND" column

                #region Set data validation for the "EMER RELATIONSHIP" column

                foreach (var item in emerRelationshipTs)
                {
                    worksheetMD.Cells[iEmerR, 12].Value = item.Name;
                    iEmerR++;
                }
                var emerRColumn = worksheet.DataValidations.AddListValidation("AG2:AG500");
                emerRColumn.ShowErrorMessage = true;
                emerRColumn.ErrorTitle = "Invalid Relationship";
                emerRColumn.Error = "Please select a relationship from the dropdown list.";
                emerRColumn.Formula.ExcelFormula = $"Master_Data!$L$1:$L${iEmerR - 1}";

                #endregion Set data validation for the "EMER RELATIONSHIP" column

                #region Set data validation for the "POSITION" column

                foreach (var item in subPositionTs)
                {
                    worksheetMD.Cells[iPos, 13].Value = item.Description + " - " + item.SubPosCode;
                    iPos++;
                }
                var posColumn = worksheet.DataValidations.AddListValidation("AB2:AB500");
                posColumn.ShowErrorMessage = true;
                posColumn.ErrorTitle = "Invalid Position";
                posColumn.Error = "Please select a position from the dropdown list.";
                posColumn.Formula.ExcelFormula = $"Master_Data!$M$1:$M${iPos - 1}";

                #endregion Set data validation for the "POSITION" column

                worksheetMD.Protection.IsProtected = true;
                worksheetMD.Protection.AllowSelectLockedCells = true;
                worksheetMD.Protection.SetPassword("JMPassword");

                #region date cplumns format

                var dateFormat = "MM/dd/yyyy";
                var dateColumn = worksheet.Cells["E2:E500"];
                var datehiredColumn = worksheet.Cells["W2:W500"];
                var dateregColumn = worksheet.Cells["X2:X500"];
                dateColumn.Style.Numberformat.Format = dateFormat;
                datehiredColumn.Style.Numberformat.Format = dateFormat;
                dateregColumn.Style.Numberformat.Format = dateFormat;

                #endregion date cplumns format

                var numberFomat = "₱ #,##0.00";
                var dataCellStyleName = "TableNumber";
                var numStyle = package.Workbook.Styles.CreateNamedStyle(dataCellStyleName);
                numStyle.Style.Numberformat.Format = numberFomat;

                worksheet.Cells[1, 1, 35, 35].AutoFitColumns();
                worksheetMD.Cells[1, 1, 13, 13].AutoFitColumns();
            };
            return package.GetAsByteArray();
        }
    }
}