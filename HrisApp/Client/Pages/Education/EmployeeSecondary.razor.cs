using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeSecondary : ComponentBase
    {
        //TABLEEES
        List<Emp_SecondaryT> secondaryList = new List<Emp_SecondaryT>();
        private Emp_SecondaryT selectedItem1 = null;

        //END FOR TABLES

        private Emp_SecondaryT sec = new Emp_SecondaryT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool SecondaryOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            SecondaryOpen = (drawerx == "SecondaryOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveSecondary()
        {
            sec.Verify_Id = VerifyCode;
            await EducationService.CreateSecondary(sec);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE Secondary", DateTime.Now);
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

        async Task DeleteSecondary(int id)
        {
            await EducationService.DeleteSecondary(id);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "DELETE Secondary", DateTime.Now);
            secondaryList = await EducationService.GetSecondarylist(VerifyCode);
        }
    }
}
