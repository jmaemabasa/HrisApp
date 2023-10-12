using HrisApp.Shared.Models.MasterData;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace HrisApp.Client.Services.MasterData.DivisionService
{
    public class DivisionService : IDivisionService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public DivisionService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<DivisionT> DivisionTs { get; set; }

        public async Task GetDivisionList()
        {
            var result = await _http.GetFromJsonAsync<List<DivisionT>>("api/Division");
            if (result != null)
                DivisionTs = result;
        }

        public async Task GetDivision()
        {
            var result = await _http.GetFromJsonAsync<List<DivisionT>>("/api/Division/GetDivision");
            if (result != null)
            {
                DivisionTs = result;

                // Console.WriteLine to check if the data is fetched
                foreach (var area in DivisionTs)
                {
                    Console.WriteLine($"Area Id: {area.Id}, Name: {area.Name}");
                }
            }
        }

        public async Task<DivisionT> GetSingleDivision(int id)
        {
            throw new NotImplementedException();
        }

        public async Task CreateDivision(string divisionName)
        {
            DivisionT div = new DivisionT
            {
                Name = divisionName
            };

            var result = await _http.PostAsJsonAsync("api/Division/CreateDivision", div);
        }

        public async Task UpdateDivision(DivisionT division)
        {
            var result = await _http.PutAsJsonAsync($"api/division/UpdateDivision", division);
        }
    }
}
