namespace HrisApp.Client.Pages.Dialog.Assets.AssetCat
{
    public partial class AddAssetCategoryDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }

        private AssetCategoryT obj = new();

        private void Cancel() => MudDialog?.Cancel();

        protected override async Task OnInitializedAsync()
        {
            await OnGenerateCode();
        }

        private async Task ConfirmCreate()
        {
            if (string.IsNullOrWhiteSpace(obj.ACat_Name))
            {
                GlobalConfigService.OpenWarningDialog("Please fill up the name.");
            }
            else
            {
                MudDialog?.Close();
                await AssetCatService.CreateObj(obj);

                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                _toastService.ShowSuccess(obj.ACat_Name + " Created Successfully!");

                // Update the List using the StateService
                StateService.SetState("AssetCatList", await AssetCatService.GetObjList());
            }
        }

        private async Task OnGenerateCode()
        {
            int lastCount = await AssetCatService.GetLastCode() + 1;
            string rolesCode = lastCount.ToString().PadLeft(2, '0');
            obj.ACat_Code = "CAT" + rolesCode;
        }
    }
}