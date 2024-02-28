namespace HrisApp.Client.Pages.Dialog.Assets.AssetSubCat
{
    public partial class UpdateSubCategoryDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }
        private List<AssetCategoryT> CategoriesL = new();

        [Parameter]
        public int Id { get; set; }

        private AssetSubCategoryT obj = new();

        private void Cancel() => MudDialog?.Cancel();

        protected override async Task OnInitializedAsync()
        {
            CategoriesL = await AssetCatService.GetObjList();
        }

        protected override async Task OnParametersSetAsync()
        {
            obj = await AssetSubCatService.GetSingleObj((int)Id);
        }

        private async Task UpdateSave()
        {
            if (obj == null)
                return;

            if (string.IsNullOrWhiteSpace(obj.ASubCat_Name))
            {
                GlobalConfigService.OpenWarningDialog("Please fill up the name.");
            }
            else
            {
                MudDialog?.Close();
                var confirmResult = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Confirmation",
                    Text = "Are you sure you want to update the " + obj.ASubCat_Name + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    await AssetSubCatService.UpdateObj(obj);
                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                    _toastService.ShowSuccess(obj.ASubCat_Name + " Updated Successfully!");

                    // Update the List using the StateService
                    StateService.SetState("AssetSubCatList", await AssetSubCatService.GetObjList());
                }
            }
        }
    }
}