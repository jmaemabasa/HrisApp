namespace HrisApp.Client.Pages.Education
{
#nullable disable

    public partial class EmployeeSecondary : ComponentBase
    {
        //TABLEEES
        private List<Emp_SecondaryT> secondaryList = new();

        private Emp_SecondaryT selectedItem1 = null;

        //END FOR TABLES

        private Emp_SecondaryT sec = new();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool SecondaryOpen;
        private Anchor anchor;
        private readonly string width = "500px", height = "100%";

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            SecondaryOpen = (drawerx == "SecondaryOpen");
            this.anchor = anchor;
        }

        protected async Task SaveSecondary()
        {
            sec.Verify_Id = VerifyCode;
            await EducationService.CreateSecondary(sec);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            sec.SecSchoolName = "";
            sec.SecSchoolLoc = "";
            sec.SecAward = "";
            sec.SecSchoolYear = "";
            secondaryList = await EducationService.GetSecondarylist(VerifyCode);
            SecondaryOpen = false;
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                secondaryList = await EducationService.GetSecondarylist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task DeleteSecondary(int id)
        {
            await EducationService.DeleteSecondary(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            secondaryList = await EducationService.GetSecondarylist(VerifyCode);
        }
    }
}