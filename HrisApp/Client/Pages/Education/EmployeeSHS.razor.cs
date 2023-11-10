using HrisApp.Shared.Models.Education;
using HrisApp.Shared.Models.LiscenseAndTraining;
using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeSHS : ComponentBase
    {
        private SeniorHST senior = new SeniorHST();
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
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "SHST", $"SHS Verify_Id: {senior.Verify_Id} created successfully.", "_", DateTime.Now);
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
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "SHST", $"SHS Verify_Id: {senior.Verify_Id} deleted successfully.", JsonConvert.SerializeObject(shsList), DateTime.Now);
            shsList = await EducationService.GetSeniorHSlist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<SeniorHST> shsList = new List<SeniorHST>();
        private SeniorHST selectedItem1 = null;
        private HashSet<SeniorHST> selectedItems = new HashSet<SeniorHST>();

        private bool FilterFunc1(SeniorHST item) => FilterFunc(item, searchString1);

        private bool FilterFunc(SeniorHST item, string searchString)
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
