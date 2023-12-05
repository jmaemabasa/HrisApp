using HrisApp.Client.HelperToken;
using HrisApp.Shared.Models.StaticData;
using System.Collections;

namespace HrisApp.Client.ViewModel.EmployeeViewModel.EmployeeViewModel
{
    public class EmployeeVM : BaseViewModel
    {
        IEmployeeService EmployeeService = new EmployeeService();
        IStaticService StaticService = new StaticService();
        IDivisionService DivisionService = new DivisionService();

        private readonly NavigationManager _navigationManager;
        public EmployeeVM(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        public readonly string _infoFormat = "{first_item}-{last_item} of {all_items}";
        public string _searchString1 = "";
        public List<EmployeeT> _employeeList = new();
        public EmployeeT _selectedItem1 = null;
        public List<StatusT> StatusL = new();
        public List<DivisionT> DivisionsL = new();

        public MudDateRangePicker _picker;
        public DateRange _dateRange = new();

        public async Task OnRefreshPage()
        {
            try
            {
                await Task.Delay(1000);
                await EmployeeService.GetEmployee();
                _employeeList = EmployeeService.EmployeeTs;
                await StaticService.GetStatusList();
                StatusL = StaticService.StatusTs;

                await DivisionService.GetDivision();
                DivisionsL = DivisionService.DivisionTs;

                #region for DASHBOARD
                var uri = new Uri(_navigationManager.Uri);
                var statusFilterString = uri.Query.Split('=').LastOrDefault();
                if (statusFilterString?.ToLower() == "inactive")
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.StatusId != 1).ToList();
                }
                else if (statusFilterString?.ToLower() == "active")
                {
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.StatusId == 1).ToList();
                }
                else if (statusFilterString?.ToLower() == "inactive5yearsago")
                {
                    DateTime fiveYearsAgo = DateTime.Now.AddYears(-5);
                    _employeeList = EmployeeService.EmployeeTs.Where(e => e.StatusId != 1 && e.DateInactiveStatus <= fiveYearsAgo).ToList();
                }
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
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
        public string CmbStatusText = "All Status";
        public string CmbDaateHiredText = "All";
        public void CmbDateHired(string type)
        {
            DateTime today = DateTime.Today;

            switch (type)
            {
                case "month":
                    CmbDaateHiredText = "This Month";
                    _isOpen = false;
                    DateTime startOfMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime endOfMonth = startOfMonth.AddMonths(1).AddDays(-1);
                    _dateRange.Start = startOfMonth;
                    _dateRange.End = endOfMonth;
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End)
                        .ToList();
                    break;

                case "last7days":
                    CmbDaateHiredText = "Last 7 Days";
                    _isOpen = false;
                    DateTime lastWeekStart = today.AddDays(-7);
                    _dateRange.Start = lastWeekStart;
                    _dateRange.End = today;
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End)
                        .ToList();
                    break;

                case "today":
                    CmbDaateHiredText = "Today";
                    _isOpen = false;
                    _dateRange.Start = today;
                    _dateRange.End = today.AddDays(1).AddTicks(-1);
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End)
                        .ToList();
                    break;

                default:
                    CmbDaateHiredText = "All";
                    _isOpen = false;
                    _dateRange.Start = null;
                    _dateRange.End = null;
                    _employeeList = EmployeeService.EmployeeTs;
                    break;
            }
        }
        public void CmbDivision(int div)
        {
            //    _dateRange.Start = null;
            //    _dateRange.End = null;

            if (div == 0)
            {
                CmbDivText = "All Division";

                if (CmbStatusText != "All Status")
                {
                    if (_dateRange.Start == null && _dateRange.End == null)
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.Status?.Name == CmbStatusText).ToList();
                    }
                    else
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.Status?.Name == CmbStatusText && e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End).ToList();
                    }
                }
                else
                {
                    if (_dateRange.Start == null && _dateRange.End == null)
                    {
                        _employeeList = EmployeeService.EmployeeTs;
                    }
                    else
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End).ToList();
                    }
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

                if (CmbStatusText != "All Status")
                {
                    if (_dateRange.Start == null && _dateRange.End == null)
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.Status?.Name == CmbStatusText && e.DivisionId == div).ToList();
                    }
                    else
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.Status?.Name == CmbStatusText && e.DivisionId == div && e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End).ToList();
                    }
                }
                else
                {
                    if (_dateRange.Start == null && _dateRange.End == null)
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.DivisionId == div).ToList();
                    }
                    else
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.DivisionId == div && e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End).ToList();
                    }
                }
            }
        }
        public void SearchStatus(int status)
        {
            //_dateRange.Start = null;
            //_dateRange.End = null;
            if (status == 0)
            {
                CmbStatusText = "All Status";

                if (CmbDivText != "All Division")
                {
                    if (_dateRange.Start == null && _dateRange.End == null)
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.Division?.Name == CmbDivText).ToList();
                    }
                    else
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.Division?.Name == CmbDivText && e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End).ToList();
                    }
                }
                else
                {
                    if (_dateRange.Start == null && _dateRange.End == null)
                    {
                        _employeeList = EmployeeService.EmployeeTs;
                    }
                    else
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End).ToList();
                    }
                }
            }
            else
            {
                foreach (var e in StatusL)
                {
                    if (e.Id == status)
                    {
                        CmbStatusText = e.Name;
                    }
                }

                if (CmbDivText != "All Division")
                {
                    if (_dateRange.Start == null && _dateRange.End == null)
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.Division?.Name == CmbDivText && e.StatusId == status).ToList();
                    }
                    else
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.Division?.Name == CmbDivText && e.StatusId == status && e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End).ToList();
                    }
                }
                else
                {
                    if (_dateRange.Start == null && _dateRange.End == null)
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.StatusId == status).ToList();
                    }
                    else
                    {
                        _employeeList = EmployeeService.EmployeeTs.Where(e => e.StatusId == status && e.DateHired >= _dateRange.Start && e.DateHired <= _dateRange.End).ToList();
                    }
                }

            }
        }
        public void EmpDateRangeChange(DateRange? dateRange)
        {
            _dateRange = dateRange;
            CmbDaateHiredText = _dateRange?.Start?.ToString("MM/dd/yyyy") + " - " + _dateRange?.End?.ToString("MM/dd/yyyy");
            ToggleOpen();

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

            if (_dateRange.Start == null && _dateRange.End == null)
            {
                if (CmbStatusText == "All Status" && CmbDivText == "All Division")
                {
                    _employeeList = EmployeeService.EmployeeTs;
                }
                else if (CmbStatusText != "All Status" && CmbDivText == "All Division")
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.Status?.Name == CmbStatusText)
                        .ToList();
                }
                else if (CmbStatusText == "All Status" && CmbDivText != "All Division")
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.Division?.Name == CmbDivText)
                        .ToList();
                }
                else if (CmbStatusText != "All Status" && CmbDivText != "All Division")
                {
                    _employeeList = EmployeeService.EmployeeTs
                        .Where(e => e.Division?.Name == CmbDivText && e.Status?.Name == CmbStatusText)
                        .ToList();
                }
            }



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
