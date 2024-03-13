namespace HrisApp.Client.Pages.Education
{
#nullable disable

    public partial class EmployeeCollege : ComponentBase
    {
        //TABLEEES
        private List<Emp_CollegeT> collegeList = new();

        private Emp_CollegeT selectedItem1 = null;

        private readonly Emp_CollegeT college = new();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool CollegeOpen;
        private Anchor anchor;
        private readonly string _width = "500px";
        private readonly string _height = "100%";

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            CollegeOpen = (drawerx == "CollegeOpen");
            this.anchor = anchor;
        }

        protected async Task SaveCollege()
        {
            college.Verify_Id = VerifyCode;
            await EducationService.CreateCollege(college);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
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

        private async Task DeleteCollege(int id)
        {
            await EducationService.DeleteCollege(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            collegeList = await EducationService.GetCollegelist(VerifyCode);
        }
    }
}