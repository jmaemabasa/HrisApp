using HrisApp.Client.Pages.Dialog.Assets.AssetAccess;
using HrisApp.Client.Pages.Dialog.Assets.MainAsset;

namespace HrisApp.Client.Pages.Assets
{
#nullable disable

    public partial class AssetMain : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(300);
            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (AssetMasterList == null || AssetMasterList.Count == 0)
            {
                OpenOverlay();
            }
        }

        private async Task LoadList()
        {
            await AssetMasterService.GetObj();
            StateService.SetState("AssetMasterList", AssetMasterService.AssetMasterTs);
        }

        private void OnStateChanged()
        {
            AssetMasterList = StateService.GetState<List<AssetMasterT>>("AssetMasterList");
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
        private List<AssetMasterT> AssetMasterList = new();
        private AssetMasterT selectedItem1 = null;

        private bool FilterFunc1(AssetMasterT area) => FilterFunc(area, searchString1);

        private bool FilterFunc(AssetMasterT area, string searchString)
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
            //var parameters = new DialogParameters<UpdateMainAssetDialog>();
            //parameters.Add(x => x.Id, id);

            //var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium };
            //DialogService.Show<UpdateMainAssetDialog>("", parameters, options);
            NavigationManager.NavigateTo($"/main-asset/details/{id}");
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, DisableBackdropClick = true };
            DialogService.Show<AddMainAssetDialog>("New Main Asset", options);
        }

        #endregion TABLES DATA
    }
}