namespace HrisApp.Client.Pages.MasterData
{
    public partial class Schedule : ComponentBase
    {
#nullable disable

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
            await ScheduleService.GetScheduleList();
            StateService.SetState("SchedList", ScheduleService.ScheduleTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            scheduleList = StateService.GetState<List<ScheduleTypeT>>("SchedList");
            StateHasChanged();
        }

        #region function
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
        private readonly string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<ScheduleTypeT> scheduleList = new();
        private ScheduleTypeT selectedItem1 = null;
        private readonly HashSet<ScheduleTypeT> selectedItems = new();

        private bool FilterFunc1(ScheduleTypeT items) => FilterFunc(items, searchString1);

        private bool FilterFunc(ScheduleTypeT items, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (items.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        //END FOR TABLES

        //OPEN DIALOGS
        private void OpenUpdateScheudle(int id)
        {
            var parameters = new DialogParameters<UpdateScheduleDialog>
            {
                { x => x.Id, id }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<UpdateScheduleDialog>("Update Schedule", parameters, options);
        }

        private void OpenAddSchedule()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddScheduleDialog>("New Schedule", options);
        }
        #endregion
    }
}
