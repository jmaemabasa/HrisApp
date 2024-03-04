namespace HrisApp.Client.Pages.Dialog.Assets.MainAsset
{
    public partial class AddMainAssetAccessoryDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }
        [Parameter] public int Id { get; set; }
        [Parameter] public EventCallback OnAddSuccess { get; set; }

        private List<MainAssetAccessoriesT> listOfAccessories = new();
        private List<AssetAccessoryT> AssetAccessoryList = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();

        private AssetMasterT assetMaster = new();
        private MainAssetAccessoriesT obj = new();

        private string selectClass = "select-acc";

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
        }

        protected override async Task OnParametersSetAsync()
        {
            assetMaster = await AssetMasterService.GetSingleObj((int)Id);
            AssetAccessoryList = await AssetAccService.GetObjList();
        }

        private void Cancel() => MudDialog?.Cancel();

        private async Task SaveUpdate()
        {
            obj.AssetMasterId = assetMaster.Id;
            obj.AssetMasterCode = assetMaster.Code;

            var asset_acc = await AssetAccService.GetSingleObj(obj.AssetAccessoryId);
            asset_acc.MainAssetId = obj.AssetMasterId;
            asset_acc.MainAssetDateUpdated = DateTime.Now;
            asset_acc.AssetStatusId = assetMaster.AssetStatusId;
            await AssetAccService.UpdateObj(asset_acc);

            await MainAssetAccService.CreateObj(obj);
            await AssetAccService.GetObj();
            MudDialog?.Close();
            _toastService.ShowSuccess("Added Successfully!");
            await OnAddSuccess.InvokeAsync();
        }

        private bool disabledsubcat = true;
        private bool disabledacc = true;

        private void OnChangeCat(int id)
        {
            obj.CategoryId = id;
            disabledsubcat = false;
        }

        private void OnChangeSCat(int id)
        {
            obj.SubCategoryId = id;
            disabledacc = false;
        }

        //public void AddAccessory(int accId, string accCode)
        //{
        //    selectClass = "selected-acc";
        //    listOfAccessories.Add(new MainAssetAccessoriesT
        //    {
        //        AssetMasterId = assetMaster.Id,
        //        AssetMasterCode = assetMaster.Code,
        //        AssetAccessoryId = accId,
        //        AssetAccessoryCode = accCode
        //    });
        //}

        //public async Task CreateAccessoryRecords()
        //{
        //    foreach (var pri in listOfAccessories)
        //    {
        //        pri.AssetMasterCode = assetMaster.Code;
        //        pri.AssetMasterId = assetMaster.Id;
        //        await MainAssetAccService.CreateObj(pri);
        //    }

        //    listOfAccessories.Clear();
        //}
    }
}