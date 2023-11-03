﻿namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeSecondary : ComponentBase
    {
        private SecondaryT sec = new SecondaryT();
        [Parameter]
        public string VerifyCode { get; set; }

        bool SecondaryOpen;
        Anchor anchor;
        string width = "500px", height = "100%";
        void OpenDrawer(Anchor anchor, string drawerx)
        {
            SecondaryOpen = (drawerx == "SecondaryOpen") ? true : false;
            this.anchor = anchor;
        }
        protected async Task SaveSecondary()
        {
            sec.Verify_Id = VerifyCode;
            await EducationService.CreateSecondary(sec);
            sec.SecSchoolName = "";
            sec.SecSchoolLoc = "";
            sec.SecAward = "";
            sec.SecSchoolYear = "";
            secondaryList = await EducationService.GetSecondarylist(VerifyCode);
            SecondaryOpen = false;

        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                secondaryList = await EducationService.GetSecondarylist(VerifyCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        async Task DeleteSecondary(int id)
        {
            await EducationService.DeleteSecondary(id);
            secondaryList = await EducationService.GetSecondarylist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<SecondaryT> secondaryList = new List<SecondaryT>();
        private SecondaryT selectedItem1 = null;
        private HashSet<SecondaryT> selectedItems = new HashSet<SecondaryT>();

        private bool FilterFunc1(SecondaryT divisions) => FilterFunc(divisions, searchString1);

        private bool FilterFunc(SecondaryT employees, string searchString)
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
