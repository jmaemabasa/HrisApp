namespace HrisApp.Client.Pages.Assets.Licenses
{
#nullable disable
    public partial class AssetLicenses : ComponentBase
    {
        private List<AssetLicenseT> AssetLicenseList = new();
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

            if (AssetLicenseList == null || AssetLicenseList.Count == 0)
            {
                OpenOverlay();
            }
        }

        private async Task LoadList()
        {
            await AssLicenseSvc.GetObj();
            StateService.SetState("AssetLicenseList", AssLicenseSvc.AssetLicenseTs);
        }

        private void OnStateChanged()
        {
            AssetLicenseList = StateService.GetState<List<AssetLicenseT>>("AssetLicenseList");
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
                    AssetLicenseList = AssLicenseSvc.AssetLicenseTs.Where(e => e.AssetStatus?.Name == CmbStatusText).ToList();
                }
                else
                {
                    AssetLicenseList = AssLicenseSvc.AssetLicenseTs;
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
                    AssetLicenseList = AssLicenseSvc.AssetLicenseTs.Where(e => e.AssetStatus?.Name == CmbStatusText && e.CategoryId == catid).ToList();
                }
                else
                {
                    AssetLicenseList = AssLicenseSvc.AssetLicenseTs.Where(e => e.CategoryId == catid).ToList();
                }
            }

            if (AssetLicenseList == null || AssetLicenseList.Count == 0)
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
                    AssetLicenseList = AssLicenseSvc.AssetLicenseTs.Where(e => e.Category?.ACat_Name == CmbCatText).ToList();
                }
                else
                {
                    AssetLicenseList = AssLicenseSvc.AssetLicenseTs;
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
                    AssetLicenseList = AssLicenseSvc.AssetLicenseTs.Where(e => e.Category?.ACat_Name == CmbCatText && e.AssetStatusId == statusid).ToList();
                }
                else
                {
                    AssetLicenseList = AssLicenseSvc.AssetLicenseTs.Where(e => e.AssetStatusId == statusid).ToList();
                }
            }

            if (AssetLicenseList == null || AssetLicenseList.Count == 0)
            {
                OpenOverlay();
            }
        }

        #region TABLES DATA

        //TABLEEES
        private readonly string infoFormat = "{first_item}-{last_item} of {all_items}";

        private string searchString1 = "";
        private AssetLicenseT selectedItem1 = null;

        private bool FilterFunc1(AssetLicenseT obj) => FilterFunc(obj, searchString1);

        private bool FilterFunc(AssetLicenseT obj, string searchString)
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
            NavigationManager.NavigateTo($"/asset-license/details/{id}");
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, DisableBackdropClick = true, MaxWidth = MaxWidth.Small, NoHeader = true };
            DialogService.Show<AddAssetLicenseDialog>("New Asset License", options);
        }

        #endregion TABLES DATA
    }
}
