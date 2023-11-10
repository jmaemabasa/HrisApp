using HrisApp.Shared.Models.Education;
using HrisApp.Shared.Models.LiscenseAndTraining;
using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeOtherEduc : ComponentBase
    {
        private OtherEducT othered = new OtherEducT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool OtherEducOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            OtherEducOpen = (drawerx == "OtherEducOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveCollege()
        {
            othered.Verify_Id = VerifyCode;
            await EducationService.CreateOtherEduc(othered);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "OtherEducT", $"OtherEduc Verify_Id: {othered.Verify_Id} created successfully.", "_", DateTime.Now);
            othered.OthersSchoolType = "";
            othered.OthersSchoolName = "";
            othered.OthersSchoolLoc = "";
            othered.OthersCourse = "";
            othered.OthersAward = "";
            othered.OthersSchoolYear = "";
            otheredList = await EducationService.GetOtherEduclist(VerifyCode);
            OtherEducOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                otheredList = await EducationService.GetOtherEduclist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteOther(int id)
        {
            await EducationService.DeleteOtherEduc(id);
            await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "OtherEducT", $"OtherEduc Verify_Id: {othered.Verify_Id} deleted successfully.", JsonConvert.SerializeObject(otheredList), DateTime.Now);
            otheredList = await EducationService.GetOtherEduclist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<OtherEducT> otheredList = new List<OtherEducT>();
        private OtherEducT selectedItem1 = null;
        private HashSet<OtherEducT> selectedItems = new HashSet<OtherEducT>();

        private bool FilterFunc1(OtherEducT item) => FilterFunc(item, searchString1);

        private bool FilterFunc(OtherEducT item, string searchString)
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
