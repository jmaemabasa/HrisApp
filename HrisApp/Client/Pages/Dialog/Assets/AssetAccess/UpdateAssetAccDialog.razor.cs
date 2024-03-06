namespace HrisApp.Client.Pages.Dialog.Assets.AssetAccess
{
    public partial class UpdateAssetAccDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }
        [Parameter] public int Id { get; set; }

        private bool isUpdating = false;

        private AssetAccessoryT obj = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();
        private List<AssetStatusT> STATUS = new();

        private void Cancel() => MudDialog?.Cancel();

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
            await StaticService.GetAssetStatus();
            STATUS = StaticService.AssetStatusTs;
        }

        protected override async Task OnParametersSetAsync()
        {
            obj = await AssetAccService.GetSingleObj((int)Id);
        }

        private async Task SaveUpdate()
        {
            if (obj.AssetStatusId == 2 || obj.AssetStatusId == 1)
            {
                obj.StatusDate = null;
            }
            await AssetAccService.UpdateObj(obj);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

            _toastService.ShowSuccess(obj.AssetCode + " Updated Successfully!");

            // Update the List using the StateService
            StateService.SetState("AssetAccList", await AssetAccService.GetObjList());
            obj = await AssetAccService.GetSingleObj((int)Id);
            isUpdating = false;
        }

        private bool IsEndOfUsefulLife()
        {
            if (obj.PurchaseDate.HasValue)
            {
                DateTime purchaseDate = obj.PurchaseDate.Value;
                DateTime endOfUsefulLife = purchaseDate.AddMonths(Convert.ToInt32(obj.EUF));
                return DateTime.Today > endOfUsefulLife;
            }
            return false;
        }

        public void UpdateForm() => isUpdating = !isUpdating;
    }
}