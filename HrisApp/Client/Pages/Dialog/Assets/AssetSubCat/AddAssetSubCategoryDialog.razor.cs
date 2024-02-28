namespace HrisApp.Client.Pages.Dialog.Assets.AssetSubCat
{
    public partial class AddAssetSubCategoryDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }

        private AssetSubCategoryT obj = new();
        private List<AssetCategoryT> CategoriesL = new();

        private bool isEnableName = true;

        private void Cancel() => MudDialog?.Cancel();

        protected override async Task OnInitializedAsync()
        {
            await OnGenerateCode();
            CategoriesL = await AssetCatService.GetObjList();
        }

        private async Task ConfirmCreateArea()
        {
            if (string.IsNullOrWhiteSpace(obj.ASubCat_Name))
            {
                GlobalConfigService.OpenWarningDialog("Please fill up the name.");
            }
            else
            {
                MudDialog?.Close();
                await AssetSubCatService.CreateObj(obj);

                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                _toastService.ShowSuccess(obj.ASubCat_Name + " Created Successfully!");

                // Update the List using the StateService
                StateService.SetState("AssetSubCatList", await AssetSubCatService.GetObjList());
            }
        }

        private async Task OnGenerateCode()
        {
            int lastCount = await AssetSubCatService.GetLastCode() + 1;
            string rolesCode = lastCount.ToString().PadLeft(2, '0');
            obj.ASubCat_Code = "SCAT" + rolesCode;
        }

        private void OnChangeCat(int id)
        {
            obj.CategoryId = id;
            isEnableName = false;
        }
    }
}