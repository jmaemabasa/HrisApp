using HrisApp.Client.Pages.Dialog.MasterData.Vendor;

namespace HrisApp.Client.Pages.MasterData
{
#nullable disable
    public partial class Vendor : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(300);
            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (VendorService.VendorTs == null || VendorService.VendorTs.Count == 0)
            {
                OpenOverlay();
            }
        }

        private async Task LoadList()
        {
            await VendorService.GetObj();
            StateService.SetState("VendorList", VendorService.VendorTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            ObjectList = StateService.GetState<List<VendorT>>("VendorList");
            StateHasChanged();
        }

        private bool isVisible;

        public async void OpenOverlay()
        {
            isVisible = false;
            await Task.Delay(2000);
            isVisible = true;
            StateHasChanged();
        }

        #region TABLES DATA

        //TABLEEES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";

        private string searchString1 = "";
        private List<VendorT> ObjectList = new();
        private VendorT selectedItem1 = null;

        private bool FilterFunc1(VendorT obj) => FilterFunc(obj, searchString1);

        private bool FilterFunc(VendorT obj, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (obj.Code.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateDialog(int id)
        {
            var parameters = new DialogParameters<UpdateVendorDialog>
            {
                { x => x.Id, id }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, DisableBackdropClick = true, MaxWidth = MaxWidth.ExtraSmall, NoHeader = true };
            DialogService.Show<UpdateVendorDialog>("Update Vendor", parameters, options);
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, DisableBackdropClick = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<AddVendorDialog>("New Vendor", options);
        }

        #endregion TABLES DATA
    }
}
