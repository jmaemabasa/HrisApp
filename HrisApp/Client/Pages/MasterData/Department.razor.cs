﻿namespace HrisApp.Client.Pages.MasterData
{
    public partial class Department : ComponentBase
    {
        private List<DepartmentT> Departments = new();
        private List<DivisionT> Divisions = new();
        protected override async Task OnInitializedAsync()
        {
            try
            {
                await Task.Delay(500);
                StateService.OnChange += OnStateChanged;
                await LoadList();
                //await DepartmentService.GetDepartment();
                //departmentList = DepartmentService.DepartmentTs;

                await DivisionService.GetDivision();
                Divisions = DivisionService.DivisionTs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task LoadList()
        {
            await DepartmentService.GetDepartment();
            StateService.SetState("DepartmentList", DepartmentService.DepartmentTs);
        }

        private void OnStateChanged()
        {
            departmentList = StateService.GetState<List<DepartmentT>>("DepartmentList");
            StateHasChanged();
        }

        private bool isVisible;
        public async void OpenOverlay()
        {
            isVisible = true;
            await Task.Delay(3000);
            isVisible = false;
            StateHasChanged();
        }

        #region TABLES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<DepartmentT> departmentList = new();
        private DepartmentT? selectedItem1 = null;
        private readonly HashSet<DepartmentT> selectedItems = new();

        private bool FilterFunc1(DepartmentT department) => FilterFunc(department, searchString1);

        private static bool FilterFunc(DepartmentT department, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (department.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        private void OpenAddDepartment()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddDepartmentDialog>("New Department", options);
        }

        private void OpenUpdateDepartment(int id)
        {
            var parameters = new DialogParameters<UpdateDivisionDialog>
            {
                { x => x.Id, id }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<UpdateDepartmentDialog>("Update Department", parameters, options);
        }
        #endregion

        #region Search Text Box

        private async Task searchh(int div)
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
