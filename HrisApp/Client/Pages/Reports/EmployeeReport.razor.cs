namespace HrisApp.Client.Pages.Reports
{
    public partial class EmployeeReport : ComponentBase
    {
        public readonly string _infoFormat = "{first_item}-{last_item} of {all_items}";
        public string _searchString1 = "";
        public List<EmployeeT> _employeeList = new();
        public EmployeeT _selectedItem1 = null;
        public List<StatusT> StatusL = new();
        public List<DivisionT> DivisionsL = new();

        public MudDateRangePicker _picker;
        public DateRange _dateRange = new();

        private bool _processing = false;

        private string TitleCountText = "As of " + DateTime.Now.ToString(("dddd, dd MMMM yyyy"));

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await Task.Delay(1000);
                await EmployeeService.GetEmployee();
                _employeeList = EmployeeService.EmployeeTs.Where(e => e.DateInactiveStatus == null || e.DateInactiveStatus >= DateTime.Now).ToList();
                await StaticService.GetStatusList();
                StatusL = StaticService.StatusTs;

                await DivisionService.GetDivision();
                DivisionsL = DivisionService.DivisionTs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public async Task OnExporttoExcel()
        {
            try
            {
                string startdate = _dateRange?.Start?.ToString("MMM dd, yyyy");
                string enddate = _dateRange?.End?.ToString("MMM dd, yyyy");
                string daterange;
                if (startdate == null && enddate == null)
                {
                    daterange = null;
                }
                else
                {
                    if (CmbDateActiveText == "Yesterday")
                    {
                        daterange = "AS OF " + startdate;
                    }
                    else
                    {
                        daterange = "FROM " + startdate + " — " + enddate;
                    }
                }
                _processing = true;
                await Task.Delay(2000);
                var fileBytes = await _crrExport.createExcelHeadcount(_employeeList, daterange);
                var fileName = $"SSDIEmployees{DateTime.Now.ToString("yyyy-MM-dd")}.xlsx";
                await JSRuntime.InvokeAsync<object>("saveAsFile", fileName, Convert.ToBase64String(fileBytes));
                _processing = false;

            }
            catch (Exception ex)
            {
                _processing = false;
                Console.WriteLine(ex.Message);
                //NavigateError();
            }
        }


        #region COMBOBOX FILTERS
        public bool _isOpen;
        public void ToggleOpen()
        {
            if (_isOpen)
                _isOpen = false;
            else
                _isOpen = true;
        }
        public void ToggleOpenMenu(bool test)
        {
            if (test)
                _isOpen = false;
            else
                _isOpen = true;
        }

        public string CmbDivText = "All Division";
        public string CmbDateActiveText = "All";
        public void CmbDateAllActive(string type)
        {
            DateTime today = DateTime.Today;

            switch (type)
            {
                case "lastmonth":
                    CmbDateActiveText = "Last Month";
                    _isOpen = false;
                    DateTime startOfLastMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
                    DateTime endOfLastMonth = new DateTime(today.Year, today.Month, 1).AddDays(-1);
                    _dateRange.Start = startOfLastMonth;
                    _dateRange.End = endOfLastMonth;

                    if (CmbDivText == "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                         .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End))
                         .ToList();
                    }
                    else if (CmbDivText != "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                            .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End) && e.Division?.Name == CmbDivText)
                            .ToList();
                    }
                    break;

                case "lastyear":
                    CmbDateActiveText = "Last Year";
                    _isOpen = false;
                    DateTime startOfLastYear = new DateTime(today.Year - 1, 1, 1);
                    DateTime endOfLastYear = startOfLastYear.AddYears(1).AddDays(-1);
                    _dateRange.Start = startOfLastYear;
                    _dateRange.End = endOfLastYear;

                    if (CmbDivText == "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                         .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End))
                         .ToList();
                    }
                    else if (CmbDivText != "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                            .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End) && e.Division?.Name == CmbDivText)
                            .ToList();
                    }
                    break;

                case "lastweek":
                    CmbDateActiveText = "Last Week";
                    _isOpen = false;
                    DateTime lastWeekStart = today.AddDays(-(int)today.DayOfWeek - 6);
                    DateTime lastWeekEnd = lastWeekStart.AddDays(6);
                    _dateRange.Start = lastWeekStart;
                    _dateRange.End = lastWeekEnd;

                    if (CmbDivText == "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                         .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End))
                         .ToList();
                    }
                    else if (CmbDivText != "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                            .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End) && e.Division?.Name == CmbDivText)
                            .ToList();
                    }
                    break;

                case "yesterday":
                    CmbDateActiveText = "Yesterday";
                    _isOpen = false;
                    DateTime yesterday = today.AddDays(-1);
                    _dateRange.Start = yesterday;
                    _dateRange.End = yesterday.AddDays(1).AddTicks(-1);

                    if (CmbDivText == "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                         .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End))
                         .ToList();
                    }
                    else if (CmbDivText != "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                            .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End) && e.Division?.Name == CmbDivText)
                            .ToList();
                    }
                    break;

                default:
                    CmbDateActiveText = "All";
                    _isOpen = false;
                    _dateRange.Start = null;
                    _dateRange.End = null;
                    if (CmbDivText == "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => (e.DateInactiveStatus == null || e.DateInactiveStatus >= DateTime.Now)).ToList();
                    }
                    else if (CmbDivText != "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                            .Where(e => e.Division?.Name == CmbDivText && (e.DateInactiveStatus == null || e.DateInactiveStatus >= DateTime.Now))
                            .ToList();
                    }
                    break;
            }

            TitleCountText = _dateRange.Start == null && _dateRange.End == null ? "As of " + DateTime.Now.ToString("dddd, dd MMMM yyyy") : type == "yesterday" ? "Yesterday, " + _dateRange?.Start?.ToString("dddd, dd MMMM yyyy") : (_dateRange?.Start?.ToString("MMM dd, yyyy") + " - " + _dateRange?.End?.ToString("MMM dd, yyyy"));
        }

        public void CmbDivision(int div)
        {
            //    _dateRange.Start = null;
            //    _dateRange.End = null;

            if (div == 0)
            {
                CmbDivText = "All Division";
                    if (_dateRange.Start == null && _dateRange.End == null)
                    {
                        _employeeList = EmployeeService.EmployeeTs;
                    }
                    else
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End)).ToList();
                    }
            }
            else
            {
                foreach (var e in DivisionsL)
                {
                    if (e.Id == div)
                    {
                        CmbDivText = e.Name;
                    }
                }
                    if (_dateRange.Start == null && _dateRange.End == null)
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.DivisionId == div).ToList();
                    }
                    else
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.DivisionId == div && (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End)).ToList();
                    }
            }
        }

        public void EmpDateRangeChange(DateRange? dateRange)
        {
            _dateRange = dateRange;
            CmbDateActiveText = _dateRange?.Start?.ToString("MM/dd/yyyy") + " - " + _dateRange?.End?.ToString("MM/dd/yyyy");
            ToggleOpen();

            if (CmbDivText == "All Division")
            {
                _employeeList = EmployeeService.EmployeeTs
                 .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End))
                 .ToList();
            }
            else if (CmbDivText != "All Division")
            {
                _employeeList = EmployeeService.EmployeeTs
                    .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End) && e.Division?.Name == CmbDivText)
                    .ToList();
            }

            if (_dateRange.Start == null && _dateRange.End == null)
            {
                if (CmbDivText == "All Division")
                {
                    _employeeList = EmployeeService.EmployeeTs
                     .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End))
                     .ToList();
                }
                else if (CmbDivText != "All Division")
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => (e.DateHired <= _dateRange.End) && (e.DateInactiveStatus == null || e.DateInactiveStatus >= _dateRange.End) && e.Division?.Name == CmbDivText)
                        .ToList();
                }
            }

            TitleCountText = (_dateRange?.Start?.ToString("MMM dd, yyyy") + " - " + _dateRange?.End?.ToString("MMM dd, yyyy"));

        }

        #endregion

        #region FUNCTIONS / METHODS
        public void CreateNewEmployee() => _navigationManager.NavigateTo("/employee/add");
        public void ShowEmployee(int id) => _navigationManager.NavigateTo($"/employee/edit/{id}");

        public async Task DeleteEmployee(int id)
        {
            await EmployeeService.DeleteEmployee(id);
        }

        public string StatusChipColor(string status)
        {
            return status switch
            {
                "Active" => "statusActiveChip",
                "Awol" => "statusAwolChip",
                "Inactive" => "statusInactiveChip",
                "Resigned" => "statusResignedChip",
                "Terminated" => "statusTerminatedChip",
                "Retired" => "statusRetiredChip",
                _ => "statusRetiredChip",
            };
        }

        //LOADING
        public bool _isVisible;

        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }
        #endregion

        #region TABLE VARIABLES
        public bool FilterFunc1(EmployeeT emp) => FilterFunc(emp, _searchString1);

        private static bool FilterFunc(EmployeeT emp, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if ((emp.FirstName + " " + emp.LastName).Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.FirstName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.MiddleName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.LastName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.Division.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.Department.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.Position.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (emp.DateHired.ToString("MM/dd/yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }
        #endregion

    }
}
