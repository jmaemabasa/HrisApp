namespace HrisApp.Client.Pages.Education
{
#nullable disable

    public partial class EmployeePrimary : ComponentBase
    {
        //TABLEEES
        private List<Emp_PrimaryT> primaryList = new();

        private Emp_PrimaryT selectedItem1 = null;

        //END FOR TABLES

        private Emp_PrimaryT _pri = new();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool _primaryOpen;
        private Anchor _anchor;
        private readonly string _width = "500px", height = "100%";

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            _primaryOpen = (drawerx == "PrimaryOpen");
            this._anchor = anchor;
        }

        protected async Task SavePrimary()
        {
            _pri.Verify_Id = VerifyCode;
            await EducationService.CreatePrimary(_pri);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            _pri.PriSchoolName = "";
            _pri.PriSchoolLoc = "";
            _pri.PriAward = "";
            _pri.PriSchoolYear = "";
            primaryList = await EducationService.GetPrimarylist(VerifyCode);
            _primaryOpen = false;
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                primaryList = await EducationService.GetPrimarylist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task DeletePrimary(int id)
        {
            await EducationService.DeletePrimary(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            primaryList = await EducationService.GetPrimarylist(VerifyCode);
        }
    }
}