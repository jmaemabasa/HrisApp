namespace HrisApp.Client.Pages.Dialog.Assets.AssetCat
{
    public partial class UpdateAssetCatDialog : ComponentBase
    {
        [CascadingParameter] MudDialogInstance? MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }

        private AssetCategoryT obj = new();

        void Cancel() => MudDialog?.Cancel();

        protected override async Task OnParametersSetAsync()
        {
            //area = AreaService.AreaTs.Find(d => d.Id == Id);
            obj = await AssetCatService.GetSingleObj((int)Id);
        }

        private async Task UpdateSave()
        {
            if (obj == null)
                return;

            if (string.IsNullOrWhiteSpace(obj.ACat_Name))
            {
                GlobalConfigService.OpenWarningDialog("Please fill up the name.");
            }
            else
            {
                MudDialog?.Close();
                var confirmResult = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Confirmation",
                    Text = "Are you sure you want to update the " + obj.ACat_Name + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    await AssetCatService.UpdateObj(obj);
                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                    _toastService.ShowSuccess(obj.ACat_Name + " Updated Successfully!");

                    // Update the List using the StateService
                    StateService.SetState("AssetCatList", await AssetCatService.GetObjList());
                }
            }
        }
    }
}
