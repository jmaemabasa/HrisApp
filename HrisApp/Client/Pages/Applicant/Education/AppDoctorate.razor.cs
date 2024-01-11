namespace HrisApp.Client.Pages.Applicant.Education
{
    public partial class AppDoctorate : ComponentBase
    {
        List<App_DoctorateT> doctorateList = new List<App_DoctorateT>();
        private App_DoctorateT selectedItem1 = null;

        private App_DoctorateT doctorate = new App_DoctorateT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool DoctorateOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            DoctorateOpen = (drawerx == "DoctorateOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveCollege()
        {
            doctorate.Verify_Id = VerifyCode;
            await EducationService.CreateDoctorate(doctorate);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            doctorate.DocSchoolName = "";
            doctorate.DocSchoolLoc = "";
            doctorate.DocCourse = "";
            doctorate.DocAward = "";
            doctorate.DocSchoolYear = "";
            doctorateList = await EducationService.GetDoctoratelist(VerifyCode);
            DoctorateOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                doctorateList = await EducationService.GetDoctoratelist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteDoc(int id)
        {
            await EducationService.DeleteDoctorate(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            doctorateList = await EducationService.GetDoctoratelist(VerifyCode);
        }
    }
}
