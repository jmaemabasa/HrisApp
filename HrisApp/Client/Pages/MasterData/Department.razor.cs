namespace HrisApp.Client.Pages.MasterData
{
    public partial class Department : ComponentBase
    {
        private List<DepartmentT> Departments = new List<DepartmentT>();
        private List<DivisionT> Divisions = new List<DivisionT>();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                await DepartmentService.GetDepartment();
                await DivisionService.GetDivision();

                Divisions = DivisionService.DivisionTs;
                departmentList = DepartmentService.DepartmentTs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void OpenAddDepartment()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddDepartmentDialog>("New Department", options);
        }

        private void OpenUpdateDepartment(int id)
        {
            var parameters = new DialogParameters<UpdateDivisionDialog>();
            parameters.Add(x => x.Id, id);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<UpdateDepartmentDialog>("Update Department", parameters, options);
        }

        //TABLEEES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<DepartmentT> departmentList = new List<DepartmentT>();
        private DepartmentT selectedItem1 = null;
        private HashSet<DepartmentT> selectedItems = new HashSet<DepartmentT>();

        private bool FilterFunc1(DepartmentT department) => FilterFunc(department, searchString1);

        private bool FilterFunc(DepartmentT department, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (department.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        //END FOR TABLES
    }
}
