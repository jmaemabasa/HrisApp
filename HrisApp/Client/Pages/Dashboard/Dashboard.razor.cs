namespace HrisApp.Client.Pages.Dashboard
{
    public partial class Dashboard : ComponentBase
    {
#nullable disable
        private string _countActiveEmployees = "0";
        private string _countInactiveEmployees = "0";
        private string _countForEval = "0";

        private string FULLNAME;

        private List<PositionT> allPositions;
        private List<DivisionT> allDivisions;
        private List<DepartmentT> allDepartments;
        private List<SectionT> allSections;
        private List<AreaT> allAreas;
        private Dictionary<int, int> positionCounts = new Dictionary<int, int>();

        public List<string> departmentArr = new List<string>();
        public List<string> divisionArr = new List<string>();
        private List<double> depEmptArr = new List<double>();

        private int EmployeeCount = 0;
        private double[] EmployeeCountPerDivision;

        private int _totalVacancy = 0; 

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await EmployeeService.GetEmployee();
                await DepartmentService.GetDepartment();
                await DivisionService.GetDivision();

                allDepartments = DepartmentService.DepartmentTs;

                #region Top Cards
                _countActiveEmployees = EmployeeService.EmployeeTs.Where(e => e.StatusId == 1).Count().ToString();
                _countInactiveEmployees = EmployeeService.EmployeeTs.Where(e => new[] { 2, 3, 4, 5, 6 }.Contains(e.StatusId)).Count().ToString();
                DateTime fiveYearsAgo = DateTime.Now.AddYears(-5);
                //_countInactiveEmployees5yearFromInactive = EmployeeService.EmployeeTs
                //    .Where(e => new[] { 2, 3, 4, 5, 6 }.Contains(e.StatusId) && e.DateInactiveStatus <= fiveYearsAgo)
                //    .Count().ToString();

                DateTime sevenMonthsAgo = DateTime.Now.AddMonths(-7);
                _countForEval = EmployeeService.EmployeeTs
                    .Count(e => e.DateHired > sevenMonthsAgo)
                    .ToString();
                #endregion

                #region Plantilla
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
                #endregion

                departmentArr = await DepartmentService.GetAllDepartmentName();
                divisionArr = await DivisionService.GetAllDivisionName();
                //DepartmentCount = await DepartmentService.GetCountDepartment();
                EmployeeCount = await EmployeeService.GetCountEmployee();

                await FilterEmployee();
                RandomizeData();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }


        #region Chart area
        private int Ch_Index = -1; //default value cannot be 0 -> first selectedindex is 0.

        public List<ChartSeries> Series = new List<ChartSeries>()
        {
        new ChartSeries() { Name = "Series 1", Data = new double[] { 90, 79, 72, 69, 62, 62, 55, 65, 70 } }
        };

        public string[] XAxisLabels = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep" };

        Random random = new Random();
        public void RandomizeData()
        {
            var new_series = new List<ChartSeries>()
            {
                new ChartSeries() { Name = "Series 1", Data = EmployeeCountPerDivision }
            };
            for (int i = 0; i < EmployeeCount; i++)
            {
                new_series[0].Data[i] = random.NextDouble() * EmployeeCount;
            }
            XAxisLabels = divisionArr.ToArray();
            Series = new_series;
            StateHasChanged();
        }

        #endregion


        private async Task FilterEmployee()
        {
            await Task.Delay(1);
            List<double> empCountperDiv = new List<double>();
            foreach (var item in DivisionService.DivisionTs)
            {
                Console.WriteLine(item.Name);
                var countEmployee = EmployeeService.EmployeeTs.Where(s => s.DivisionId == item.Id).Count();
                empCountperDiv.Add(countEmployee);
            }
            EmployeeCountPerDivision = empCountperDiv.ToArray();

        }



        public void NavForEval() => NavigationManager.NavigateTo("/evaluation");

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
