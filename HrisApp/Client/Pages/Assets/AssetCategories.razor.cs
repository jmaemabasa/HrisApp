namespace HrisApp.Client.Pages.Assets
{
    public partial class AssetCategories : ComponentBase
    {
        protected override async Task OnInitializedAsync()

        {
            await Task.Delay(300);
            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (AssetCatList == null || AssetCatList.Count == 0)
            {
                OpenOverlay();
            }
        }

        private async Task LoadList()
        {
            await AssetCatService.GetObj();
            StateService.SetState("AssetCatList", AssetCatService.AssetCategoryTs);
        }

        private void OnStateChanged()
        {
            AssetCatList = StateService.GetState<List<AssetCategoryT>>("AssetCatList");
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
        private string infoFormat = "{first_item}-{last_item} of {all_items}";

        private string searchString1 = "";
        private List<AssetCategoryT> AssetCatList = new();
        private AssetCategoryT selectedItem1 = null;

        private bool FilterFunc1(AssetCategoryT area) => FilterFunc(area, searchString1);

        private bool FilterFunc(AssetCategoryT area, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (area.ACat_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateDialog(int id)
        {
            var parameters = new DialogParameters<UpdateAssetCatDialog>();
            parameters.Add(x => x.Id, id);

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<UpdateAssetCatDialog>("Update Asset Category", parameters, options);
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<AddAssetCategoryDialog>("New Asset Category", options);
        }

        #endregion TABLES DATA
    }
}