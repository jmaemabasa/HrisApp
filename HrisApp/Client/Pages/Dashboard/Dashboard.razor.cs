namespace HrisApp.Client.Pages.Dashboard
{
    public partial class Dashboard : ComponentBase
    {
#nullable disable
        private string _countActiveEmployees = "0";
        private string _countInactiveEmployees = "0";

        private string FULLNAME;

        private List<PositionT> allPositions;
        private Dictionary<int, int> positionCounts = new Dictionary<int, int>();

        private int _totalVacancy = 0; 

        protected override async Task OnInitializedAsync()
        {
            await DepartmentService.GetDepartment();

            await EmployeeService.GetEmployee();
            _countActiveEmployees = EmployeeService.EmployeeTs.Where(e => e.StatusId == 1).Count().ToString();
            _countInactiveEmployees = EmployeeService.EmployeeTs.Where(e => new[] { 2, 3, 4, 5, 6 }.Contains(e.StatusId)).Count().ToString();

            allPositions = await PositionService.GetPositionList();

            foreach (var position in allPositions)
            {
                int positionId = position.Id;
                int count = EmployeeService.EmployeeTs.Count(e => e.PositionId == positionId);
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

            }
        }

        
    }
}
