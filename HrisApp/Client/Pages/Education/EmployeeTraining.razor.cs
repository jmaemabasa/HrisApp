using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeTraining : ComponentBase
    {
        private Emp_TrainingT training = new Emp_TrainingT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool TrainingOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            TrainingOpen = (drawerx == "TrainingOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveTraining()
        {
            training.Verify_Id = VerifyCode;
            await LicenseTrainingService.CreateTraining(training);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "TrainingT", $"Training Verify_Id: {training.Verify_Id} created successfully.", "_", DateTime.Now);
            training.TrainingName = "";
            training.SponsorSpeaker = "";
            training.TrainingDate = DateTime.Today;
            _trainingListt = await LicenseTrainingService.GetTraininglist(VerifyCode);
            TrainingOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                _trainingListt = await LicenseTrainingService.GetTraininglist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteTraining(int id)
        {
            await LicenseTrainingService.DeleteTraining(id);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "TrainingT", $"Training Verify_Id: {training.Verify_Id} deleted successfully.", JsonConvert.SerializeObject(_trainingListt), DateTime.Now);
            _trainingListt = await LicenseTrainingService.GetTraininglist(VerifyCode);
        }


        //TABLEEES
        private string _searchString1 = "";
        List<Emp_TrainingT> _trainingListt = new List<Emp_TrainingT>();
        private Emp_TrainingT _selectedItem1 = null;
        private HashSet<Emp_TrainingT> _selectedItems = new HashSet<Emp_TrainingT>();

        private bool FilterFunc1(Emp_TrainingT item) => FilterFunc(item, _searchString1);

        private bool FilterFunc(Emp_TrainingT item, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            return false;
        }
        //END FOR TABLES
    }
}
