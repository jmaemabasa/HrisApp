namespace HrisApp.Client.Pages.Dashboard
{
    public partial class Dashboard : ComponentBase
    {
#nullable disable
        private string _countEmployees = "0";

        private List<PositionT> allPositions;
        private Dictionary<int, int> positionCounts = new Dictionary<int, int>();
        private Dictionary<int, int> plantillaPositions = new Dictionary<int, int>();

        private int _totalVacancy = 0; 

        protected override async Task OnInitializedAsync()
        {
            await DepartmentService.GetDepartment();

            await EmployeeService.GetEmployee();
            _countEmployees = EmployeeService.EmployeeTs.Where(e => e.StatusId == 1).Count().ToString();

            allPositions = await PositionService.GetPositionList();

            plantillaPositions = new Dictionary<int, int>
            {
                { 1, 3 }, { 2, 2 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 4 },{ 48, 3 }, { 49, 1 }
            };

            foreach (var position in allPositions)
            {
                int positionId = position.Id;
                int count = EmployeeService.EmployeeTs.Count(e => e.PositionId == positionId);
                positionCounts[positionId] = count;

                if (plantillaPositions.ContainsKey(positionId) && (plantillaPositions[positionId] - positionCounts[positionId] != 0))
                {
                    // You can display the position in the dashboard if the plantilla is not zero
                    Console.WriteLine($"Position ID: {positionId}, Employee Count: {count}, Plantilla: {plantillaPositions[positionId]}, ds: {plantillaPositions[positionId] - positionCounts[positionId]}");
                }
            }

             _totalVacancy = allPositions
            .Select(position => plantillaPositions.ContainsKey(position.Id) ? plantillaPositions[position.Id] - positionCounts[position.Id] : 0)
            .Sum();
            }

        
    }
}
