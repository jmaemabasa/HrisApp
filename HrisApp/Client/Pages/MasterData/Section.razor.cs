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


        //DROPDOWN SEARCH LIST
        private int divdd;
        private int depdd;

        private async Task searchh(ChangeEventArgs e)
        {
            if (depdd == 0)
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    await SectionService.GetSection();
                    sectionList = SectionService.SectionTs;

                    divdd = Convert.ToInt32(e.Value);

                }
                else
                {
                    await SectionService.GetSectByDivision(Convert.ToInt32(e.Value));
                    sectionList = SectionService.SectionTs;

                    divdd = Convert.ToInt32(e.Value);
                    Console.WriteLine(divdd);
                }
            }
            else
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    await SectionService.GetSection();
                    sectionList = SectionService.SectionTs.Where(d => d.DepartmentId == depdd).ToList();

                    divdd = Convert.ToInt32(e.Value);

                }
                else
                {
                    await SectionService.GetSectByDivision(Convert.ToInt32(e.Value));
                    sectionList = SectionService.SectionTs.Where(d => d.DepartmentId == depdd).ToList();

                    divdd = Convert.ToInt32(e.Value);
                    Console.WriteLine(divdd);
                }
            }
        }

        private async Task searchh1(ChangeEventArgs e)
        {

            //if ang value sa dropdown na division kay all display tanan division by department
            if (divdd == 0)
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    await SectionService.GetSection();
                    sectionList = SectionService.SectionTs;

                    depdd = Convert.ToInt32(e.Value);
                }
                else
                {
                    await SectionService.GetSectByDepartment(Convert.ToInt32(e.Value));
                    sectionList = SectionService.SectionTs;

                    depdd = Convert.ToInt32(e.Value);

                }
            }

            //else naay gi pick sa division drop down display lang ang department sa value sa dropdown na division
            else
            {
                if (Convert.ToInt32(e.Value) == 0)
                {
                    await SectionService.GetSection();
                    sectionList = SectionService.SectionTs.Where(d => d.DivisionId == divdd).ToList();
                    depdd = Convert.ToInt32(e.Value);

                }
                else
                {
                    await SectionService.GetSectByDepartment(Convert.ToInt32(e.Value));
                    sectionList = SectionService.SectionTs.Where(d => d.DivisionId == divdd).ToList();

                    depdd = Convert.ToInt32(e.Value);

                }
            }
        }
        //END DROPDOWN SEARCH LIST
    }
}
