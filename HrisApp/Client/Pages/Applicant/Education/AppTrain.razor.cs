namespace HrisApp.Client.Pages.Applicant.Education
{
#nullable disable

    public partial class AppTrain : ComponentBase
    {
        //TABLEEES
        private List<App_TrainingT> _trainingListt = new List<App_TrainingT>();

        private App_TrainingT _selectedItem1 = null;

        //END FOR TABLES

        private App_TrainingT training = new App_TrainingT();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool TrainingOpen;
        private Anchor anchor;

        //string width = "500px", height = "100%";
        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            TrainingOpen = (drawerx == "TrainingOpen") ? true : false;
            this.anchor = anchor;
        }

        //protected async Task SaveTraining()
        //{
        //    training.Verify_Id = VerifyCode;
        //    await LicenseTrainingService.CreateTraining(training);
        //    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
        //    training.TrainingName = "";
        //    training.SponsorSpeaker = "";
        //    training.TrainingDate = DateTime.Today;
        //    _trainingListt = await LicenseTrainingService.GetTraininglist(VerifyCode);
        //    TrainingOpen = false;

        //}

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