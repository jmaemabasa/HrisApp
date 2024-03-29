﻿namespace HrisApp.Client.Pages.MasterData
{
    public partial class Section : ComponentBase
    {
        private List<DepartmentT> Departments = new();
        private List<DivisionT> Divisions = new();

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await Task.Delay(500);
                StateService.OnChange += OnStateChanged;
                await LoadList();

                await DepartmentService.GetDepartment();
                await DivisionService.GetDivision();

                Divisions = DivisionService.DivisionTs;
                Departments = DepartmentService.DepartmentTs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task LoadList()
        {
            await SectionService.GetSection();
            StateService.SetState("SectionList", SectionService.SectionTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            sectionList = StateService.GetState<List<SectionT>>("SectionList");
            StateHasChanged();
        }


        private void OpenAddSection()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddSectionDialog>("New Section", options);
        }

        private void OpenUpdateSection(int id)
        {
            var parameters = new DialogParameters<UpdateSectionDialog>
            {
                { x => x.Id, id }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<UpdateSectionDialog>("Update Section", parameters, options);
        }

        private bool isVisible;
        public async void OpenOverlay()
        {
            isVisible = true;
            await Task.Delay(3000);
            isVisible = false;
            StateHasChanged();
        }

        //TABLEEES
        private readonly string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<SectionT> sectionList = new();

        private SectionT selectedItem1 = null;

        private bool FilterFunc1(SectionT section) => FilterFunc(section, searchString1);

        private static bool FilterFunc(SectionT section, string searchString)
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

        private async Task searchh(int div)
        {
            await Task.Delay(10);
            if (div == 0)
            {
                await SectionService.GetSection();
                sectionList = SectionService.SectionTs;
                divdd = 0;
            }
            else
            {
                await SectionService.GetSectByDivision(div);
                sectionList = SectionService.SectionTs;
                divdd = div;
            }

        }
        private async Task searchh1(int dep)
        {
            await Task.Delay(10);
            if (dep == 0)
            {
                await SectionService.GetSection();
                sectionList = SectionService.SectionTs.Where(d => d.DivisionId == divdd).ToList();
            }
            else
            {
                await SectionService.GetSectByDepartment(dep);
                sectionList = SectionService.SectionTs.Where(d => d.DivisionId == divdd).ToList();
            }

        }

        //END DROPDOWN SEARCH LIST
    }
}
