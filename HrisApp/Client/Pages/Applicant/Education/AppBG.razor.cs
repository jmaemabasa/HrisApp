namespace HrisApp.Client.Pages.Applicant.Education
{
#nullable disable

    public partial class AppBG : ComponentBase
    {
        //TABLEEES
        private List<App_ProfBackgroundT> _profBgListt = new();

        private App_ProfBackgroundT _selectedItem1 = null;

        //END FOR TABLES

        private App_ProfBackgroundT profBg = new();

        [Parameter]
        public string VerifyCode { get; set; }

        private bool ProfBgOpen;

        //private Anchor anchor;
        //private string width = "500px", height = "100%";

        //private void OpenDrawer(Anchor anchor, string drawerx)
        //{
        //    ProfBgOpen = true;
        //    this.anchor = anchor;
        //}

        //protected async Task SaveBg()
        //{
        //    profBg.Verify_Id = VerifyCode;
        //    await LicenseTrainingService.CreateProfBg(profBg);
        //    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
        //    profBg.DateFrom = DateTime.Today;
        //    profBg.DateTo = DateTime.Today;
        //    profBg.CompanyName = "";
        //    profBg.Position = "";
        //    profBg.BasicSalary = "";
        //    profBg.RSLeaving = "";
        //    _profBgListt = await LicenseTrainingService.GetProfBglist(VerifyCode);
        //    ProfBgOpen = false;

        //}

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

        private async Task DeleteProfbg(int id)
        {
            await LicenseTrainingService.DeleteProfBg(id);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);
            _profBgListt = await LicenseTrainingService.GetProfBglist(VerifyCode);
        }
    }
}