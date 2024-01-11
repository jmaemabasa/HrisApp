namespace HrisApp.Client.Pages.Applicant.Education
{
#nullable disable
    public partial class AppOtherAwards : ComponentBase
    {
        //TABLEEES
        List<App_OtherAwardsT> _trainingListt = new List<App_OtherAwardsT>();
        private App_OtherAwardsT _selectedItem1 = null;

        //END FOR TABLES

        private App_OtherAwardsT training = new App_OtherAwardsT();
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
                _trainingListt = await LicenseTrainingService.GetOtherAwardslist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteTraining(int id)
        {
            await LicenseTrainingService.DeleteOtherAwards(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            _trainingListt = await LicenseTrainingService.GetOtherAwardslist(VerifyCode);
        }
    }
}
