using HrisApp.Shared.Models.DailyVerse;

namespace HrisApp.Client.Services.DailyVerseService
{
    public interface IDailyVerseService
    {
        Task<DailyVerse> GetDailyVerse();
    }
}
