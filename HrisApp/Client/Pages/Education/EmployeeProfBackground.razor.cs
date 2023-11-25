namespace HrisApp.Client.Pages.Education
{
    public partial class EmployeeProfBackground : ComponentBase
    {
        //TABLEEES
        List<Emp_ProfBackgroundT> _profBgListt = new List<Emp_ProfBackgroundT>();
        private Emp_ProfBackgroundT _selectedItem1 = null;

        //END FOR TABLES

        private Emp_ProfBackgroundT profBg = new Emp_ProfBackgroundT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool ProfBgOpen
            ;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            ProfBgOpen = true;
            this.anchor = anchor;
        }
        protected async Task SaveBg()
        {
            profBg.Verify_Id = VerifyCode;
            await LicenseTrainingService.CreateProfBg(profBg);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            profBg.DateFrom = DateTime.Today;
            profBg.DateTo = DateTime.Today;
            profBg.CompanyName = "";
            profBg.Position = "";
            profBg.BasicSalary = "";
            profBg.RSLeaving = "";
            _profBgListt = await LicenseTrainingService.GetProfBglist(VerifyCode);
            ProfBgOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                _profBgListt = await LicenseTrainingService.GetProfBglist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteProfbg(int id)
        {
            await LicenseTrainingService.DeleteProfBg(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            _profBgListt = await LicenseTrainingService.GetProfBglist(VerifyCode);
        }
    }
}
