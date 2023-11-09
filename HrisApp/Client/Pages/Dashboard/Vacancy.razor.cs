namespace HrisApp.Client.Pages.Dashboard
{
    public partial class Vacancy : ComponentBase
    {
        #nullable disable
        private List<PositionT> allPositions;
        private List<SectionT> sections = new List<SectionT>();
        private Dictionary<int, int> positionCounts = new Dictionary<int, int>();

        private int _totalVacancy = 0;

        protected override async Task OnInitializedAsync()
        {
            await EmployeeService.GetEmployee();
            await DepartmentService.GetDepartment();
            await SectionService.GetSection();
            sections = SectionService.SectionTs;

            allPositions = await PositionService.GetPositionList();

            foreach (var position in allPositions)
            {
                int positionId = position.Id;
                int count = EmployeeService.EmployeeTs.Count(e => e.PositionId == positionId);
                positionCounts[positionId] = count;
            }

            //foreach (var department in DepartmentService.DepartmentTs)
            //{
            //    await SectionService.GetSectByDepartment(department.Id);
            //    var departmentSections = SectionService.SectionTs;
            //    sections.AddRange(departmentSections);
            //}

            //Console.WriteLine(sections);

            _totalVacancy = allPositions.Sum(position => position.Plantilla - positionCounts[position.Id]);
        }
    }
}
