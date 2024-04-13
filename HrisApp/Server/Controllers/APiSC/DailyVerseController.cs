using HrisApp.Shared.Models.DailyVerse;
using Newtonsoft.Json;

namespace HrisApp.Server.Controllers.APiSC
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyVerseController : ControllerBase
    {
        private readonly HttpClient _http;

        public DailyVerseController(HttpClient http)
        {
            _http = http;
        }

        [HttpGet("GetDailyVerse")]
        public async Task<ActionResult<DailyVerse>> GetDailyVerse()
        {
            try
            {
                var apiUrl = "https://dailyverses.net/api/dailyverse";

                var response = await _http.GetStringAsync(apiUrl);
                dynamic verseData = JsonConvert.DeserializeObject(response);
                return Ok(verseData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest(new { Error = $"Failed to fetch verse. {ex.Message}" });
            }
        }
    }
}
