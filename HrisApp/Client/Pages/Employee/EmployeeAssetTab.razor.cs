namespace HrisApp.Client.Pages.Employee
{
#nullable disable

    public partial class EmployeeAssetTab : ComponentBase
    {
        [Parameter] public int EmpId { get; set; }

        private EmployeeT EMPLOYEE = new();

        private List<AssetMasterT> MAINASSETS = new();
        private List<AssetAccessoryT> ACCESSORIES = new();

        protected override async Task OnParametersSetAsync()
        {
            EMPLOYEE = await EmployeeService.GetSingleEmployee(EmpId);
            await AssetMasterService.GetObj();
            MAINASSETS = AssetMasterService.AssetMasterTs.Where(e => e.EmployeeId == EmpId).ToList();
        }

        private void NavToAssignedAsset(int id)
        {
            NavigationManager.NavigateTo($"/main-asset/details/{id}");
        }
    }
}