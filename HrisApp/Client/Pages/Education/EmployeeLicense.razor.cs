namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeLicense : ComponentBase
    {
        private LicenseT license = new LicenseT();
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
            license.Examination = "";
            license.ProfMembership = "";
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
            licenseList = await LicenseTrainingService.GetLicenselist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<LicenseT> licenseList = new List<LicenseT>();
        private LicenseT selectedItem1 = null;
        private HashSet<LicenseT> selectedItems = new HashSet<LicenseT>();

        private bool FilterFunc1(LicenseT item) => FilterFunc(item, searchString1);

        private bool FilterFunc(LicenseT item, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            // if (employees.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            //     return true;
            return false;
        }
        //END FOR TABLES
    }
}
