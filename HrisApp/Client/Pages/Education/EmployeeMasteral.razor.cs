namespace HrisApp.Client.Pages.Education
{
#nullable disable

    public partial class EmployeeMasteral : ComponentBase
    {
        //TABLEEES
        private List<Emp_MasteralT> masteralList = new();

        private Emp_MasteralT selectedItem1 = null;

        //END FOR TABLES

        private readonly Emp_MasteralT masteral = new();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool MasteralOpen;
        private Anchor anchor;
        private readonly string width = "500px", height = "100%";

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            MasteralOpen = (drawerx == "MasteralOpen");
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

        private async Task DeleteMasteral(int id)
        {
            await EducationService.DeleteMasteral(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            masteralList = await EducationService.GetMasterallist(VerifyCode);
        }
    }
}