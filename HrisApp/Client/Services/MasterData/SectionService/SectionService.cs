namespace HrisApp.Client.Services.MasterData.SectionService
{
#nullable disable
    public class SectionService : ISectionService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public SectionService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<SectionT> SectionTs { get; set; }


        //GEEEEEEET
        //public async Task<List<SectionT>> GetSectByDepartment(int deptId)
        //{
        //    var sections = await _http.GetFromJsonAsync<List<SectionT>>($"api/Section/SectByDepartment/{deptId}");
        //    return sections;
        //}

        public async Task GetSectByDepartment(int deptId)
        {
            var sections = await _httpClient.GetFromJsonAsync<List<SectionT>>($"api/Section/SectByDepartment/{deptId}");
            if (sections != null)
            {
                SectionTs = sections;
            }
        }
        //public async Task<List<SectionT>> GetSectByDivision(int divId)
        //{
        //    var sections = await _http.GetFromJsonAsync<List<SectionT>>($"api/Section/SectByDivision/{divId}");
        //    return sections;
        //}

        public async Task GetSectByDivision(int divId)
        {
            var sections = await _httpClient.GetFromJsonAsync<List<SectionT>>($"api/Section/SectByDivision/{divId}");
            if ( sections != null )
            {
                SectionTs = sections;
            }
        }

        public async Task GetSection()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SectionT>>("api/Section/GetSection");
            if (result != null)
            {
                SectionTs = result;
                // Console.WriteLine to check if the data is fetched
                //foreach (var sect in SectionTs)
                //{
                //    Console.WriteLine($"sec Id: {sect.Id}, Name: {sect.Name}");
                //}
            }
        }

        public async Task<List<SectionT>> GetSectionList()
        {
            return await _httpClient.GetFromJsonAsync<List<SectionT>>("api/Section");
        }

        public async Task<SectionT> GetSingleSection(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<SectionT>($"api/Section/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        //CREATE UPDATE

        public async Task CreateSection(string sectName, int divId, int deptId)
        {
            SectionT newSect = new()
            {
                Name = sectName,
                DivisionId = divId,
                DepartmentId = deptId
            };

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Section/CreateSection", newSect);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
        }

        public async Task UpdateSection(SectionT section)
        {
            try
            {
                var result = await _httpClient.PutAsJsonAsync($"api/Section/UpdateSection", section);
                result.EnsureSuccessStatusCode();
                var index = SectionTs.FindIndex(s => s.Id == section.Id);
                if (index >=0)
                {
                    SectionTs[index] = section;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message + "daot ang services");
            }
        }
    }
}
