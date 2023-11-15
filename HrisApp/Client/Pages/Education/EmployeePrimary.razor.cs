using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeePrimary : ComponentBase
    {
        //TABLEEES
        List<Emp_PrimaryT> primaryList = new List<Emp_PrimaryT>();
        private Emp_PrimaryT selectedItem1 = null;

        //END FOR TABLES

        private Emp_PrimaryT _pri = new Emp_PrimaryT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool _primaryOpen;
        Anchor _anchor;
        string _width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            _primaryOpen = (drawerx == "PrimaryOpen") ? true : false;
            this._anchor = anchor;
        }
        protected async Task SavePrimary()
        {
            _pri.Verify_Id = VerifyCode;
            await EducationService.CreatePrimary(_pri);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE Primary", DateTime.Now);
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

        async Task DeletePrimary(int id)
        {
            await EducationService.DeletePrimary(id);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "DELETE Primary", DateTime.Now);
            primaryList = await EducationService.GetPrimarylist(VerifyCode);
        }
    }
}
