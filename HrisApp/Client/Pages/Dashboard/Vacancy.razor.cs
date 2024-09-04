namespace HrisApp.Client.Pages.Dashboard
{
#nullable disable

    public partial class Vacancy : ComponentBase
    {
        private List<PositionT> allPositions;
        private List<SubPositionT> allSubPositions;
        private List<SubPositionT> tableListpos;
        private List<DepartmentT> allDepartments;
        private List<DivisionT> allDivisions;
        private List<SectionT> allSections = new();

        private int _totalVacancy = 0;
        private string cmbDivTitle = "All Division";

        protected override async Task OnInitializedAsync()
        {
            await EmployeeService.GetEmployee();
            await PositionService.GetPosition();
            allPositions = await PositionService.GetPositionList();

            allDivisions = await DivisionService.GetDivisionList();
            allDepartments = await DepartmentService.GetDepartmentList();
            allSections = await SectionService.GetSectionList();
            await PositionService.GetSubPosition();
            allSubPositions = PositionService.SubPositionTs;
            tableListpos = PositionService.SubPositionTs
                    .Where(e => e.Status.Equals("Vacant"))
                    .GroupBy(e => e.PositionId) // Group by position code
                    .Select(g => g.First()) // Select the first item of each group
                    .ToList();

            _totalVacancy = allSubPositions.Where(e => e.Status.Equals("Vacant")).Count();
        }

        private void CmbDivision(int div)
        {
            foreach (var item in allDivisions)
            {
                if (item.Id == div)
                    cmbDivTitle = div == 0 ? "All Division" : item.Name;
            }

            if (div == 0)
                cmbDivTitle = "All Division";

            tableListpos = div == 0 ?
                PositionService.SubPositionTs
                    .Where(e => e.Status.Equals("Vacant"))
                    .GroupBy(e => e.PositionId) // Group by position code
                    .Select(g => g.First()) // Select the first item of each group
                    .ToList()
                : PositionService.SubPositionTs
                    .Where(e => e.Status.Equals("Vacant") && e.DivisionId == div) //filter div
                    .GroupBy(e => e.PositionId)
                    .Select(g => g.First())
                    .ToList();
        }
    }
}