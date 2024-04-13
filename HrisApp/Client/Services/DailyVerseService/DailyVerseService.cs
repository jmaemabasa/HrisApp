using HrisApp.Shared.Models.DailyVerse;

namespace HrisApp.Client.Services.DailyVerseService
{
#nullable disable
    public class DailyVerseService : IDailyVerseService
    {
        MainsService _mainService = new();
        private readonly HttpClient _httpClient;
        public DailyVerseService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public async Task<DailyVerse> GetDailyVerse()
        {
            var response = await _httpClient.GetFromJsonAsync<DailyVerse>("api/DailyVerse/GetDailyVerse");
            Console.WriteLine("response " + response);
            return response;
        }
    }
}
