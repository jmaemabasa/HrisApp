using HrisApp.Client.Pages.MasterData;
using static MudBlazor.CategoryTypes;

namespace HrisApp.Client.ViewModel.MasterDataViewModel
{
    public class DepartmentVM : BaseViewModel
    {

        IAuditlogService _auditlogService = new AuditlogService();
        IDivisionService DivisionService = new DivisionService();
        IDepartmentService DepartmentService = new DepartmentService();

        private readonly GlobalConfigService GlobalConfigService;
        public DepartmentVM(GlobalConfigService globalConfigService)
        {
            GlobalConfigService = globalConfigService;
        }

        int _paramID, _selectedDiv;

        public List<DepartmentT> Departments = new();
        public List<DivisionT> Divisions = new();

        public DepartmentT departmentupdate = new();
        public int selectedDivision { get => _selectedDiv; set => SetValue(ref _selectedDiv, value); }

        public MudMessageBox Message_Box { get; set; }
        public int ParameterID { get => _paramID; set => SetValue(ref _paramID, value); }

        string _deptName;
        public string newDeptName { get => _deptName; set => SetValue(ref _deptName, value); }

        public async Task OnRefreshPage()
        {
            try
            {
                
                ParameterID = 0;
                OnChange += OnStateChanged;
                await LoadList();

                await DivisionService.GetDivision();
                Divisions = DivisionService.DivisionTs;
                selectedDivision = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task LoadList()
        {
            await DepartmentService.GetDepartment();
            SetState("DepartmentList", DepartmentService.DepartmentTs);
        }

        public void OnStateChanged()
        {
            departmentList = GetState<List<DepartmentT>>("DepartmentList");
            //StateHasChanged();
        }

        public async Task<string> ConfirmCreateDepartment()
        {

            if (string.IsNullOrWhiteSpace(newDeptName))
            {
                return $"{TokenConst.AlertError}xxxFill out name.";
            }


            if (ParameterID == 0)
            {
                await DepartmentService.CreateDepartment(newDeptName, selectedDivision);

                await _auditlogService.CreateLog(Convert.ToInt32(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                //_toastService.ShowSuccess(newArea + " Created Successfully!");

                // Update the areaList using the StateService
                await DepartmentService.GetDepartment();
                var newAreaList = DepartmentService.DepartmentTs;
                SetState("DepartmentList", newAreaList);
                return $"{TokenConst.AlertSuccess}xxxSuccessfully Created.";
            }
            else
            {
                departmentupdate.Name = newDeptName;
                await DepartmentService.UpdateDepartment(departmentupdate);
                await _auditlogService.CreateLog(Convert.ToInt32(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                //_toastService.ShowSuccess(area.Name + " Updated Successfully!");

                // Update the areaList using the StateService
                await DepartmentService.GetDepartment();
                var newAreaList = DepartmentService.DepartmentTs;
                SetState("DepartmentList", newAreaList);
                return $"{TokenConst.AlertSuccess}xxxSuccessfully Updated.";
            }
        }

        public async Task ShowNameTextField(int divId)
        {
            selectedDivision = 0;
            await Task.Delay(100);
            SetState("NameChange", divId);
            OnChange += OnStateNameChanged;

        }

        public void OnStateNameChanged()
        {
            selectedDivision = GetState<int>("NameChange");
            Console.WriteLine("Selected div: "+selectedDivision);
            //StateHasChanged();
        }

        #region TABLES
        public string infoFormat = "{first_item}-{last_item} of {all_items}";
        public string searchString1 = "";
        public List<DepartmentT> departmentList = new();
        public DepartmentT? selectedItem1 = null;
        public readonly HashSet<DepartmentT> selectedItems = new();

        public bool FilterFunc1(DepartmentT department) => FilterFunc(department, searchString1);

        private static bool FilterFunc(DepartmentT department, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (department.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public async Task OpenAddDepartment()
        {
            //selectedDivision = 0;
            newDeptName = string.Empty;
            await Message_Box.Show();
        }

        public async Task OpenUpdateDepartment(int id)
        {
            ParameterID = id;
            await Message_Box.Show();
            departmentupdate = await DepartmentService.GetSingleDepartment(id);
            OnChange += OnStateChanged;
            newDeptName = departmentupdate.Name;
        }
        #endregion

        #region Search Text Box

        public async Task searchh(int div)
        {
            await Task.Delay(10);
            if (div == 0)
            {
                await DepartmentService.GetDepartment();
                departmentList = DepartmentService.DepartmentTs;
            }
            else
            {
                departmentList = await DepartmentService.GetDeptByDivision(div);
            }

        }
        #endregion

        

    }
}
