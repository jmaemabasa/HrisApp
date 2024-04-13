using HrisApp.Client.Pages.Dialog.Announcement;

namespace HrisApp.Client.Pages.Announcement
{
#nullable disable

    public partial class Announcement : ComponentBase
    {
        public List<AnnouncementT> _announceList = new();
        private AnnouncementT selectedItem1 = null;
        private string infoFormat = "{first_item}-{last_item} of {all_items}";

        //LOADING
        public bool _isVisible;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(300);
            StateService.OnChange += OnStateChanged;
            await LoadList();

            if (_announceList == null || _announceList.Count == 0)
            {
                _isVisible = true;
            }
        }

        private async Task LoadList()
        {
            await AnnouncementService.GetAnnouncement();
            _announceList = AnnouncementService.AnnouncementTs.OrderBy(a => a.DateStart).ToList();

            // Then, reorder announcements based on their date ranges
            var currentTime = DateTime.Now;

            var currentAnnouncements = _announceList.Where(a => a.DateStart <= currentTime && a.DateEnd >= currentTime).ToList();
            var upcomingAnnouncements = _announceList.Where(a => a.DateStart > currentTime).ToList();
            var pastAnnouncements = _announceList.Where(a => a.DateEnd < currentTime).ToList();

            // Concatenate the sorted announcement lists
            _announceList = currentAnnouncements.Concat(upcomingAnnouncements).Concat(pastAnnouncements).ToList();
            StateService.SetState("AnnouncementList", _announceList);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            _announceList = StateService.GetState<List<AnnouncementT>>("AnnouncementList");
            StateHasChanged();
        }

        bool isCurrentClick = false, isUpcomingClick = false, isPastClick = false;
        string clsCurrent = "clsMainCurrent", clsUpcoming = "clsMainUpcoming", clsPast = "clsMainPast";
        string dotCurr = "dotCurr", dotSoon = "dotSoon", dotDone = "dotDone";
        private async Task FilterAnnouncement(int type)
        {
            if (type == 1)
            {
                isCurrentClick = !isCurrentClick;
                clsCurrent = isCurrentClick ? "clsCurrent" : "clsMainCurrent";
                dotCurr = isCurrentClick ? "dotCurrClick" : "dotCurr";
            }
            if (type == 2)
            {
                isUpcomingClick = !isUpcomingClick;
                clsUpcoming = isUpcomingClick ? "clsUpcoming" : "clsMainUpcoming";
                dotSoon = isUpcomingClick ? "dotSoonClick" : "dotSoon";
            }
            if (type == 3)
            {
                isPastClick = !isPastClick;
                clsPast = isPastClick ? "clsPast" : "clsMainPast";
                dotDone = isPastClick ? "dotDoneClick" : "dotDone";
            }

            await AnnouncementService.GetAnnouncement();
            _announceList = AnnouncementService.AnnouncementTs.OrderBy(a => a.DateStart).ToList();
            var currentTime = DateTime.Now;

            if (!isCurrentClick && !isUpcomingClick && !isPastClick)
            {
                //if all buttons are not pressed
                var currentAnnouncements = _announceList.Where(a => a.DateStart <= currentTime && a.DateEnd >= currentTime).ToList();
                var upcomingAnnouncements = _announceList.Where(a => a.DateStart > currentTime).ToList();
                var pastAnnouncements = _announceList.Where(a => a.DateEnd < currentTime).ToList();
                _announceList = currentAnnouncements.Concat(upcomingAnnouncements).Concat(pastAnnouncements).ToList();
            }
            else if (isCurrentClick && !isUpcomingClick && !isPastClick)
            {
                //if current
                var upcomingAnnouncements = _announceList.Where(a => a.DateStart > currentTime).ToList();
                var pastAnnouncements = _announceList.Where(a => a.DateEnd < currentTime).ToList();
                _announceList = (upcomingAnnouncements).Concat(pastAnnouncements).ToList();
            }
            else if (!isCurrentClick && isUpcomingClick && !isPastClick)
            {
                //ifupcoming
                var currentAnnouncements = _announceList.Where(a => a.DateStart <= currentTime && a.DateEnd >= currentTime).ToList();
                var pastAnnouncements = _announceList.Where(a => a.DateEnd < currentTime).ToList();
                _announceList = currentAnnouncements.Concat(pastAnnouncements).ToList();
            }
            else if (!isCurrentClick && !isUpcomingClick && isPastClick)
            {
                //if past
                var currentAnnouncements = _announceList.Where(a => a.DateStart <= currentTime && a.DateEnd >= currentTime).ToList();
                var upcomingAnnouncements = _announceList.Where(a => a.DateStart > currentTime).ToList();
                _announceList = currentAnnouncements.Concat(upcomingAnnouncements).ToList();
            }
            else if (isCurrentClick && isUpcomingClick && !isPastClick)
            {
                //if current upcoming
                var pastAnnouncements = _announceList.Where(a => a.DateEnd < currentTime).ToList();
                _announceList = (pastAnnouncements);
            }
            else if (!isCurrentClick && isUpcomingClick && isPastClick)
            {
                //if all buttons are not pressed
                var currentAnnouncements = _announceList.Where(a => a.DateStart <= currentTime && a.DateEnd >= currentTime).ToList();
                _announceList = currentAnnouncements;
            }
            else if (isCurrentClick && !isUpcomingClick && isPastClick)
            {
                //if all buttons are not pressed
                var upcomingAnnouncements = _announceList.Where(a => a.DateStart > currentTime).ToList();
                _announceList = upcomingAnnouncements;
            }
            else
            {
                _announceList = null;
            }
        }

        private void OpenAddDialog()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, DisableBackdropClick=true };
            DialogService.Show<AddAnnounceDialog>("New Announcement", options);
        }

        private void OpenViewAnnoun(int id)
        {
            var parameters = new DialogParameters<UpdateAnnounceDialog>();
            parameters.Add(x => x.Id, id);
            parameters.Add(x => x.FromPage, "Announcement");

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, NoHeader = true, DisableBackdropClick = true };
            DialogService.Show<UpdateAnnounceDialog>("", parameters, options);
        }
    }
}