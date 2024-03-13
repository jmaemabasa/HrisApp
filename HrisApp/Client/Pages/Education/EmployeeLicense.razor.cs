namespace HrisApp.Client.Pages.Education
{
#nullable disable

    public partial class EmployeeLicense : ComponentBase
    {
        //TABLEEES
        private List<Emp_LicenseT> licenseList = new();

        private Emp_LicenseT selectedItem1 = null;
        //END FOR TABLES

        private Emp_LicenseT license = new();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool LicenseOpen;
        private Anchor anchor;
        private string width = "500px", height = "100%";

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            LicenseOpen = (drawerx == "LicenseOpen");
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

        private async Task DeleteLicense(int id)
        {
            await LicenseTrainingService.DeleteLicense(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            licenseList = await LicenseTrainingService.GetLicenselist(VerifyCode);
        }
    }
}