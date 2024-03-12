namespace HrisApp.Client.Pages.Assets
{
#nullable disable

    public partial class AssetTypes : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(300);
            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (AssetTypeList == null || AssetTypeList.Count == 0)
            {
                OpenOverlay();
            }
        }

        private async Task LoadList()
        {
            await AssetTypeService.GetObj();
            StateService.SetState("AssetTypesList", AssetTypeService.AssetTypesTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            AssetTypeList = StateService.GetState<List<AssetTypesT>>("AssetTypesList");
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
        private List<AssetTypesT> AssetTypeList = new();
        private AssetTypesT selectedItem1 = null;

        private bool FilterFunc1(AssetTypesT area) => FilterFunc(area, searchString1);

        private bool FilterFunc(AssetTypesT area, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (area.AType_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateDialog(int id)
        {
            var parameters = new DialogParameters<UpdateAssetTypeDialog>();
            parameters.Add(x => x.Id, id);

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<UpdateAssetTypeDialog>("Update Asset Type", parameters, options);
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<AddAssetTypeDialog>("New Asset Type", options);
        }

        #endregion TABLES DATA
    }
}