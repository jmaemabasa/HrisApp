namespace HrisApp.Client.Pages.MasterData
{
    public partial class Section : ComponentBase
    {
        private List<DepartmentT> Departments = new List<DepartmentT>();
        private List<DivisionT> Divisions = new List<DivisionT>();
        private List<SectionT> Sections = new List<SectionT>();


        protected override async Task OnInitializedAsync()
        {
            try
            {
                await DepartmentService.GetDepartment();
                await DivisionService.GetDivision();
                await SectionService.GetSection();

                Divisions = DivisionService.DivisionTs;
                Departments = DepartmentService.DepartmentTs;
                sectionList = SectionService.SectionTs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void OpenAddSection()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddSectionDialog>("New Section", options);
        }

        private void OpenUpdateSection(int id)
        {
            var parameters = new DialogParameters<UpdateSectionDialog>();
            parameters.Add(x => x.Id, id);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<UpdateSectionDialog>("Update Section", parameters, options);
        }

        //TABLEEES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<SectionT> sectionList = new List<SectionT>();

        private SectionT selectedItem1 = null;
        private HashSet<SectionT> selectedItems = new HashSet<SectionT>();

        private bool FilterFunc1(SectionT section) => FilterFunc(section, searchString1);

        private bool FilterFunc(SectionT section, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (section.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        //END FOR TABLES
    }
}
