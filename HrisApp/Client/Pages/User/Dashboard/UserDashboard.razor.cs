using HrisApp.Client.Pages.Dialog.Announcement;

namespace HrisApp.Client.Pages.User.Dashboard
{
#nullable disable

    public partial class UserDashboard : ComponentBase
    {
        private string FULLNAME = "";
        private string VERIFY = "";
        private string availableLeavetext = "";
        private string availableLeavetextEL = "";
        private string availableLeavetextML = "";
        private string availableLeavetextPL = "";
        private string availableLeavetextVL = "";
        private string availableLeavetextOL = "";
        private double countSl, countEl, countMl, countPl, countVl, countOl;

        private Emp_LeaveCreditT empLeaveCred = new();
        private List<AnnouncementT> announceL = new();

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1);
            var globalId = Convert.ToInt32(GlobalConfigService.User_Id);
            FULLNAME = await EmployeeService.Getname(globalId);

            VERIFY = GlobalConfigService.VerifyId;
            empLeaveCred = await LeaveCredService.GetSingleLeaveCredByVerId(VERIFY);
            await SetValues();

            announceL = await AnnouncementService.GetFilteredAnnouncementList();

        }

        private async Task SetValues()
        {
            countSl = await LeaveCredService.GetCountExistCredits(VERIFY, "Sick");
            countEl = await LeaveCredService.GetCountExistCredits(VERIFY, "Emergency");
            countMl = await LeaveCredService.GetCountExistCredits(VERIFY, "Maternity");
            countPl = await LeaveCredService.GetCountExistCredits(VERIFY, "Paternity");
            countVl = await LeaveCredService.GetCountExistCredits(VERIFY, "Vacation");
            countOl = await LeaveCredService.GetCountExistCredits(VERIFY, "Other");

            availableLeavetext = (((Convert.ToDouble(empLeaveCred.SL) - countSl) / Convert.ToDouble(empLeaveCred.SL)) * 100).ToString() + "%";
            availableLeavetextEL = (((Convert.ToDouble(empLeaveCred.EL) - countEl) / Convert.ToDouble(empLeaveCred.EL)) * 100).ToString() + "%";
            availableLeavetextML = (((Convert.ToDouble(empLeaveCred.ML) - countMl) / Convert.ToDouble(empLeaveCred.ML)) * 100).ToString() + "%";
            availableLeavetextPL = (((Convert.ToDouble(empLeaveCred.PL) - countPl) / Convert.ToDouble(empLeaveCred.PL)) * 100).ToString() + "%";
            availableLeavetextVL = (((Convert.ToDouble(empLeaveCred.VL) - countVl) / Convert.ToDouble(empLeaveCred.VL)) * 100).ToString() + "%";
            availableLeavetextOL = (((Convert.ToDouble(empLeaveCred.OL) - countOl) / Convert.ToDouble(empLeaveCred.OL)) * 100).ToString() + "%";
        }

        private void OpenViewAnnoun(int id)
        {
            var parameters = new DialogParameters<UpdateAnnounceDialog>
            {
                { x => x.Id, id },
                { x => x.FromPage, "Dashboard" }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, NoHeader = true };
            DialogService.Show<UpdateAnnounceDialog>("", parameters, options);
        }

        private static string GetGreeting()
        {
            var currentTime = DateTime.Now;
            var currentHour = currentTime.Hour;

            if (currentHour < 12)
            {
                return "Good morning";
            }
            else if (currentHour < 18)
            {
                return "Good afternoon";
            }
            else
            {
                return "Good evening";
            }
        }
    }
}