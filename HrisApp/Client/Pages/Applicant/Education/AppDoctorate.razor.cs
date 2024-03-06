namespace HrisApp.Client.Pages.Applicant.Education
{
#nullable disable

    public partial class AppDoctorate : ComponentBase
    {
        private List<App_DoctorateT> doctorateList = new();
        private App_DoctorateT selectedItem1 = null;

        private App_DoctorateT doctorate = new();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool DoctorateOpen;
        private Anchor anchor;

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            DoctorateOpen = (drawerx == "DoctorateOpen");
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

        private async Task DeleteDoc(int id)
        {
            await EducationService.DeleteDoctorate(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            doctorateList = await EducationService.GetDoctoratelist(VerifyCode);
        }
    }
}