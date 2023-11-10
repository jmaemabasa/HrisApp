using HrisApp.Shared.Models.Education;
using HrisApp.Shared.Models.LiscenseAndTraining;
using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeMasteral : ComponentBase
    {
        private MasteralT masteral = new MasteralT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool MasteralOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            MasteralOpen = (drawerx == "MasteralOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveCollege()
        {
            masteral.Verify_Id = VerifyCode;
            await EducationService.CreateMasteral(masteral);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "MasteralT", $"Masteral Verify_Id: {masteral.Verify_Id} created successfully.", "_", DateTime.Now);
            masteral.MasSchoolName = "";
            masteral.MasSchoolLoc = "";
            masteral.MasCourse = "";
            masteral.MasAward = "";
            masteral.MasSchoolYear = "";
            masteralList = await EducationService.GetMasterallist(VerifyCode);
            MasteralOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                masteralList = await EducationService.GetMasterallist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteMasteral(int id)
        {
            await EducationService.DeleteMasteral(id);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "MasteralT", $"Masteral Verify_Id: {masteral.Verify_Id} deleted successfully.", JsonConvert.SerializeObject(masteralList), DateTime.Now);
            masteralList = await EducationService.GetMasterallist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<MasteralT> masteralList = new List<MasteralT>();
        private MasteralT selectedItem1 = null;
        private HashSet<MasteralT> selectedItems = new HashSet<MasteralT>();

        private bool FilterFunc1(MasteralT item) => FilterFunc(item, searchString1);

        private bool FilterFunc(MasteralT item, string searchString)
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
