using HrisApp.Client.Pages.Dialog.Assets.MainAsset;
using HrisApp.Client.Pages.Dialog.Assets.Vehicle;

namespace HrisApp.Client.Pages.Assets.Vehicles
{
#nullable disable
    public partial class Vehicles : ComponentBase
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

            if (VehicleMasterList == null || VehicleMasterList.Count == 0)
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
            await AssetVehicleService.GetObj();
            StateService.SetState("VehicleMasterList", AssetMasterService.AssetMasterTs);
        }

        private void OnStateChanged()
        {
            VehicleMasterList = StateService.GetState<List<AssetVehiclesT>>("VehicleMasterList");
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
        private List<AssetVehiclesT> VehicleMasterList = new();
        private AssetVehiclesT selectedItem1 = null;

        private bool FilterFunc1(AssetVehiclesT obj) => FilterFunc(obj, searchString1);

        private bool FilterFunc(AssetVehiclesT obj, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (obj.AssetCode.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Model.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Category.ACat_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.AssetStatus.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;

            if (obj.Serial.Contains(searchString, StringComparison.OrdinalIgnoreCase))
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
            DialogService.Show<AddVehicleDialog>("New Vehicle", options);
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
                    VehicleMasterList = AssetVehicleService.AssetVehiclesTs.Where(e => e.AssetStatus?.Name == CmbStatusText).ToList();
                }
                else
                {
                    VehicleMasterList = AssetVehicleService.AssetVehiclesTs;
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
                    VehicleMasterList = AssetVehicleService.AssetVehiclesTs.Where(e => e.AssetStatus?.Name == CmbStatusText && e.CategoryId == catid).ToList();
                }
                else
                {
                    VehicleMasterList = AssetVehicleService.AssetVehiclesTs.Where(e => e.CategoryId == catid).ToList();
                }
            }

            if (VehicleMasterList == null || VehicleMasterList.Count == 0)
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
                    VehicleMasterList = AssetVehicleService.AssetVehiclesTs.Where(e => e.Category?.ACat_Name == CmbCatText).ToList();
                }
                else
                {
                    VehicleMasterList = AssetVehicleService.AssetVehiclesTs;
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
                    VehicleMasterList = AssetVehicleService.AssetVehiclesTs.Where(e => e.Category?.ACat_Name == CmbCatText && e.AssetStatusId == statusid).ToList();
                }
                else
                {
                    VehicleMasterList = AssetVehicleService.AssetVehiclesTs.Where(e => e.AssetStatusId == statusid).ToList();
                }
            }

            if (VehicleMasterList == null || VehicleMasterList.Count == 0)
            {
                OpenOverlay();
            }
        }
    }
}
