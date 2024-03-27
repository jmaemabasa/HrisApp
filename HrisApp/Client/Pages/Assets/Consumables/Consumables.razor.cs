namespace HrisApp.Client.Pages.Assets.Consumables
{
    public partial class Consumables : ComponentBase
    {
        private List<ConsumablesT> AssetMasterList = new();

        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        private ConsumablesT selectedItem1 = null;

        private List<AssetCategoryT> CATEGORIES = new();
        private List<AssetStatusT> ASSSTATUS = new();

        protected override async Task OnInitializedAsync()
        {
            CATEGORIES = await AssetCatService.GetObjList();
            await StaticService.GetAssetStatus();
            ASSSTATUS = StaticService.AssetStatusTs;
            await Task.Delay(300);
            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (AssetMasterList == null || AssetMasterList.Count == 0)
            {
                OpenOverlay();
            }

            //foreach (var item in AssetMasterList)
            //{
            //    await AssetImg(item.AssetCode);
            //}
        }

        private async Task LoadList()
        {
            await ConsumablesService.GetObj();
            StateService.SetState("ConsumableList", ConsumablesService.ConsumablesTs);
        }

        private void OnStateChanged()
        {
            AssetMasterList = StateService.GetState<List<ConsumablesT>>("ConsumableList");
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

        private void OpenUpdateDialog(int id)
        {
            NavigationManager.NavigateTo($"/asset-consumable/details/{id}");
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Large, DisableBackdropClick = true, NoHeader = true };
            DialogService.Show<AddConsumableDialog>("New Consumable", options);
        }

        #region FILTER

        private bool FilterFunc1(ConsumablesT obj) => FilterFunc(obj, searchString1);

        private bool FilterFunc(ConsumablesT obj, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (obj.AssetCode.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Cons_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Category.ACat_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        public string CmbCatText = "All Category";
        public string CmbStatusText = "All Status";

        public void CmbCategory(int catid)
        {
            if (catid == 0)
            {
                CmbCatText = "All Category";

                AssetMasterList = ConsumablesService.ConsumablesTs;
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

                AssetMasterList = ConsumablesService.ConsumablesTs.Where(e => e.CategoryId == catid).ToList();
            }

            if (AssetMasterList == null || AssetMasterList.Count == 0)
            {
                OpenOverlay();
            }
        }

        #endregion FILTER
    }
}