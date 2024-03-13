namespace HrisApp.Client.Pages.Education
{
#nullable disable

    public partial class EmployeeTraining : ComponentBase
    {
        //TABLEEES
        private List<Emp_TrainingT> _trainingListt = new();

        private Emp_TrainingT _selectedItem1 = null;

        //END FOR TABLES

        private Emp_TrainingT training = new();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool TrainingOpen;
        private Anchor anchor;
        private string width = "500px", height = "100%";

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            TrainingOpen = (drawerx == "TrainingOpen");
            this.anchor = anchor;
        }

        protected async Task SaveTraining()
        {
            training.Verify_Id = VerifyCode;
            await LicenseTrainingService.CreateTraining(training);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
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

        private async Task DeleteTraining(int id)
        {
            await LicenseTrainingService.DeleteTraining(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            _trainingListt = await LicenseTrainingService.GetTraininglist(VerifyCode);
        }
    }
}