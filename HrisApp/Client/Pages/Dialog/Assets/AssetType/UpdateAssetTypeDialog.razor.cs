namespace HrisApp.Client.Pages.Dialog.Assets.AssetType
{
    public partial class UpdateAssetTypeDialog : ComponentBase
    {
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }

        private AssetTypesT obj = new();

        void Cancel() => MudDialog?.Cancel();

        protected override async Task OnParametersSetAsync()
        {
            //area = AreaService.AreaTs.Find(d => d.Id == Id);
            obj = await AssetTypeService.GetSingleObj((int)Id);
        }

        private async Task UpdateSave()
        {
            if (obj == null)
                return;

            if (string.IsNullOrWhiteSpace(obj.AType_Name))
            {
                GlobalConfigService.OpenWarningDialog("Please fill up the name.");
            }
            else
            {
                MudDialog?.Close();
                var confirmResult = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Confirmation",
                    Text = "Are you sure you want to update the " + obj.AType_Name + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    await AssetTypeService.UpdateObj(obj);
                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                    _toastService.ShowSuccess(obj.AType_Name + " Updated Successfully!");

                    // Update the List using the StateService
                    StateService.SetState("AssetTypesList", await AssetTypeService.GetObjList());
                }
            }
        }
    }
}
