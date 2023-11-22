namespace HrisApp.Client.Pages.Dashboard
{
    public partial class Dashboard : ComponentBase
    {
#nullable disable
        private string _countActiveEmployees = "0";
        private string _countInactiveEmployees = "0";
        private string _countInactiveEmployees5yearFromInactive = "0";
        private string _countDivisions = "0";
        private string _countDepartments = "0";
        private string _countSections = "0";
        private string _countAreas = "0";

        private string FULLNAME;

        private List<PositionT> allPositions;
        private List<DivisionT> allDivisions;
        private List<DepartmentT> allDepartments;
        private List<SectionT> allSections;
        private List<AreaT> allAreas;
        private Dictionary<int, int> positionCounts = new Dictionary<int, int>();

        private int _totalVacancy = 0; 

        protected override async Task OnInitializedAsync()
        {
            await DepartmentService.GetDepartment();
            allDivisions = await DivisionService.GetDivisionList();
            allDepartments = await DepartmentService.GetDepartmentList();
            allSections = await SectionService.GetSectionList();
            allAreas = await AreaService.GetAreaList();

            await EmployeeService.GetEmployee();
            _countActiveEmployees = EmployeeService.EmployeeTs.Where(e => e.StatusId == 1).Count().ToString();
            _countInactiveEmployees = EmployeeService.EmployeeTs.Where(e => new[] { 2, 3, 4, 5, 6 }.Contains(e.StatusId)).Count().ToString();
            DateTime fiveYearsAgo = DateTime.Now.AddYears(-5);
            _countInactiveEmployees5yearFromInactive = EmployeeService.EmployeeTs
                .Where(e => new[] { 2, 3, 4, 5, 6 }.Contains(e.StatusId) && e.DateInactiveStatus <= fiveYearsAgo)
                .Count().ToString();
            _countDivisions = allDivisions.Count().ToString();
            _countDepartments = allDepartments.Count().ToString();
            _countSections = allSections.Count().ToString();
            _countAreas = allAreas.Count().ToString();

            allPositions = await PositionService.GetPositionList();
            foreach (var position in allPositions)
            {
                int positionId = position.Id;
                int count = EmployeeService.EmployeeTs.Count(e => e.StatusId == 1 && e.PositionId == positionId);
                positionCounts[positionId] = count;
            }
            _totalVacancy = allPositions.Sum(position => position.Plantilla - positionCounts[position.Id]);

            var globalId = Convert.ToInt32(GlobalConfigService.User_Id);
            FULLNAME = await EmployeeService.Getname(globalId);
        }

        public void NavIconBtns(string text)
        {
            switch (text)
            {
                case "employee":
                    NavigationManager.NavigateTo("/employee?allInStatus=active");
                    break;
                case "inactiveEmployee":
                    NavigationManager.NavigateTo("/employee?allInStatus=inactive");
                    break;
                case "vacancy":
                    NavigationManager.NavigateTo("/vacancy");
                    break;
                case "5yearsinactive":
                    NavigationManager.NavigateTo("/employee?allInStatus=inactive5yearsago");
                    break; 
                case "division":
                    NavigationManager.NavigateTo("/division");
                    break;
                case "department":
                    NavigationManager.NavigateTo("/department");
                    break;
                case "section":
                    NavigationManager.NavigateTo("/section");
                    break;
                case "area":
                    NavigationManager.NavigateTo("/area");
                    break;

            }
        }

        
    }
}
