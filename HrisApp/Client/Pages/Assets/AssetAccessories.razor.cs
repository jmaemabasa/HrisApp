using HrisApp.Client.Pages.Dialog.Assets.AssetAccess;

namespace HrisApp.Client.Pages.Assets
{
#nullable disable

    public partial class AssetAccessories : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(300);
            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (AssetAccessList == null || AssetAccessList.Count == 0)
            {
                OpenOverlay();
            }
        }

        private async Task LoadList()
        {
            await AssetAccService.GetObj();
            StateService.SetState("AssetAccList", AssetAccService.AssetAccessoryTs);
        }

        private void OnStateChanged()
        {
            AssetAccessList = StateService.GetState<List<AssetAccessoryT>>("AssetAccList");
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
        private List<AssetAccessoryT> AssetAccessList = new();
        private AssetAccessoryT selectedItem1 = null;

        private bool FilterFunc1(AssetAccessoryT area) => FilterFunc(area, searchString1);

        private bool FilterFunc(AssetAccessoryT area, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (area.Brand.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (area.Model.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateDialog(int id)
        {
            NavigationManager.NavigateTo($"/asset-accessories/details/{id}");
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small };
            DialogService.Show<AddAssetAccDialog>("New Asset Accessorry", options);
        }

        #endregion TABLES DATA
    }
}