namespace HrisApp.Client.Pages.MasterData
{
    public partial class Internal : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            try
            {
                await Task.Delay(500);
                StateService.OnChange += OnStateChanged;
                await LoadList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task LoadList()
        {
            await ManpowerService.GetInternal();
            StateService.SetState("InternalList", ManpowerService.PosMPInternalTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            internalList = StateService.GetState<List<PosMPInternalT>>("InternalList");
            StateHasChanged();
        }


        #region table
        //LOADING
        private bool isVisible;
        public async void OpenOverlay()
        {
            isVisible = true;
            await Task.Delay(3000);
            isVisible = false;
            StateHasChanged();
        }

        //TABLEEES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<PosMPInternalT> internalList = new();
        private PosMPInternalT selectedItem1 = null;
        private HashSet<PosMPInternalT> selectedItems = new();

        private bool FilterFunc1(PosMPInternalT obj) => FilterFunc(obj, searchString1);

        private static bool FilterFunc(PosMPInternalT obj, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (obj.Internal_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateInternal(int id)
        {
            var parameters = new DialogParameters<UpdateInternalDialog>
            {
                { x => x.Id, id }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<UpdateInternalDialog>("Update", parameters, options);
        }

        private void OpenAddInternal()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddInternalDialog>("New", options);
        }
        #endregion
    }
}
