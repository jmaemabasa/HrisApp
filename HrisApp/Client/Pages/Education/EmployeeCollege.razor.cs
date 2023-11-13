using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeCollege : ComponentBase
    {
        private readonly Emp_CollegeT college = new Emp_CollegeT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool CollegeOpen;
        Anchor anchor;
        private readonly string _width = "500px";
        private readonly string _height = "100%";

        void OpenDrawer(Anchor anchor, string drawerx)
        {
            CollegeOpen = (drawerx == "CollegeOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveCollege()
        {
            college.Verify_Id = VerifyCode;
            await EducationService.CreateCollege(college);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "CollegeT", $"College Verify_Id: {college.Verify_Id} created successfully.", "_", DateTime.Now);
            college.CollSchoolName = "";
            college.CollSchoolLoc = "";
            college.CollAward = "";
            college.CollSchoolYear = "";
            collegeList = await EducationService.GetCollegelist(VerifyCode);
            CollegeOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                collegeList = await EducationService.GetCollegelist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteCollege(int id)
        {
            await EducationService.DeleteCollege(id);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "CollegeT", $"College Verify_Id: {college.Verify_Id} deleted successfully.", JsonConvert.SerializeObject(collegeList), DateTime.Now);
            collegeList = await EducationService.GetCollegelist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<Emp_CollegeT> collegeList = new List<Emp_CollegeT>();
        private Emp_CollegeT selectedItem1 = null;
        private HashSet<Emp_CollegeT> selectedItems = new HashSet<Emp_CollegeT>();

        private bool FilterFunc1(Emp_CollegeT item) => FilterFunc(item, searchString1);

        private static bool FilterFunc(Emp_CollegeT item, string searchString)
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
