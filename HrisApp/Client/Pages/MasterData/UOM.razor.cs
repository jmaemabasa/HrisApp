namespace HrisApp.Client.Pages.MasterData
{
#nullable disable
    public partial class UOM : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(300);
            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (UOMService.UOMTs == null || UOMService.UOMTs.Count == 0)
            {
                OpenOverlay();
            }
        }

        private async Task LoadList()
        {
            await UOMService.GetObj();
            StateService.SetState("UOMList", UOMService.UOMTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            ObjectList = StateService.GetState<List<UOMT>>("UOMList");
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
        private List<UOMT> ObjectList = new();
        private UOMT selectedItem1 = null;

        private bool FilterFunc1(UOMT obj) => FilterFunc(obj, searchString1);

        private bool FilterFunc(UOMT obj, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (obj.Code.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            if (obj.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }

        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateDialog(int id)
        {
            var parameters = new DialogParameters<UpdateAreaDialog>
            {
                { x => x.Id, id }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall, NoHeader=true };
            DialogService.Show<UpdateUOMDialog>("Update UOM", parameters, options);
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<AddUOMDialog>("New UOM", options);
        }

        #endregion TABLES DATA
    }
}
