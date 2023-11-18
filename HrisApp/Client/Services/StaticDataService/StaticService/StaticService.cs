namespace HrisApp.Client.Services.StaticDataService.StaticService
{
#nullable disable
    public class StaticService : IStaticService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public StaticService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<StatusT> StatusTs { get; set; }
        public List<EmploymentStatusT> EmploymentStatusTs { get; set; }
        public List<EmerRelationshipT> EmerRelationshipTs { get; set; }
        public List<GenderT> GenderTs { get; set; }
        public List<CivilStatusT> CivilStatusTs { get; set; }
        public List<ReligionT> ReligionTs { get; set; }
        public List<InactiveStatusT> InactiveStatusTs { get; set; }
        public List<RateTypeT> RateTypeTs { get; set; } = new List<RateTypeT>();
        public List<CashBondT> CashBondTs { get; set; } = new List<CashBondT>();
        public List<RestDayT> RestDayTs { get; set; } = new List<RestDayT>();

        public async Task GetStatusList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<StatusT>>("api/Static/GetStatusList");
            if (result != null)
            {
                StatusTs = result;
            }
        }
        public async Task GetEmploymentStatusList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<EmploymentStatusT>>("api/Static/GetEmploymentStatusList");
            if (result != null)
            {
                EmploymentStatusTs = result;
            }
        }
        public async Task GetEmerRelationshipList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<EmerRelationshipT>>("api/Static/GetEmerRelationshipList");
            if (result != null)
            {
                EmerRelationshipTs = result;
            }
        }
        public async Task GetGenderList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<GenderT>>("api/Static/GetGenderList");
            if (result != null)
            {
                GenderTs = result;
            }
        }
        public async Task GetCivilStatusList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<CivilStatusT>>("api/Static/GetCivilStatusList");
            if (result != null)
            {
                CivilStatusTs = result;
            }
        }
        public async Task GetReligionList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ReligionT>>("api/Static/GetReligionList");
            if (result != null)
            {
                ReligionTs = result;
            }
        }
        public async Task GetInactiveStatusList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<InactiveStatusT>>("api/Static/GetInactiveStatusList");
            if (result != null)
            {
                InactiveStatusTs = result;
            }
        }
        public async Task GetRateType()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RateTypeT>>("api/Static/ratetype");
            if (result != null)
                RateTypeTs = result;
        }

        public async Task GetCashbond()
        {
            var result = await _httpClient.GetFromJsonAsync<List<CashBondT>>("api/Static/cashbond");
            if (result != null)
                CashBondTs = result;
        }


        public async Task GetRestDay()
        {
            var result = await _httpClient.GetFromJsonAsync<List<RestDayT>>("api/Static/restday");
            if (result != null)
                RestDayTs = result;
        }
    }
}
