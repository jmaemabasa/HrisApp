namespace HrisApp.Client.Pages.MasterData
{
    public partial class Division : ComponentBase
    {
        private DivisionT divisions = new DivisionT();

        protected override async Task OnInitializedAsync()
        {
            try
            {
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
            await DivisionService.GetDivision();
            StateService.SetState("DivisionList", DivisionService.DivisionTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            divisionList = StateService.GetState<List<DivisionT>>("DivisionList");
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
        List<DivisionT> divisionList = new List<DivisionT>();
        private DivisionT selectedItem1 = null;
        private HashSet<DivisionT> selectedItems = new HashSet<DivisionT>();

        private bool FilterFunc1(DivisionT divisions) => FilterFunc(divisions, searchString1);

        private bool FilterFunc(DivisionT employees, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (employees.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateDivision(int id)
        {
            var parameters = new DialogParameters<UpdateDivisionDialog>();
            parameters.Add(x => x.Id, id);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<UpdateDivisionDialog>("Update Division", parameters, options);
        }

        private void OpenAddDivision()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddDivisionDialog>("New Division", options);
        }
        #endregion
    }
}
