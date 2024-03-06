using ChartJs.Blazor.Common.Axes.Ticks;
using System.Data;
using System.Globalization;

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
        private List<EmployeeT> employeeBdayL = new();
        private List<AnnouncementT> announceL = new();
        private Dictionary<int, int> positionCounts = new();

        public List<string> departmentArr = new();
        public List<string> divisionArr = new();

        private int[] EmployeeCountPerDivision;
        private int[] EmployeeCountActual;
        private int[] EmployeeCountPlantilla;

        private int _totalVacancy = 0;
        private int _totalPlantilla = 0;
        private string cmbBdyTitle = "This Month";

        //private int totalLeave = 12;
        //private int availableLeave = 8;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                await EmployeeService.GetEmployee();
                await DepartmentService.GetDepartment();
                await DivisionService.GetDivision();
                await PositionService.GetPosition();
                await PositionService.GetDbTotalPlantilla();
                await PositionService.GetSubPosition();
                await ForEvalService.GetForEval();

                announceL = await AnnouncementService.GetFilteredAnnouncementList();

                allDivisions = DivisionService.DivisionTs;
                employeeBdayL = EmployeeService.EmployeeTs.Where(x => x.Birthdate.Month == DateTime.Now.Month).OrderBy(d => d.Birthdate.Day).ToList();

                #region Plantilla

                allPositions = await PositionService.GetPositionList();
                foreach (var position in allPositions)
                {
                    int positionId = position.Id;
                    string positionCode = position.PosCode;
                    int count = PositionService.SubPositionTs.Count(e => e.Status == "Active" && e.PosCode == positionCode);
                    positionCounts[positionId] = count;
                }
                _totalVacancy = allPositions.Sum(position => position.Plantilla - positionCounts[position.Id]);

                var globalId = Convert.ToInt32(GlobalConfigService.User_Id);
                FULLNAME = await EmployeeService.Getname(globalId);

                #endregion Plantilla

                #region Top Cards

                _countActiveEmployees = EmployeeService.EmployeeTs.Where(e => e.StatusId == 1).Count().ToString();
                _countInactiveEmployees = EmployeeService.EmployeeTs.Where(e => new[] { 2, 3, 4, 5, 6 }.Contains(e.StatusId)).Count().ToString();
                DateTime fiveYearsAgo = DateTime.Now.AddYears(-5);
                //_countInactiveEmployees5yearFromInactive = EmployeeService.EmployeeTs
                //    .Where(e => new[] { 2, 3, 4, 5, 6 }.Contains(e.StatusId) && e.DateInactiveStatus <= fiveYearsAgo)
                //    .Count().ToString();

                _countForEval = ForEvalService.Emp_EvaluationTs
                .Count(e => e.EvalStatus != "Done")
                .ToString();

                foreach (var item in allPositions)
                {
                    _totalPlantilla += item.Plantilla;
                }

                #endregion Top Cards

                departmentArr = await DepartmentService.GetAllDepartmentName();
                divisionArr = await DivisionService.GetAllDivisionName();

                FilterEmployee();
                ConfigureBarConfig();

                dataforline = GetLast10DaysLabels();
                FilterLineEmployeeActual();
                FilterLineEmployeePlantilla();
                ConfigureLineConfig();

                ConfigurePieConfig();
                FilterPieEmployee();

                //availableLeavetext = ((Convert.ToDouble(availableLeave) / Convert.ToDouble(totalLeave)) * 100).ToString() + "%";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region BAR CHART BDUDY

        public BarConfig _config = new()
        {
            Options = new BarOptions
            {
                Responsive = true,
                Title = new OptionsTitle
                {
                    Display = false,
                    Text = "Employee Count by Department",
                },
                Legend = new Legend
                {
                    Display = false
                },
                MaintainAspectRatio = false,
            }
        };

        private void ConfigureBarConfig()
        {
            foreach (string _item in divisionArr)
            {
                _config.Data.Labels.Add(_item);
            }

            BarDataset<int> dataset = new(EmployeeCountPerDivision)
            {
                BackgroundColor = new[]
                    {
                        ColorUtil.ColorHexString(149, 125, 173),//
                        ColorUtil.ColorHexString(224, 202, 34), //
                        ColorUtil.ColorHexString(50, 124, 161), //
                        ColorUtil.ColorHexString(152, 138, 207),//
                        ColorUtil.ColorHexString(224, 145, 250),//
                        ColorUtil.ColorHexString(105, 191, 190), //
                        ColorUtil.ColorHexString(188, 191, 105),//
                        ColorUtil.ColorHexString(219, 189, 79), //
                        ColorUtil.ColorHexString(79, 158, 219), //
                        ColorUtil.ColorHexString(33, 79, 115), //
                        ColorUtil.ColorHexString(179, 125, 199), //
                        ColorUtil.ColorHexString(125, 199, 161), //
                        ColorUtil.ColorHexString(181, 110, 120), //
                        ColorUtil.ColorHexString(179, 45, 63), //
                        ColorUtil.ColorHexString(148, 135, 171), //
                        ColorUtil.ColorHexString(66, 103, 150), //
                        ColorUtil.ColorHexString(75, 125, 110), //
                        ColorUtil.ColorHexString(31, 128, 98), //
                        ColorUtil.ColorHexString(126, 186, 123),
                        ColorUtil.ColorHexString(196, 196, 151), //
                        ColorUtil.ColorHexString(117, 117, 35), //
                        ColorUtil.ColorHexString(94, 102, 195), //
                        ColorUtil.ColorHexString(35, 152, 140), //
                        ColorUtil.ColorHexString(175, 74, 215), //
                        ColorUtil.ColorHexString(199, 119, 90),//
                        ColorUtil.ColorHexString(115, 59, 38),
                        ColorUtil.ColorHexString(33, 120, 67),
                        ColorUtil.ColorHexString(139, 113, 244),
                        ColorUtil.ColorHexString(111, 249, 108),
                        ColorUtil.ColorHexString(122, 133, 129),
                        ColorUtil.ColorHexString(171, 92, 84),
                        ColorUtil.ColorHexString(223, 90, 233),
                        ColorUtil.ColorHexString(240, 102, 49),
                        ColorUtil.ColorHexString(149, 60, 161),
                        ColorUtil.ColorHexString(7, 55, 214),
                        ColorUtil.ColorHexString(125, 67, 61),
                        ColorUtil.ColorHexString(90, 97, 94),
                        ColorUtil.ColorHexString(243, 125, 80),
                        ColorUtil.ColorHexString(74, 114, 249),
                        ColorUtil.ColorHexString(8, 63, 247),
                        ColorUtil.ColorHexString(223, 90, 233),
                        ColorUtil.ColorHexString(199, 255, 199),
                        ColorUtil.ColorHexString(7, 55, 214),
                        ColorUtil.ColorHexString(149, 60, 161),
                        ColorUtil.ColorHexString(74, 114, 249),
                        ColorUtil.ColorHexString(255, 199, 158),
                        ColorUtil.ColorHexString(255, 166, 255),
                        ColorUtil.ColorHexString(118, 238, 118),
                        ColorUtil.ColorHexString(255, 99, 71),
                        ColorUtil.ColorHexString(255, 176, 181),
                        ColorUtil.ColorHexString(255, 224, 158),
                        ColorUtil.ColorHexString(143, 235, 191),
                        ColorUtil.ColorHexString(210, 145, 188)
                    },
            };

            _config.Data.Datasets.Add(dataset);
        }

        private void FilterEmployee()
        {
            List<int> empCountperDiv = new();

            foreach (var item in allDivisions)
            {
                var countEmployee = EmployeeService.EmployeeTs.Where(s => s.DivisionId == item.Id).Count();
                //if (countEmployee != 0)
                //{
                //}
                empCountperDiv.Add(countEmployee);
            }
            EmployeeCountPerDivision = empCountperDiv.ToArray();
        }

        #endregion BAR CHART BDUDY

        #region LINE CHART

        public LineConfig _lineconfig = new()
        {
            Options = new LineOptions
            {
                Responsive = true,
                Title = new OptionsTitle
                {
                    Display = false,
                    Text = "Employee Count by Department",
                },
                Legend = new Legend
                {
                    Display = true,
                    Position = ChartJs.Blazor.Common.Enums.Position.Top
                },
                MaintainAspectRatio = false,
                Tooltips = new Tooltips
                {
                    Mode = InteractionMode.Nearest,
                    Intersect = false
                },
                Hover = new Hover
                {
                    Mode = InteractionMode.Nearest,
                    Intersect = false
                },
                Scales = new Scales
                {
                    XAxes = new List<CartesianAxis>
                    {
                        new CategoryAxis
                        {
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = "Last 10 Days",
                                Display = true,
                            },
                        }
                    },
                    YAxes = new List<CartesianAxis>
                    {
                        new LinearCartesianAxis
                        {
                            Ticks = new LinearCartesianTicks
                            {
                                BeginAtZero = true,
                            }
                        }
                    }
                },
            }
        };

        private void ConfigureLineConfig()
        {
            foreach (var item in dataforline)
            {
                if (DateTime.TryParse(item, out DateTime date))
                {
                    if (item == DateTime.Today.ToString("yyyy-MM-dd"))
                    {
                        _lineconfig.Data.Labels.Add("Today");
                    }
                    else
                    {
                        _lineconfig.Data.Labels.Add(date.ToString("MMM dd"));
                    }
                }
            }

            Random rd = new();
            var color = String.Format("#{0:X6}", rd.Next(0x1000000));

            LineDataset<int> dataset = new(EmployeeCountActual)
            {
                Label = "Employee Headcount",
                BackgroundColor = "#966c03",
                BorderColor = "#d19c1b",
                Fill = FillingMode.Disabled
            };

            LineDataset<int> dataset2 = new(EmployeeCountPlantilla)
            {
                Label = "Plantilla",
                BackgroundColor = "#8b5694",
                BorderColor = "#BB9CC0",
                Fill = FillingMode.Disabled
            };

            _lineconfig.Data.Datasets.Add(dataset);
            _lineconfig.Data.Datasets.Add(dataset2);
        }

        //employee count daily vs plantilla
        private void FilterLineEmployeeActual()
        {
            List<int> empCountActual = new();

            foreach (var item in dataforline)
            {
                string format = "yyyy-MM-dd";
                DateTime dateTime = DateTime.ParseExact(item, format, CultureInfo.InvariantCulture);
                var countEmployee = EmployeeService.EmployeeTs.Where(e => (e.DateHired <= dateTime) && (e.DateInactiveStatus == null || e.DateInactiveStatus > dateTime)).Count();
                empCountActual.Add(countEmployee);
            }
            EmployeeCountActual = empCountActual.ToArray();
        }

        private void FilterLineEmployeePlantilla()
        {
            List<int> empCountPlantilla = new();

            foreach (var item in dataforline)
            {
                string format = "yyyy-MM-dd";
                DateTime dateTime = DateTime.ParseExact(item, format, CultureInfo.InvariantCulture);

                // Find the total plantilla count for the specified date
                var dailyTotal = PositionService.DailyTotalPlantillaTs
                    .Where(s => s.Date <= dateTime)
                    .OrderByDescending(s => s.Date)
                    .FirstOrDefault()?.TotalPlantilla ?? 0;

                empCountPlantilla.Add(dailyTotal);
            }

            EmployeeCountPlantilla = empCountPlantilla.ToArray();
        }

        private List<string> dataforline = new();

        private List<string> GetLast10DaysLabels()
        {
            List<string> labels = new();

            DateTime currentDate = DateTime.Now;

            for (int i = 0; i < 10; i++)
            {
                labels.Add(currentDate.ToString("yyyy-MM-dd"));
                currentDate = currentDate.AddDays(-1);
            }
            labels.Reverse();
            return labels;
        }

        #endregion LINE CHART

        #region PIE CHART

        public PieConfig _configPie = new()
        {
            Options = new PieOptions
            {
                Responsive = true,
                Title = new OptionsTitle
                {
                    Display = false,
                    Text = "Employee Count by Division",
                },
                Legend = new Legend
                {
                    Display = true,
                    Position = ChartJs.Blazor.Common.Enums.Position.Right
                },
                MaintainAspectRatio = false,
            }
        };

        private void ConfigurePieConfig()
        {
            foreach (string _item in divisionArr)
            {
                _configPie.Data.Labels.Add(_item);
            }

            PieDataset<int> dataset = new(EmployeeCountPerDivision)
            {
                BackgroundColor = new[]
                    {
                        ColorUtil.ColorHexString(66, 125, 157),
                        ColorUtil.ColorHexString(255, 152, 0),
                        ColorUtil.ColorHexString(154, 152, 227),
                        ColorUtil.ColorHexString(233, 119, 119),
                        ColorUtil.ColorHexString(209, 128, 196),
                        ColorUtil.RandomColorString(),
                        ColorUtil.RandomColorString(),
                        ColorUtil.RandomColorString(),
                        ColorUtil.RandomColorString(),
                        ColorUtil.RandomColorString(),
                        ColorUtil.RandomColorString(),
                        ColorUtil.RandomColorString(),
                        ColorUtil.RandomColorString(),
                        ColorUtil.RandomColorString(),
                        ColorUtil.RandomColorString(),
                        ColorUtil.RandomColorString(),
                    },
            };

            _configPie.Data.Datasets.Add(dataset);
        }

        private void FilterPieEmployee()
        {
            List<int> empCountperDiv = new();

            foreach (var item in allDivisions)
            {
                var countEmployee = EmployeeService.EmployeeTs.Where(s => s.DivisionId == item.Id).Count();
                empCountperDiv.Add(countEmployee);
            }

            EmployeeCountPerDivision = empCountperDiv.ToArray();
        }

        #endregion PIE CHART

        #region FUNCTIONS

        public void BdayThisDay()
        {
            cmbBdyTitle = "Today";
            employeeBdayL = EmployeeService.EmployeeTs.Where(x => x.Birthdate.Month == DateTime.Now.Month && x.Birthdate.Day == DateTime.Now.Day).OrderBy(d => d.Birthdate).ToList();
        }

        public void BdayThisMonth()
        {
            cmbBdyTitle = "This Month";
            employeeBdayL = EmployeeService.EmployeeTs.Where(x => x.Birthdate.Month == DateTime.Now.Month).OrderBy(d => d.Birthdate.Day).ToList();
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

                case "totalPlantilla":
                    NavigationManager.NavigateTo("/totalPlantilla");
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

        #endregion FUNCTIONS
    }
}