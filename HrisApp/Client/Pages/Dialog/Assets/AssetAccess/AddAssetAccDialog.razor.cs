namespace HrisApp.Client.Pages.Dialog.Assets.AssetAccess
{
    public partial class AddAssetAccDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }

        private AssetAccessoryT obj = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();

        private void Cancel() => MudDialog?.Cancel();

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
            await StaticService.GetAssetStatus();
            obj.AssetStatusId = 2;
        }

        private async Task ConfirmCreate()
        {
            await OnGenerateCode();
            await AssetAccService.CreateObj(obj);

            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

            MudDialog?.Close();
            _toastService.ShowSuccess(obj.MainAsset + " Created Successfully!");

            // Update the List using the StateService
            StateService.SetState("AssetAccList", await AssetAccService.GetObjList());
        }

        private async Task OnGenerateCode()
        {
            int lastCount = await AssetAccService.GetLastCode(obj.CategoryId, obj.SubCategoryId) + 1;

            var catcode = CAT.Where(e => e.Id == obj.CategoryId).FirstOrDefault()!.ACat_Code;
            var subcode = SUBCAT.Where(e => e.Id == obj.SubCategoryId).FirstOrDefault()!.ASubCat_Code;
            string rolesCode = lastCount.ToString().PadLeft(4, '0');
            obj.Code = $"{catcode}-{subcode}-{rolesCode}";
        }
    }
}