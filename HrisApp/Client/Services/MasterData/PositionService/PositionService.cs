namespace HrisApp.Client.Services.MasterData.PositionService
{
#nullable disable
    public class PositionService : IPositionService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public PositionService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<PositionT> PositionTs { get; set; }

        //GEEEEEEEEEEEET
        //Get/Return All PositionList
        public async Task<List<PositionT>> GetPositionList()
        {
            return await _httpClient.GetFromJsonAsync<List<PositionT>>("api/Position");
        }

        //Get Position by Department
        public async Task GetPosByDepartment(int deptId)
        {
            var pos = await _httpClient.GetFromJsonAsync<List<PositionT>>($"api/Position/PosByDepartment/{deptId}");
            if (pos != null)
            {
                PositionTs = pos;
            }
        }

        //Get Position by Division
        public async Task GetPosByDivision(int divId)
        {
            var pos = await _httpClient.GetFromJsonAsync<List<PositionT>>($"api/Position/PosByDivision/{divId}");
            if (pos != null)
            {
                PositionTs = pos;
            }
        }

        //Get Position by Section
        public async Task GetPosBySection(int sectId)
        {
            var pos = await _httpClient.GetFromJsonAsync<List<PositionT>>($"api/Position/PosBySection/{sectId}");
            if (pos != null)
            {
                PositionTs = pos;
            }
        }

        //Get All PositionList set to PositionTs
        public async Task GetPosition()
        {
            var result = await _httpClient.GetFromJsonAsync<List<PositionT>>("api/Position/GetPosition");
            if (result != null)
            {
                PositionTs = result;
            }
        }
        public async Task<PositionT> GetSinglePosition(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PositionT>($"api/Position/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        //CREATE AND UPDATEEEEEE
        public async Task CreatePositionPerDept(string posName, string posCode,int divId, int deptId, int plantilla)
        {
            PositionT newPosition = new()
            {
                Name = posName,
                DivisionId = divId,
                DepartmentId = deptId,
                PosCode = posCode,
                Plantilla = plantilla
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Position/CreatePosition", newPosition);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
        }
        public async Task CreatePositionPerSection(string posName, string posCode, int divId, int deptId, int sectId, int plantilla)
        {
            PositionT newPosition = new()
            {
                Name = posName,
                PosCode = posCode,
                DivisionId = divId,
                DepartmentId = deptId,
                SectionId = sectId,
                Plantilla = plantilla
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Position/CreatePosition", newPosition);
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
                var result = await _httpClient.PutAsJsonAsync($"api/Position/UpdatePosition", position);
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
