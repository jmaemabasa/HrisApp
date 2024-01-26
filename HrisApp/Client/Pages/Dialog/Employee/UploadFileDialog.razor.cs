using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;

namespace HrisApp.Client.Pages.Dialog.Employee
{
    public partial class UploadFileDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        private string Filename = string.Empty;
        private bool _processing = false;
        private bool _processingSave = false;

        List<EmployeeT> EmployeeList = new List<EmployeeT>();
        List<DepartmentT> DepartmentList = new List<DepartmentT>();
        List<AreaT> AreaList = new();
        List<DivisionT> DivisionList = new();
        List<SectionT> SectionList = new();
        List<GenderT> GenderList = new();
        List<CivilStatusT> CivilStatusList = new();
        List<ReligionT> ReligionList = new();
        List<StatusT> StatusList = new();
        List<EmploymentStatusT> EmploymentStatusList = new();
        List<RateTypeT> RateTypeList = new();
        List<CashBondT> CashBondList = new();
        List<EmerRelationshipT> EmerRelationshipList = new();
        List<SubPositionT> SubPositionList = new();

        public DataTable dtable = new DataTable();


        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(10);

            DepartmentList = await DepartmentService.GetDepartmentList();
            AreaList = await AreaService.GetAreaList();
            DivisionList = await DivisionService.GetDivisionList();
            SectionList = await SectionService.GetSectionList();

            await StaticService.GetGenderList();
            GenderList = StaticService.GenderTs;
            await StaticService.GetCivilStatusList();
            CivilStatusList = StaticService.CivilStatusTs;
            await StaticService.GetReligionList();
            ReligionList = StaticService.ReligionTs;
            await StaticService.GetStatusList();
            StatusList = StaticService.StatusTs;
            await StaticService.GetEmploymentStatusList();
            EmploymentStatusList = StaticService.EmploymentStatusTs;
            await StaticService.GetRateType();
            RateTypeList = StaticService.RateTypeTs;
            await StaticService.GetCashbond();
            CashBondList = StaticService.CashBondTs;
            await StaticService.GetEmerRelationshipList();
            EmerRelationshipList = StaticService.EmerRelationshipTs;
            await PositionService.GetSubPosition();
            SubPositionList = PositionService.SubPositionTs.Where(e => e.Status != "Active").ToList();

        }

        private async Task OnUploadFile()
        {
            try
            {
                _processingSave = true;
                var response = await EmployeeService.QueryEmployeeForUpload(dtable, Filename);
                switch (response)
                {
                    case TokenCons.INVALIDFILE:
                        _toastService.ShowError("Your file is not valid, Please select a valid xlsx extension file.");
                        _processingSave = false;
                        break;

                    case TokenCons.INVALIDFORMAT:
                        _toastService.ShowError("Your file format is not valid, Please use the download template.");
                        _processingSave = false;
                        break;

                    case TokenCons.MISSINGFIELD:
                        _toastService.ShowError("Missing field, Please check your file.");
                        _processingSave = false;
                        break;

                    case TokenCons.IsError:
                        _toastService.ShowError("Error, Please check your file.");
                        _processingSave = false;
                        break;

                    case TokenCons.IsSuccess:
                        await Task.Delay(2500);
                        MudDialog.Cancel();
                        await EmployeeService.GetEmployee();
                        var newList = EmployeeService.EmployeeTs;
                        StateService.SetState("EmployeeList", newList);
                        _toastService.ShowSuccess("New employee successfully added");
                        _processingSave = false;
                        break;

                    case TokenCons.IsUpdated:
                        await Task.Delay(2500);
                        MudDialog.Cancel();
                        _toastService.ShowSuccess("Employee updated successfully");
                        _processingSave = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return;
            }
        }


        private async Task OnImportExcel(InputFileChangeEventArgs e)
        {
            try
            {
                var entry = e.GetMultipleFiles();
                var fileEx = entry.FirstOrDefault().Name.Split(".").Last();

                if (fileEx == "xlsx")
                {
                    dtable.Rows.Clear();
                    dtable.Columns.Clear();
                    Filename = (string)e.File.Name;

                    var fileStream = e.File.OpenReadStream();
                    var mstream = new MemoryStream();

                    await fileStream.CopyToAsync(mstream);
                    fileStream.Close();
                    mstream.Position = 0;

                    ISheet sheets;
                    var xworkbook = new XSSFWorkbook(mstream);

                    sheets = xworkbook.GetSheetAt(0);
                    IRow irows = sheets.GetRow(0);
                    var rlist = new List<string>();

                    int countcol = irows.LastCellNum;
                    for (var a = 0; a < countcol; a++)
                    {
                        ICell icell = irows.GetCell(a);
                        dtable.Columns.Add(icell.ToString());
                    }

                    for (var b = (sheets.FirstRowNum + 1); b <= sheets.LastRowNum; b++)
                    {
                        var c = sheets.GetRow(b);
                        for (var d = c.FirstCellNum; d < countcol; d++)
                        {
                            rlist.Add(c.GetCell(d).ToString());
                        }

                        if (rlist.Count > 0)
                        {
                            dtable.Rows.Add(rlist.ToArray());
                        }
                        rlist.Clear();
                    }
                }
                else
                {
                    _toastService.ShowError("Your file is not valid, Please select a valid xlsx extension file.");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private async Task OnDownloadTem()
        {
            _processing = true;
            var fileBytes = await _export.DownloadEmpTemplate(DepartmentList, AreaList, DivisionList, SectionList, GenderList, CivilStatusList, ReligionList, StatusList, EmploymentStatusList, RateTypeList, CashBondList, EmerRelationshipList, SubPositionList);
            var fileName = $"EmployeeDataTemplate.xlsx";
            await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
            _processing = false;
        }

        private async Task OnClearfile()
        {
            await Task.Delay(10);
            dtable.Rows.Clear();
            dtable.Columns.Clear();
            Filename = string.Empty;
        }

        void Cancel() => MudDialog.Cancel();
    }
}
