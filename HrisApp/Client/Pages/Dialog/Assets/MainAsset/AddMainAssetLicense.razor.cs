namespace HrisApp.Client.Pages.Dialog.Assets.MainAsset
{
#nullable disable
    public partial class AddMainAssetLicense : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        [Parameter] public int Id { get; set; }
        [Parameter] public EventCallback OnAddSuccess { get; set; }

        private List<AssetLicenseT> AssetLicenseList = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();

        private AssetMasterT assetMaster = new();
        private readonly MainAssetLicensesT obj = new();
        private readonly AssetLicenseHistoryT licHistoryObj = new();

        protected override async Task OnInitializedAsync()
        {
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
        }

        protected override async Task OnParametersSetAsync()
        {
            assetMaster = await AssetMasterService.GetSingleObj(Id);
            AssetLicenseList = await AssLicenseSvc.GetObjList();
        }

        private void Cancel() => MudDialog?.Cancel();

        private async Task SaveUpdate()
        {
            if (fieldObj == null)
            {
                GlobalConfigService.OpenErrorDialog("Select license");
            }
            else
            {
                obj.AssetLicenseId = fieldObj.Id;

                obj.CategoryId = AssetLicenseList.Where(x => x.Id == obj.AssetLicenseId).FirstOrDefault().CategoryId;
                obj.SubCategoryId = AssetLicenseList.Where(x => x.Id == obj.AssetLicenseId).FirstOrDefault().SubCategoryId;

                obj.AssetMasterId = assetMaster.Id;
                obj.AssetMasterCode = assetMaster.JMCode;

                await MainAssLicSvc.CreateObj(obj);

                var asset_acc = await AssLicenseSvc.GetSingleObj(obj.AssetLicenseId);
                asset_acc.MainAssetId = obj.AssetMasterId;
                asset_acc.MainAssetDateUpdated = DateTime.Now;
                asset_acc.AssetStatusId = assetMaster.AssetStatusId;
                await AssLicenseSvc.UpdateObj(asset_acc);

                licHistoryObj.AssignedDateMainAss = DateTime.Now;
                licHistoryObj.MainAssetId = assetMaster.Id;
                licHistoryObj.AssetLicenseId = obj.AssetLicenseId;
                licHistoryObj.EmployeeId = assetMaster.EmployeeId;
                await AssLicenseHisSvc.CreateObj(licHistoryObj);

                MudDialog?.Close();
                _toastService.ShowSuccess("Added Successfully!");
                await OnAddSuccess.InvokeAsync();
            }
        }

        private AssetLicenseT fieldObj;

        private async Task<IEnumerable<AssetLicenseT>> Search1(string value)
        {
            await Task.Delay(5);
            IEnumerable<AssetLicenseT> list;
            if (obj.CategoryId != 0 && obj.SubCategoryId != 0)
            {
                list = AssetLicenseList.Where(e => e.MainAssetId == null && e.CategoryId == obj.CategoryId && e.SubCategoryId == obj.SubCategoryId && e.AssetStatusId == 2);
            }
            else if (obj.CategoryId != 0 && obj.SubCategoryId == 0)
            {
                list = AssetLicenseList.Where(e => e.MainAssetId == null && e.CategoryId == obj.CategoryId && e.AssetStatusId == 2);
            }
            else if (obj.CategoryId == 0 && obj.SubCategoryId != 0)
            {
                list = AssetLicenseList.Where(e => e.MainAssetId == null && e.SubCategoryId == obj.SubCategoryId && e.AssetStatusId == 2);
            }
            else
            {
                list = AssetLicenseList.Where(e => e.MainAssetId == null && e.AssetStatusId == 2);
            }

            if (string.IsNullOrEmpty(value))
            {
                return list;
            }
            else
            {
                var chk = list.Where(x => x.AssetCode.Contains(value, StringComparison.InvariantCultureIgnoreCase) ||
                                            x.Brand.Contains(value, StringComparison.InvariantCultureIgnoreCase) ||
                                            x.Model.Contains(value, StringComparison.InvariantCultureIgnoreCase));

                return chk;
            }
        }

        private void OnChangeCat(int id)
        {
            obj.CategoryId = id;
        }

        private void OnChangeSCat(int id)
        {
            obj.SubCategoryId = id;
        }
    }
}
