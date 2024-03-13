namespace HrisApp.Client.Pages.Education
{
#nullable disable

    public partial class EmployeeSHS : ComponentBase
    {
        //TABLEEES
        private List<Emp_SeniorHST> shsList = new();

        private Emp_SeniorHST selectedItem1 = null;

        //END FOR TABLES

        private Emp_SeniorHST senior = new();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool SeniorOpen;
        private Anchor anchor;
        private readonly string width = "500px", height = "100%";

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            SeniorOpen = (drawerx == "SeniorOpen");
            this.anchor = anchor;
        }

        protected async Task SaveSenior()
        {
            senior.Verify_Id = VerifyCode;
            await EducationService.CreateSeniorHS(senior);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
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

        private async Task DeleteSenior(int id)
        {
            await EducationService.DeleteSHS(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            shsList = await EducationService.GetSeniorHSlist(VerifyCode);
        }
    }
}