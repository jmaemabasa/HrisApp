namespace HrisApp.Client.Services.MasterData.PositionService
{
#nullable disable
    public class PositionService : IPositionService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PositionService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<PositionT> PositionTs { get; set; }

        //GEEEEEEEEEEEET
        //Get/Return All PositionList
        public async Task<List<PositionT>> GetPositionList()
        {
            return await _http.GetFromJsonAsync<List<PositionT>>("api/Position");
        }

        //Get Position by Department
        public async Task GetPosByDepartment(int deptId)
        {
            var pos = await _http.GetFromJsonAsync<List<PositionT>>($"api/Position/PosByDepartment/{deptId}");
            if (pos != null)
            {
                PositionTs = pos;
            }
        }

        //Get Position by Division
        public async Task GetPosByDivision(int divId)
        {
            var pos = await _http.GetFromJsonAsync<List<PositionT>>($"api/Position/PosByDivision/{divId}");
            if (pos != null)
            {
                PositionTs = pos;
            }
        }

        //Get Position by Section
        public async Task GetPosBySection(int sectId)
        {
            var pos = await _http.GetFromJsonAsync<List<PositionT>>($"api/Position/PosBySection/{sectId}");
            if (pos != null)
            {
                PositionTs = pos;
            }
        }

        //Get All PositionList set to PositionTs
        public async Task GetPosition()
        {
            var result = await _http.GetFromJsonAsync<List<PositionT>>("api/Position/GetPosition");
            if (result != null)
            {
                PositionTs = result;
                // Console.WriteLine to check if the data is fetched
                //foreach (var pos in PositionTs)
                //{
                //    Console.WriteLine($"pos Id: {pos.Id}, Name: {pos.Name}");
                //}
            }
        }


        //CREATE AND UPDATEEEEEE
        public async Task CreatePositionPerDept(string posName, int divId, int deptId)
        {
            PositionT newPosition = new PositionT
            {
                Name = posName,
                DivisionId = divId,
                DepartmentId = deptId
            };

            HttpResponseMessage response = await _http.PostAsJsonAsync("api/Position/CreatePosition", newPosition);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
        }
        public async Task CreatePositionPerSection(string posName, int divId, int deptId, int sectId)
        {
            PositionT newPosition = new PositionT
            {
                Name = posName,
                DivisionId = divId,
                DepartmentId = deptId,
                SectionId = sectId
            };

            HttpResponseMessage response = await _http.PostAsJsonAsync("api/Position/CreatePosition", newPosition);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
        }
        public async Task UpdatePosition(PositionT position)
        {
            try
            {
                var result = await _http.PutAsJsonAsync($"api/Position/UpdatePosition", position);
                result.EnsureSuccessStatusCode();
                var index = PositionTs.FindIndex(s => s.Id == position.Id);
                if (index >= 0)
                {
                    PositionTs[index] = position;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "daot ang services");
            }
        }
    }
}
