namespace HrisApp.Client.Pages.Dialog.Assets.AssetType
{
#nullable disable

    public partial class AddAssetTypeDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        private AssetTypesT obj = new();

        private void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            await OnGenerateCode();
        }

        private async Task ConfirmCreateArea()
        {
            if (string.IsNullOrWhiteSpace(obj.AType_Name))
            {
                GlobalConfigService.OpenWarningDialog("Please fill up the name.");
            }
            else
            {
                MudDialog.Close();
                await AssetTypeService.CreateObj(obj);

                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                _toastService.ShowSuccess(obj.AType_Name + " Created Successfully!");

                // Update the List using the StateService
                StateService.SetState("AssetTypesList", await AssetTypeService.GetObjList());
            }
        }

        private async Task OnGenerateCode()
        {
            int lastCount = await AssetTypeService.GetLastCode() + 1;
            string rolesCode = lastCount.ToString().PadLeft(3, '0');
            obj.AType_Code = rolesCode;
        }
    }
}