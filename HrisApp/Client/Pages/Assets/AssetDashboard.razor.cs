namespace HrisApp.Client.Pages.Assets
{
#nullable disable

    public partial class AssetDashboard : ComponentBase
    {
        private string FULLNAME;

        private string countAvailableMain, countAvailableAccess, countTotalUsed, countTotalAsset = "0";

        protected override async Task OnInitializedAsync()
        {
            await AssetMasterService.GetObj();
            await AssetAccService.GetObj();

            var globalId = Convert.ToInt32(GlobalConfigService.User_Id);
            FULLNAME = await EmployeeService.Getname(globalId);

            countAvailableMain = AssetMasterService.AssetMasterTs.Where(e => e.AssetStatusId == 2).Count().ToString();
            countAvailableAccess = AssetAccService.AssetAccessoryTs.Where(e => e.AssetStatusId == 2).Count().ToString();
            countTotalUsed = AssetMasterService.AssetMasterTs.Where(e => e.EmployeeId != null).Count().ToString();
            countTotalAsset = AssetMasterService.AssetMasterTs.Count.ToString();
        }
    }
}