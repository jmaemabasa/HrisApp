using HrisApp.Shared.Models.Employee.Emp_Education;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeUndergraduate : ComponentBase
    {//TABLEEES
        private List<Emp_UndergraduateT> objList = new();

        private Emp_UndergraduateT selectedItem1 = null;

        private Emp_UndergraduateT newObj = new();

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

        protected async Task SaveObj()
        {
            newObj.Verify_Id = VerifyCode;
            await EducationService.CreateUG(newObj);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            newObj = new();
            objList = await EducationService.GetUGlist(VerifyCode);
            CollegeOpen = false;
            StateHasChanged();
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                objList = await EducationService.GetUGlist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task DeleteObj(int id)
        {
            await EducationService.DeleteUG(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            objList = await EducationService.GetUGlist(VerifyCode);
        }
    }
}
