﻿namespace HrisApp.Client.Pages.MasterData
{
    public partial class Position : ComponentBase
    {
        private List<DepartmentT> Departments = new List<DepartmentT>();
        private List<DivisionT> Divisions = new List<DivisionT>();
        private List<SectionT> Sections = new List<SectionT>();
        private List<PositionT> Positions = new List<PositionT>();


        protected override async Task OnInitializedAsync()
        {
            try
            {
                StateService.OnChange += OnStateChanged;
                await LoadList();

                await DepartmentService.GetDepartment();
                await DivisionService.GetDivision();
                await SectionService.GetSection();

                Divisions = DivisionService.DivisionTs;
                Departments = DepartmentService.DepartmentTs;
                Sections = SectionService.SectionTs;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task LoadList()
        {
            await PositionService.GetPosition();
            StateService.SetState("PositionList", PositionService.PositionTs);
        }

        private void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            positionList = StateService.GetState<List<PositionT>>("PositionList");
            StateHasChanged();
        }


        private void OpenAddPosition()
        {
            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<AddPositionDialog>("New Position", options);
        }

        private void OpenUpdatePosition(int id)
        {
            var parameters = new DialogParameters<UpdatePositionDialog>();
            parameters.Add(x => x.Id, id);

            var options = new DialogOptions { CloseOnEscapeKey = true };
            DialogService.Show<UpdatePositionDialog>("Update Position", parameters, options);
        }

        //TABLEEES
        private string infoFormat = "{first_item}-{last_item} of {all_items}";
        private string searchString1 = "";
        List<PositionT> positionList = new List<PositionT>();

        private PositionT selectedItem1 = null;
        private HashSet<PositionT> selectedItems = new HashSet<PositionT>();

        private bool FilterFunc1(PositionT pos) => FilterFunc(pos, searchString1);

        private bool FilterFunc(PositionT pos, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (pos.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        //END FOR TABLES

        //DROPDOWN SEARCH LIST
        private int divdd;
        private int depdd;
        private int secdd;

        private async Task searchh(int div)
        {
            await Task.Delay(10);
            if (div == 0)
            {
                await PositionService.GetPosition();
                positionList = PositionService.PositionTs;
                depdd = 0;
                divdd = 0;
            }
            else
            {
                divdd = div;
                depdd = 0;

                await PositionService.GetPosByDivision(div);
                positionList = PositionService.PositionTs.Where(d => d.DivisionId == divdd).ToList();
            }

        }


        private async Task searchh1(int dep)
        {
            await Task.Delay(10);
            if (divdd != 0)
            {
                if (dep == 0)
                {
                    await PositionService.GetPosition();
                    positionList = PositionService.PositionTs.Where(d => d.DivisionId == divdd).ToList();
                    depdd = dep;
                }
                else
                {
                    await PositionService.GetPosByDepartment(dep);
                    positionList = PositionService.PositionTs.Where(d => d.DivisionId == divdd).ToList();

                    depdd = dep;
                }
            }
        }

        private async Task searchh2(int sec)
        {
            await Task.Delay(10);
            //if ang value sa section na dd kay dli 0, then i display tanan section sa department id
            if (sec == 0)
            {
                await PositionService.GetPosition();
                positionList = PositionService.PositionTs.Where(d => d.DepartmentId == depdd).ToList();
                secdd = sec;
            }
            else
            {
                await PositionService.GetPosBySection(sec);
                positionList = PositionService.PositionTs.Where(d => d.DepartmentId == depdd).ToList();

                secdd = sec;
            }
        }
        //END DROPDOWN SEARCH   
    }
}
