namespace HrisApp.Client.Pages.Applicant.Education
{
#nullable disable
    public partial class AppOtherEduc : ComponentBase
    {
        //TABLEEES
        List<App_OtherEducT> otheredList = new List<App_OtherEducT>();
        private App_OtherEducT selectedItem1 = null;

        //END FOR TABLES

        private App_OtherEducT othered = new App_OtherEducT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool OtherEducOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            OtherEducOpen = (drawerx == "OtherEducOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveCollege()
        {
            othered.Verify_Id = VerifyCode;
            await EducationService.CreateOtherEduc(othered);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            othered.OthersSchoolType = "";
            othered.OthersSchoolName = "";
            othered.OthersSchoolLoc = "";
            othered.OthersCourse = "";
            othered.OthersAward = "";
            othered.OthersSchoolYear = "";
            otheredList = await EducationService.GetOtherEduclist(VerifyCode);
            OtherEducOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                otheredList = await EducationService.GetOtherEduclist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteOther(int id)
        {
            await EducationService.DeleteOtherEduc(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            otheredList = await EducationService.GetOtherEduclist(VerifyCode);
        }
    }
}
