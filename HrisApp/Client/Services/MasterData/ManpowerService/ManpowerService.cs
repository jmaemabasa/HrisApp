using HrisApp.Client.Pages.MasterData;

namespace HrisApp.Client.Services.MasterData.ManpowerService
{
#nullable disable
    public class ManpowerService : IManpowerService
    {

        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public ManpowerService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<PosMPInternalT> PosMPInternalTs { get; set; } = new List<PosMPInternalT>();

        public async Task<List<PosMPInternalT>> GetInternalList()
        {
            return await _httpClient.GetFromJsonAsync<List<PosMPInternalT>>("api/PosInternal");
        }
        public async Task<PosMPInternalT> GetSingleInternal(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PosMPInternalT>($"api/PosInternal/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }
        public async Task GetInternal()
        {
            var result = await _httpClient.GetFromJsonAsync<List<PosMPInternalT>>("/api/PosInternal/GetInternal");
            if (result != null)
            {
                PosMPInternalTs = result;
            }
        }
        public async Task CreateInternal(string name, string verid)
        {
            PosMPInternalT div = new()
            {
                Internal_Name = name,
                Internal_VerifyId = verid
            };

            var result = await _httpClient.PostAsJsonAsync("api/PosInternal/CreateInternal", div);
        }
        public async Task UpdateInternal(PosMPInternalT obj)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/PosInternal/UpdateInternal", obj);
        }





        public List<PosMPExternalT> PosMPExternalTs { get; set; } = new List<PosMPExternalT>();

        public async Task<List<PosMPExternalT>> GetExternalList()
        {
            return await _httpClient.GetFromJsonAsync<List<PosMPExternalT>>("api/PosExternal");

        }

        public async Task<PosMPExternalT> GetSingleExternal(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<PosMPExternalT>($"api/PosExternal/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        public async Task GetExternal()
        {
            var result = await _httpClient.GetFromJsonAsync<List<PosMPExternalT>>("/api/PosExternal/GetExternal");
            if (result != null)
            {
                PosMPExternalTs = result;
            }
        }

        public async Task CreateExternal(string name, string verid)
        {
            PosMPExternalT div = new()
            {
                External_Name = name,
                External_VerifyId = verid
            };

            var result = await _httpClient.PostAsJsonAsync("api/PosExternal/CreateExternal", div);
        }

        public async Task UpdateExternal(PosMPExternalT obj)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/PosExternal/UpdateExternal", obj);
        }
    }
}
