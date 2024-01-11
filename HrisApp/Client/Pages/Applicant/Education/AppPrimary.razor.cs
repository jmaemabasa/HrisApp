namespace HrisApp.Client.Pages.Applicant.Education
{
#nullable disable
    public partial class AppPrimary : ComponentBase
    {
        //TABLEEES
        List<App_PrimaryT> primaryList = new List<App_PrimaryT>();
        private App_PrimaryT selectedItem1 = null;

        //END FOR TABLES

        private App_PrimaryT _pri = new App_PrimaryT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool _primaryOpen;
        Anchor _anchor;
        string _width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            _primaryOpen = (drawerx == "PrimaryOpen") ? true : false;
            this._anchor = anchor;
        }
        protected async Task SavePrimary()
        {
            _pri.Verify_Id = VerifyCode;
            await EducationService.CreatePrimary(_pri);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            _pri.PriSchoolName = "";
            _pri.PriSchoolLoc = "";
            _pri.PriAward = "";
            _pri.PriSchoolYear = "";
            primaryList = await EducationService.GetPrimarylist(VerifyCode);
            _primaryOpen = false;
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                primaryList = await EducationService.GetPrimarylist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeletePrimary(int id)
        {
            await EducationService.DeletePrimary(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            primaryList = await EducationService.GetPrimarylist(VerifyCode);
        }
    }
}
