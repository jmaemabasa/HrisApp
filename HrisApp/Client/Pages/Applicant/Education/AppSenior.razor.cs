namespace HrisApp.Client.Pages.Applicant.Education
{
#nullable disable
    public partial class AppSenior : ComponentBase
    {
        //TABLEEES
        List<App_SeniorHST> shsList = new List<App_SeniorHST>();
        private App_SeniorHST selectedItem1 = null;

        //END FOR TABLES

        private App_SeniorHST senior = new App_SeniorHST();
        [Parameter]
        public string VerifyCode { get; set; }

        bool SeniorOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            SeniorOpen = (drawerx == "SeniorOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveSenior()
        {
            senior.Verify_Id = VerifyCode;
            await EducationService.CreateSeniorHS(senior);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            senior.ShsSchoolName = "";
            senior.ShsSchoolLoc = "";
            senior.ShsAward = "";
            senior.ShsSchoolYear = "";
            shsList = await EducationService.GetSeniorHSlist(VerifyCode);
            SeniorOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                shsList = await EducationService.GetSeniorHSlist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteSenior(int id)
        {
            await EducationService.DeleteSHS(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            shsList = await EducationService.GetSeniorHSlist(VerifyCode);
        }
    }
}
