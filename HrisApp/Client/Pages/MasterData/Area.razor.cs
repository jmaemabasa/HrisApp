﻿namespace HrisApp.Client.Pages.MasterData
{
    public partial class Area : ComponentBase
    {
        protected override async Task OnInitializedAsync()
        {
            StateService.OnChange += OnStateChanged;
            await LoadAreaList();
        }

        private async Task LoadAreaList()
        {
            await AreaService.GetArea();
            StateService.SetState("AreaList", AreaService.AreaTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            areaList = StateService.GetState<List<AreaT>>("AreaList");
            StateHasChanged();
        }

        private bool isVisible;
        public async void OpenOverlay()
        {
            isVisible = true;
            await Task.Delay(3000);
            isVisible = false;
            StateHasChanged();
        }

        #region TABLES DATA
        //TABLEEES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<AreaT> areaList = new();
        private AreaT selectedItem1 = null;
        private HashSet<AreaT> selectedItems = new HashSet<AreaT>();

        private bool FilterFunc1(AreaT area) => FilterFunc(area, searchString1);

        private bool FilterFunc(AreaT area, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (area.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateArea(int id)
        {
            var parameters = new DialogParameters<UpdateAreaDialog>();
            parameters.Add(x => x.Id, id);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<UpdateAreaDialog>("Update Area", parameters, options);
        }

        private void OpenAddArea()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddAreaDialog>("New Area", options);
        }
        #endregion
    }
}
