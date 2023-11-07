﻿namespace HrisApp.Client.Pages.Education
{
#nullable disable
    public partial class EmployeeDoctorate : ComponentBase
    {
        private DoctorateT doctorate = new DoctorateT();
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
            doctorateList = await EducationService.GetDoctoratelist(VerifyCode);
        }


        //TABLEEES
        private string searchString1 = "";
        List<DoctorateT> doctorateList = new List<DoctorateT>();
        private DoctorateT selectedItem1 = null;
        private HashSet<DoctorateT> selectedItems = new HashSet<DoctorateT>();

        private bool FilterFunc1(DoctorateT item) => FilterFunc(item, searchString1);

        private bool FilterFunc(DoctorateT item, string searchString)
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