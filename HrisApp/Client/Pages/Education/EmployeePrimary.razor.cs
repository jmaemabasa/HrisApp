namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeePrimary : ComponentBase
    {
        private PrimaryT _pri = new PrimaryT();
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
            primaryList = await EducationService.GetPrimarylist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<PrimaryT> primaryList = new List<PrimaryT>();
        private PrimaryT selectedItem1 = null;
        private HashSet<PrimaryT> selectedItems = new HashSet<PrimaryT>();

        private bool FilterFunc1(PrimaryT divisions) => FilterFunc(divisions, searchString1);

        private bool FilterFunc(PrimaryT employees, string searchString)
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
