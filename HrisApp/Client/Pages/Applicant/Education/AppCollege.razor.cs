namespace HrisApp.Client.Pages.Applicant.Education
{
    public partial class AppCollege : ComponentBase
    {
        //TABLEEES
        List<App_CollegeT> collegeList = new();
        private App_CollegeT selectedItem1 = null;

        private readonly App_CollegeT college = new();
        [Parameter]
        public string VerifyCode { get; set; }

        bool CollegeOpen;
        Anchor anchor;
        private readonly string _width = "500px";
        private readonly string _height = "100%";

        void OpenDrawer(Anchor anchor, string drawerx)
        {
            CollegeOpen = (drawerx == "CollegeOpen");
            this.anchor = anchor;
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

    }
}
