using HrisApp.Client.Pages.Dialog.Assets.AssetAccess;

namespace HrisApp.Client.Pages.Assets
{
#nullable disable

    public partial class AssetAccessories : ComponentBase
    {
        private List<AssetAccessoryT> AssetAccessList = new();
        private List<AssetCategoryT> CATEGORIES = new();
        private List<AssetStatusT> ASSSTATUS = new();

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(300);
            CATEGORIES = await AssetCatService.GetObjList();
            await StaticService.GetAssetStatus();
            ASSSTATUS = StaticService.AssetStatusTs;

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

        public string CmbCatText = "All Category";
        public string CmbStatusText = "All Status";

        public void CmbCategory(int catid)
        {
            if (catid == 0)
            {
                CmbCatText = "All Category";

                if (CmbStatusText != "All Status")
                {
                    AssetAccessList = AssetAccService.AssetAccessoryTs.Where(e => e.AssetStatus?.Name == CmbStatusText).ToList();
                }
                else
                {
                    AssetAccessList = AssetAccService.AssetAccessoryTs;
                }
            }
            else
            {
                foreach (var e in CATEGORIES)
                {
                    if (e.Id == catid)
                    {
                        CmbCatText = e.ACat_Name;
                    }
                }

                if (CmbStatusText != "All Status")
                {
                    AssetAccessList = AssetAccService.AssetAccessoryTs.Where(e => e.AssetStatus?.Name == CmbStatusText && e.CategoryId == catid).ToList();
                }
                else
                {
                    AssetAccessList = AssetAccService.AssetAccessoryTs.Where(e => e.CategoryId == catid).ToList();
                }
            }

            if (AssetAccessList == null || AssetAccessList.Count == 0)
            {
                OpenOverlay();
            }
        }

        public void SearchStatus(int statusid)
        {
            if (statusid == 0)
            {
                CmbStatusText = "All Status";

                if (CmbCatText != "All Category")
                {
                    AssetAccessList = AssetAccService.AssetAccessoryTs.Where(e => e.Category?.ACat_Name == CmbCatText).ToList();
                }
                else
                {
                    AssetAccessList = AssetAccService.AssetAccessoryTs;
                }
            }
            else
            {
                foreach (var e in ASSSTATUS)
                {
                    if (e.Id == statusid)
                    {
                        CmbStatusText = e.Name;
                    }
                }

                if (CmbCatText != "All Category")
                {
                    AssetAccessList = AssetAccService.AssetAccessoryTs.Where(e => e.Category?.ACat_Name == CmbCatText && e.AssetStatusId == statusid).ToList();
                }
                else
                {
                    AssetAccessList = AssetAccService.AssetAccessoryTs.Where(e => e.AssetStatusId == statusid).ToList();
                }
            }

            if (AssetAccessList == null || AssetAccessList.Count == 0)
            {
                OpenOverlay();
            }
        }

        #region TABLES DATA

        //TABLEEES
        private readonly string infoFormat = "{first_item}-{last_item} of {all_items}";

        private string searchString1 = "";
        private AssetAccessoryT selectedItem1 = null;

        private bool FilterFunc1(AssetAccessoryT obj) => FilterFunc(obj, searchString1);

        private bool FilterFunc(AssetAccessoryT obj, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (obj.AssetCode.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Model.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Serial.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Category.ACat_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.AssetStatus.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
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
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, DisableBackdropClick = true, MaxWidth = MaxWidth.Small, NoHeader = true };
            DialogService.Show<AddAssetAccDialog>("New Asset Accessorry", options);
        }

        #endregion TABLES DATA
    }
}