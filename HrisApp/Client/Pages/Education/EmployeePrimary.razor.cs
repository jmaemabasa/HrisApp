using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeePrimary : ComponentBase
    {
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
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "PrimaryT", $"Primary Verify_Id: {_pri.Verify_Id} created successfully.", "_", DateTime.Now);
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
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "PrimaryT", $"Primary Verify_Id: {_pri.Verify_Id} deleted successfully.", JsonConvert.SerializeObject(primaryList), DateTime.Now);
            primaryList = await EducationService.GetPrimarylist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<Emp_PrimaryT> primaryList = new List<Emp_PrimaryT>();
        private Emp_PrimaryT selectedItem1 = null;
        private HashSet<Emp_PrimaryT> selectedItems = new HashSet<Emp_PrimaryT>();

        private bool FilterFunc1(Emp_PrimaryT divisions) => FilterFunc(divisions, searchString1);

        private bool FilterFunc(Emp_PrimaryT employees, string searchString)
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
