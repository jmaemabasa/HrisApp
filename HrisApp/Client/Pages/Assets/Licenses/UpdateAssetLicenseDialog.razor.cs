namespace HrisApp.Client.Pages.Assets.Licenses
{
    public partial class UpdateAssetLicenseDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }
        [Parameter] public int Id { get; set; }

        private AssetLicenseT obj = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();
        private List<AssetStatusT> STATUS = new();
        private string AccessImageData { get; set; } = string.Empty;

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
            obj = await AssLicenseSvc.GetSingleObj(Id);

            try
            {
                await LoadAccessImg(obj.JMCode);//image
            }
            catch (Exception)
            {
                AccessImageData = string.Format("images/asset-holder.jpg");
            }
        }

        private async Task LoadAccessImg(string jmcode)
        {
            var imagemodel = await AssLicenseImgSvc.GetImageData(jmcode);
            if (imagemodel != null)
            {
                var base642 = Convert.ToBase64String(imagemodel);
                AccessImageData = string.Format("data:image/png;base64,{0}", base642);
            }
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
    }
}