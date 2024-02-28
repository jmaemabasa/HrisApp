using HrisApp.Client.Pages.Dialog.Assets.AssetSubCat;

namespace HrisApp.Client.Pages.Assets
{
#nullable disable

    public partial class AssetSubCategories : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(300);
            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (AssetSubCatList == null || AssetSubCatList.Count == 0)
            {
                OpenOverlay();
            }
        }

        private async Task LoadList()
        {
            await AssetSubCatService.GetObj();
            StateService.SetState("AssetSubCatList", AssetSubCatService.AssetSubCategoryTs);
        }

        private void OnStateChanged()
        {
            AssetSubCatList = StateService.GetState<List<AssetSubCategoryT>>("AssetSubCatList");
            StateHasChanged();
        }

        public bool _isVisible;

        public async void OpenOverlay()
        {
            _isVisible = false;
            await Task.Delay(2000);
            _isVisible = true;
            StateHasChanged();
        }

        #region TABLES DATA

        //TABLEEES
        private readonly string infoFormat = "{first_item}-{last_item} of {all_items}";

        private string searchString1 = "";
        private List<AssetSubCategoryT> AssetSubCatList = new();
        private AssetSubCategoryT selectedItem1 = null;

        private bool FilterFunc1(AssetSubCategoryT obj) => FilterFunc(obj, searchString1);

        private bool FilterFunc(AssetSubCategoryT obj, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (obj.ASubCat_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Category.ACat_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateDialog(int id)
        {
            var parameters = new DialogParameters<UpdateSubCategoryDialog>();
            parameters.Add(x => x.Id, id);

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<UpdateSubCategoryDialog>("Update Asset Sub Category", parameters, options);
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<AddAssetSubCategoryDialog>("New Asset Sub Category", options);
        }

        #endregion TABLES DATA
    }
}