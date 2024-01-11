namespace HrisApp.Client.Pages.Applicant.Education
{
#nullable disable
    public partial class AppLicense : ComponentBase
    {
        //TABLEEES
        List<App_LicenseT> licenseList = new List<App_LicenseT>();
        private App_LicenseT selectedItem1 = null;
        //END FOR TABLES

        private App_LicenseT license = new App_LicenseT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool LicenseOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            LicenseOpen = (drawerx == "LicenseOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveLicense()
        {
            license.Verify_Id = VerifyCode;
            await LicenseTrainingService.CreateLicense(license);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            license.Examination = "";
            license.Rating = "";
            license.LicenseNo = "";
            license.Date = DateTime.Today;
            licenseList = await LicenseTrainingService.GetLicenselist(VerifyCode);
            LicenseOpen = false;
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                licenseList = await LicenseTrainingService.GetLicenselist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteLicense(int id)
        {
            await LicenseTrainingService.DeleteLicense(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            licenseList = await LicenseTrainingService.GetLicenselist(VerifyCode);
        }
    }
}
