namespace HrisApp.Client.Pages.MasterData
{
    public partial class Schedule : ComponentBase
    {
#nullable disable
        private ScheduleTypeT schedules = new ScheduleTypeT();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await ScheduleService.GetScheduleList();
                scheduleList = ScheduleService.ScheduleTs;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);

            }
        }

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
        List<ScheduleTypeT> scheduleList = new List<ScheduleTypeT>();
        private ScheduleTypeT selectedItem1 = null;
        private HashSet<ScheduleTypeT> selectedItems = new HashSet<ScheduleTypeT>();

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
            var parameters = new DialogParameters<UpdateScheduleDialog>();
            parameters.Add(x => x.Id, id);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<UpdateScheduleDialog>("Update Schedule", parameters, options);
        }

        private void OpenAddSchedule()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddScheduleDialog>("New Schedule", options);
        }
    }
}
