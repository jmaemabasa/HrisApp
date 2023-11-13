using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeLicense : ComponentBase
    {
        private Emp_LicenseT license = new Emp_LicenseT();
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
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "LicenseT", $"License Verify_Id: {license.Verify_Id} created successfully.", "_", DateTime.Now);
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
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "LicenseT", $"License Verify_Id: {license.Verify_Id} deleted successfully.", JsonConvert.SerializeObject(licenseList), DateTime.Now);
            licenseList = await LicenseTrainingService.GetLicenselist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<Emp_LicenseT> licenseList = new List<Emp_LicenseT>();
        private Emp_LicenseT selectedItem1 = null;
        private HashSet<Emp_LicenseT> selectedItems = new HashSet<Emp_LicenseT>();

        private bool FilterFunc1(Emp_LicenseT item) => FilterFunc(item, searchString1);

        private bool FilterFunc(Emp_LicenseT item, string searchString)
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
