namespace HrisApp.Client.Pages.Dashboard
{
    public partial class Dashboard : ComponentBase
    {
#nullable disable
        private string _countActiveEmployees = "0";
        private string _countInactiveEmployees = "0";
        private string _countForEval = "0";
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

        public List<string> departmentArr = new List<string>();
        private List<double> depEmptArr = new List<double>();

        private int Index = -1; //default value cannot be 0 -> first selectedindex is 0.

        public List<ChartSeries> Series = new List<ChartSeries>();
        public string[] XAxisLabels = null;

        private int _totalVacancy = 0; 

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Console.WriteLine("Console 1");

                await EmployeeService.GetEmployee();
                Console.WriteLine("Console 2");

                await DepartmentService.GetDepartment();
                Console.WriteLine("Console 3");

                allDepartments = DepartmentService.DepartmentTs;

                


                #region Top Cards
                _countActiveEmployees = EmployeeService.EmployeeTs.Where(e => e.StatusId == 1).Count().ToString();
                _countInactiveEmployees = EmployeeService.EmployeeTs.Where(e => new[] { 2, 3, 4, 5, 6 }.Contains(e.StatusId)).Count().ToString();
                DateTime fiveYearsAgo = DateTime.Now.AddYears(-5);
                _countInactiveEmployees5yearFromInactive = EmployeeService.EmployeeTs
                    .Where(e => new[] { 2, 3, 4, 5, 6 }.Contains(e.StatusId) && e.DateInactiveStatus <= fiveYearsAgo)
                    .Count().ToString();

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
                #endregion


                var globalId = Convert.ToInt32(GlobalConfigService.User_Id);
                FULLNAME = await EmployeeService.Getname(globalId);

                await OnChartRefresh();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            
        }


        private async Task OnChartRefresh()
        {
            Series[0] = new ChartSeries() { Name = "United States", Data = new double[] { 40, 20, 25, 27, 46, 60, 48, 80, 15, 40, 20, 25, 27, 46, 60, 48, 80, 15, 1, 1, 1, 1, 1 } };

            await Task.Delay(1);
            Console.WriteLine("Console 4 " + allDepartments.Count());

            int countindex = 1;
            foreach (var item in allDepartments)
            {
                departmentArr.Add(item.Name);
                countindex++;
                //Console.WriteLine(item.Name);
                //depEmptArr.Add(Convert.ToDouble(EmployeeService.EmployeeTs.Where(e => e.DepartmentId == item.Id).Count()));
            }
            //Console.WriteLine(departmentArr.ToArray());


            XAxisLabels = departmentArr.ToArray();

            foreach (var i in XAxisLabels)
            {
                Console.WriteLine(i);
            }



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
