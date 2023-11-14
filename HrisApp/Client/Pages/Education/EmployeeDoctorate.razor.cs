using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeDoctorate : ComponentBase
    {
        List<Emp_DoctorateT> doctorateList = new List<Emp_DoctorateT>();
        private Emp_DoctorateT selectedItem1 = null;

        private Emp_DoctorateT doctorate = new Emp_DoctorateT();
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
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "DoctorateT", $"Doctorate Verify_Id: {doctorate.Verify_Id} created successfully.", "_", DateTime.Now);
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
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "DoctorateT", $"Doctorate Verify_Id: {doctorate.Verify_Id} deleted successfully.", JsonConvert.SerializeObject(doctorateList), DateTime.Now);
            doctorateList = await EducationService.GetDoctoratelist(VerifyCode);
        }
    }
}
