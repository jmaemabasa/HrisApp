namespace HrisApp.Client.Pages.MasterData
{
    public partial class External : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            try
            {
                await Task.Delay(500);
                StateService.OnChange += OnStateChanged;
                await LoadList();

                if (externalList == null || externalList.Count == 0)
                {
                    OpenOverlay();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task LoadList()
        {
            await ManpowerService.GetExternal();
            StateService.SetState("ExternalList", ManpowerService.PosMPExternalTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            externalList = StateService.GetState<List<PosMPExternalT>>("ExternalList");
            StateHasChanged();
        }


        #region table
        //LOADING
        private bool isVisible;
        public async void OpenOverlay()
        {
            isVisible = false;
            await Task.Delay(2000);
            isVisible = true;
            StateHasChanged();
        }

        //TABLEEES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<PosMPExternalT> externalList = new();
        private PosMPExternalT selectedItem1 = null;
        private HashSet<PosMPExternalT> selectedItems = new();

        private bool FilterFunc1(PosMPExternalT obj) => FilterFunc(obj, searchString1);

        private static bool FilterFunc(PosMPExternalT obj, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (obj.External_Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateExternal(int id)
        {
            var parameters = new DialogParameters<UpdateExternalDialog>
            {
                { x => x.Id, id }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<UpdateExternalDialog>("Update", parameters, options);
        }

        private void OpenAddExternal()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.ExtraSmall };
            DialogService.Show<AddExternalDialog>("New", options);
        }
        #endregion
    }
}
