﻿namespace HrisApp.Client.Pages.MasterData
{
    public partial class Area : ComponentBase
    {
        private AreaT areas = new AreaT();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await AreaService.GetAreaList();
                areaList = AreaService.AreaTs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //TABLEEES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<AreaT> areaList = new List<AreaT>();
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
    }
}