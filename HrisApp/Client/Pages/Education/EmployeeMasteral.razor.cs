namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeMasteral : ComponentBase
    {
        private MasteralT masteral = new MasteralT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool MasteralOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            MasteralOpen = (drawerx == "MasteralOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveCollege()
        {
            masteral.Verify_Id = VerifyCode;
            await EducationService.CreateMasteral(masteral);
            masteral.MasSchoolName = "";
            masteral.MasSchoolLoc = "";
            masteral.MasCourse = "";
            masteral.MasAward = "";
            masteral.MasSchoolYear = "";
            masteralList = await EducationService.GetMasterallist(VerifyCode);
            MasteralOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                masteralList = await EducationService.GetMasterallist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteMasteral(int id)
        {
            await EducationService.DeleteMasteral(id);
            masteralList = await EducationService.GetMasterallist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<MasteralT> masteralList = new List<MasteralT>();
        private MasteralT selectedItem1 = null;
        private HashSet<MasteralT> selectedItems = new HashSet<MasteralT>();

        private bool FilterFunc1(MasteralT item) => FilterFunc(item, searchString1);

        private bool FilterFunc(MasteralT item, string searchString)
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
