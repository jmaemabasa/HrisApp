namespace HrisApp.Client.Pages.Education
{
#nullable disable

    public partial class EmployeeOtherEduc : ComponentBase
    {
        //TABLEEES
        private List<Emp_OtherEducT> otheredList = new();

        private Emp_OtherEducT selectedItem1 = null;

        //END FOR TABLES

        private Emp_OtherEducT othered = new();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool OtherEducOpen;
        private Anchor anchor;
        private readonly string width = "500px", height = "100%";

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            OtherEducOpen = (drawerx == "OtherEducOpen");
            this.anchor = anchor;
        }

        protected async Task SaveCollege()
        {
            othered.Verify_Id = VerifyCode;
            await EducationService.CreateOtherEduc(othered);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            othered.OthersSchoolType = "";
            othered.OthersSchoolName = "";
            othered.OthersSchoolLoc = "";
            othered.OthersCourse = "";
            othered.OthersAward = "";
            othered.OthersSchoolYear = "";
            otheredList = await EducationService.GetOtherEduclist(VerifyCode);
            OtherEducOpen = false;
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                otheredList = await EducationService.GetOtherEduclist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task DeleteOther(int id)
        {
            await EducationService.DeleteOtherEduc(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            otheredList = await EducationService.GetOtherEduclist(VerifyCode);
        }
    }
}