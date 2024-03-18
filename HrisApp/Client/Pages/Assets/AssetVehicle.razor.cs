namespace HrisApp.Client.Pages.Assets
{
#nullable disable

    public partial class AssetVehicle : ComponentBase
    {
        private List<AssetCategoryT> CATEGORIES = new();
        private List<AssetSubCategoryT> SUBCATEGORIES = new();
        private List<AssetStatusT> ASSSTATUS = new();

        protected override async Task OnInitializedAsync()
        {
            CATEGORIES = await AssetCatService.GetObjList();
            SUBCATEGORIES = await AssetSubCatService.GetObjList();
            await StaticService.GetAssetStatus();
            ASSSTATUS = StaticService.AssetStatusTs;
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
            if (area.WorksationName.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (area.Brand.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (area.Model.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (area.SubCategory.ASubCat_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (area.Category.ACat_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (area.AssetStatus.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateDialog(int id)
        {
            NavigationManager.NavigateTo($"/main-asset/details/{id}");
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Large, DisableBackdropClick = true, NoHeader = true };
            //DialogService.Show<AddMainAssetDialog>("New Main Asset", options);
        }

        #endregion TABLES DATA

        public string CmbCatText = "All Category";
        public string CmbStatusText = "All Status";

        public void CmbCategory(int catid)
        {
            if (catid == 0)
            {
                CmbCatText = "All Category";

                if (CmbStatusText != "All Status")
                {
                    AssetMasterList = AssetMasterService.AssetMasterTs.Where(e => e.AssetStatus?.Name == CmbStatusText).ToList();
                }
                else
                {
                    AssetMasterList = AssetMasterService.AssetMasterTs;
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
                    AssetMasterList = AssetMasterService.AssetMasterTs.Where(e => e.AssetStatus?.Name == CmbStatusText && e.CategoryId == catid).ToList();
                }
                else
                {
                    AssetMasterList = AssetMasterService.AssetMasterTs.Where(e => e.CategoryId == catid).ToList();
                }
            }

            if (AssetMasterList == null || AssetMasterList.Count == 0)
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
                    AssetMasterList = AssetMasterService.AssetMasterTs.Where(e => e.Category?.ACat_Name == CmbCatText).ToList();
                }
                else
                {
                    AssetMasterList = AssetMasterService.AssetMasterTs;
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
                    AssetMasterList = AssetMasterService.AssetMasterTs.Where(e => e.Category?.ACat_Name == CmbCatText && e.AssetStatusId == statusid).ToList();
                }
                else
                {
                    AssetMasterList = AssetMasterService.AssetMasterTs.Where(e => e.AssetStatusId == statusid).ToList();
                }
            }

            if (AssetMasterList == null || AssetMasterList.Count == 0)
            {
                OpenOverlay();
            }
        }
    }
}