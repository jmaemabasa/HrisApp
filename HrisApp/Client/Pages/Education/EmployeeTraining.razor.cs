﻿namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeTraining : ComponentBase
    {
        private TrainingT training = new TrainingT();
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
            training.TrainingName = "";
            training.Remarks = "";
            training.TrainingDate = DateTime.Today;
            trainingListt = await LicenseTrainingService.GetTraininglist(VerifyCode);
            TrainingOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                trainingListt = await LicenseTrainingService.GetTraininglist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteTraining(int id)
        {
            await LicenseTrainingService.DeleteTraining(id);
            trainingListt = await LicenseTrainingService.GetTraininglist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<TrainingT> trainingListt = new List<TrainingT>();
        private TrainingT selectedItem1 = null;
        private HashSet<TrainingT> selectedItems = new HashSet<TrainingT>();

        private bool FilterFunc1(TrainingT item) => FilterFunc(item, searchString1);

        private bool FilterFunc(TrainingT item, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;

            return false;
        }
        //END FOR TABLES
    }
}
