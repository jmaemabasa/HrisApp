using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeMasteral : ComponentBase
    {
        //TABLEEES
        List<Emp_MasteralT> masteralList = new List<Emp_MasteralT>();
        private Emp_MasteralT selectedItem1 = null;

        //END FOR TABLES

        private Emp_MasteralT masteral = new Emp_MasteralT();
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
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
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
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            masteralList = await EducationService.GetMasterallist(VerifyCode);
        }
    }
}
