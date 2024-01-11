namespace HrisApp.Client.Pages.Applicant.Education
{
#nullable disable
    public partial class AppSecondary : ComponentBase
    {
        //TABLEEES
        List<App_SecondaryT> secondaryList = new List<App_SecondaryT>();
        private App_SecondaryT selectedItem1 = null;

        //END FOR TABLES

        private App_SecondaryT sec = new App_SecondaryT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool SecondaryOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            SecondaryOpen = (drawerx == "SecondaryOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveSecondary()
        {
            sec.Verify_Id = VerifyCode;
            await EducationService.CreateSecondary(sec);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            sec.SecSchoolName = "";
            sec.SecSchoolLoc = "";
            sec.SecAward = "";
            sec.SecSchoolYear = "";
            secondaryList = await EducationService.GetSecondarylist(VerifyCode);
            SecondaryOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                secondaryList = await EducationService.GetSecondarylist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteSecondary(int id)
        {
            await EducationService.DeleteSecondary(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            secondaryList = await EducationService.GetSecondarylist(VerifyCode);
        }
    }
}
