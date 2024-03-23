namespace HrisApp.Client.Pages.Employee
{
#nullable disable

    public partial class Employee : ComponentBase
    {
        public readonly string _infoFormat = "{first_item}-{last_item} of {all_items}";
        public string _searchString1 = "";
        public List<EmployeeT> _employeeList = new();
        public EmployeeT _selectedItem1 = null;
        public List<StatusT> StatusL = new();
        public List<DivisionT> DivisionsL = new();
        public List<DepartmentT> DepartmentsL = new();
        public List<SubPositionT> SubPositionsL = new();

        public MudDateRangePicker _picker;
        public DateRange _dateRange = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await Task.Delay(1000);
                StateService.OnChange += OnStateChanged;
                await LoadList();
                //await EmployeeService.GetEmployee();
                //_employeeList = EmployeeService.EmployeeTs;
                await StaticService.GetStatusList();
                StatusL = StaticService.StatusTs;

                await DivisionService.GetDivision();
                DivisionsL = DivisionService.DivisionTs;

                await PositionService.GetSubPosition();
                SubPositionsL = PositionService.SubPositionTs;

                DepartmentsL = await DepartmentService.GetDepartmentList();

                #region for DASHBOARD

                var uri = new Uri(NavigationManager.Uri);
                var statusFilterString = uri.Query.Split('=').LastOrDefault();
                if (statusFilterString?.ToLower() == "inactive")
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.StatusId != 1).ToList();
                }
                else if (statusFilterString?.ToLower() == "active")
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.StatusId == 1).ToList();
                }

                #endregion for DASHBOARD

                if (_employeeList == null || _employeeList.Count == 0)
                {
                    OpenOverlay();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private async Task LoadList()
        {
            await EmployeeService.GetEmployee();
            StateService.SetState("EmployeeList", EmployeeService.EmployeeTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            _employeeList = StateService.GetState<List<EmployeeT>>("EmployeeList");
            StateHasChanged();
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
        public string CmbDeptText = "All Department";
        public string CmbStatusText = "All Status";
        public string CmbDaateHiredText = "All";

        public async void CmbDateHired(string type)
        {
            await Task.Delay(0);
            DateTime today = DateTime.Today;

            switch (type)
            {
                case "lastmonth":
                    CmbDaateHiredText = "Last Month";
                    _isOpen = false;
                    DateTime startOfLastMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
                    DateTime endOfLastMonth = new DateTime(today.Year, today.Month, 1).AddDays(-1);
                    _dateRange.Start = startOfLastMonth;
                    _dateRange.End = endOfLastMonth;

                    await UpdateEmpList();
                    break;

                case "lastyear":
                    CmbDaateHiredText = "Last Year";
                    _isOpen = false;
                    DateTime startOfLastYear = new(today.Year - 1, 1, 1);
                    DateTime endOfLastYear = startOfLastYear.AddYears(1).AddDays(-1);
                    _dateRange.Start = startOfLastYear;
                    _dateRange.End = endOfLastYear;

                    await UpdateEmpList();
                    break;

                case "lastweek":
                    CmbDaateHiredText = "Last Week";
                    _isOpen = false;
                    DateTime lastWeekStart = today.AddDays(-(int)today.DayOfWeek - 6);
                    DateTime lastWeekEnd = lastWeekStart.AddDays(6);
                    _dateRange.Start = lastWeekStart;
                    _dateRange.End = lastWeekEnd;

                    if (CmbStatusText == "All Status" && CmbDivText == "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                         .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End)
                         .ToList();
                    }
                    else if (CmbStatusText != "All Status" && CmbDivText == "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End && e.Status?.Name == CmbStatusText)
                        .ToList();
                    }
                    else if (CmbStatusText == "All Status" && CmbDivText != "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                            .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End && e.Division?.Name == CmbDivText)
                            .ToList();
                    }
                    else if (CmbStatusText != "All Status" && CmbDivText != "All Division")
                    {
                        _employeeList = EmployeeService.EmployeeTs
                            .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End && e.Division?.Name == CmbDivText && e.Status?.Name == CmbStatusText)
                            .ToList();
                    }
                    break;

                case "yesterday":
                    CmbDaateHiredText = "Yesterday";
                    _isOpen = false;
                    DateTime yesterday = today.AddDays(-1);
                    _dateRange.Start = yesterday;
                    _dateRange.End = yesterday.AddDays(1).AddTicks(-1);

                    await UpdateEmpList();
                    break;

                default:
                    CmbDaateHiredText = "All";
                    _isOpen = false;
                    _dateRange.Start = null;
                    _dateRange.End = null;

                    await UpdateEmpList();
                    break;
            }

            if (_employeeList == null || _employeeList.Count == 0)
            {
                OpenOverlay();
            }
        }

        public async Task CmbDivision(int div)
        {
            if (div == 0)
            {
                CmbDivText = "All Division";
            }
            else
            {
                CmbDivText = DivisionsL.FirstOrDefault(e => e.Id == div)?.Name ?? CmbDivText;
            }
            await UpdateEmpList();
        }

        public async Task SearchStatus(int status)
        {
            if (status == 0)
            {
                CmbStatusText = "All Status";
            }
            else
            {
                CmbStatusText = StatusL.FirstOrDefault(e => e.Id == status)?.Name ?? CmbStatusText;
            }
            await UpdateEmpList();
        }

        public async Task EmpDateRangeChange(DateRange dateRange)
        {
            _dateRange = dateRange;
            CmbDaateHiredText = _dateRange?.Start?.ToString("MM/dd/yyyy") + " - " + _dateRange?.End?.ToString("MM/dd/yyyy");
            ToggleOpen();

            await UpdateEmpList();
        }

        public async Task CmbDepartment(int dep)
        {
            if (dep == 0)
            {
                CmbDeptText = "All Department";
            }
            else
            {
                CmbDeptText = DepartmentsL.FirstOrDefault(e => e.Id == dep)?.Name ?? CmbDeptText;
            }

            await UpdateEmpList();
        }


        public async Task UpdateEmpList()
        {
            await Task.Delay(0);
            if (CmbStatusText == "All Status" && CmbDivText == "All Division" && CmbDeptText == "All Department")
            {
                if (_dateRange.Start == null && _dateRange.End == null)
                {
                    _employeeList = EmployeeService.EmployeeTs;
                }
                else
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End)
                        .ToList();
                }
            }
            else if (CmbStatusText != "All Status" && CmbDivText == "All Division" && CmbDeptText == "All Department")
            {
                if (_dateRange.Start == null && _dateRange.End == null)
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.Status?.Name == CmbStatusText).ToList();
                }
                else
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End && e.Status?.Name == CmbStatusText)
                        .ToList();
                }
            }
            else if (CmbStatusText == "All Status" && CmbDivText != "All Division" && CmbDeptText == "All Department")
            {
                if (_dateRange.Start == null && _dateRange.End == null)
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.Division?.Name == CmbDivText).ToList();
                }
                else
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End && e.Division?.Name == CmbDivText)
                        .ToList();
                }
            }
            else if (CmbStatusText == "All Status" && CmbDivText == "All Division" && CmbDeptText != "All Department")
            {
                if (_dateRange.Start == null && _dateRange.End == null)
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.Department?.Name == CmbDeptText).ToList();
                }
                else
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End && e.Department?.Name == CmbDeptText)
                        .ToList();
                }
            }
            else if (CmbStatusText != "All Status" && CmbDivText != "All Division" && CmbDeptText == "All Department")
            {
                if (_dateRange.Start == null && _dateRange.End == null)
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.Division?.Name == CmbDivText && e.Status?.Name == CmbStatusText).ToList();
                }
                else
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End && e.Division?.Name == CmbDivText && e.Status?.Name == CmbStatusText)
                        .ToList();
                }
            }
            else if (CmbStatusText != "All Status" && CmbDivText == "All Division" && CmbDeptText != "All Department")
            {
                if (_dateRange.Start == null && _dateRange.End == null)
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.Department?.Name == CmbDeptText && e.Status?.Name == CmbStatusText).ToList();
                }
                else
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End && e.Department?.Name == CmbDeptText && e.Status?.Name == CmbStatusText)
                        .ToList();
                }
            }
            else if (CmbStatusText == "All Status" && CmbDivText != "All Division" && CmbDeptText != "All Department")
            {
                if (_dateRange.Start == null && _dateRange.End == null)
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.Department?.Name == CmbDeptText && e.Division?.Name == CmbDivText).ToList();
                }
                else
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End && e.Department?.Name == CmbDeptText && e.Division?.Name == CmbDivText)
                        .ToList();
                }
            }
            else if (CmbStatusText != "All Status" && CmbDivText != "All Division" && CmbDeptText != "All Department")
            {
                if (_dateRange.Start == null && _dateRange.End == null)
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.Department?.Name == CmbDeptText && e.Division?.Name == CmbDivText && e.Status?.Name == CmbStatusText).ToList();
                }
                else
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End && e.Department?.Name == CmbDeptText && e.Division?.Name == CmbDivText && e.Status?.Name == CmbStatusText)
                        .ToList();
                }
            }

            // Check if the employee list is empty and show overlay if needed
            if (_employeeList == null || _employeeList.Count == 0)
            {
                OpenOverlay();
            }
        }


        #endregion COMBOBOX FILTERS

        #region FUNCTIONS / METHODS

        public void CreateNewEmployee() => NavigationManager.NavigateTo("/employee/add");

        public void ShowEmployee(int id) => NavigationManager.NavigateTo($"/employee/edit/{id}");

        private void OpenUploadDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small };
            DialogService.Show<UploadFileDialog>("", options);
        }

        public async Task DeleteEmployee(int id)
        {
            await EmployeeService.DeleteEmployee(id);
        }

        public static string StatusChipColor(string status)
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

        public async void OpenOverlay()
        {
            _isVisible = false;
            await Task.Delay(2000);
            _isVisible = true;
            StateHasChanged();
        }

        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }

        #endregion FUNCTIONS / METHODS

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
            if (emp.DateHired.ToString("MM/dd/yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;
        }

        #endregion TABLE VARIABLES
    }
}