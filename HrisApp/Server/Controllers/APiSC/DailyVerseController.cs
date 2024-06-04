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

        //public HttpClient GetapiHttp()
        //{
        //    //string _baseURL = "http://192.168.1.27:1335/";
        //    string _baseURL = "http://sonicsales.net:1335/";
        //    HttpClient _client = new()
        //    {
        //        BaseAddress = new Uri(_baseURL)
        //    };
        //    _client.DefaultRequestHeaders.Accept.Clear();
        //    _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    return _client;
        //}


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

        //[HttpGet("GetFroi")]
        //public async Task<ActionResult<List<AG_GHeader>>> GetFroi()
        //{
        //    try
        //    {
        //        var _client = GetapiHttp();
        //        //var json = await _client.GetStringAsync($"api/AG_GReturn/GetReturnForCRR/{_gpCode}/{_userCode}/{_dateProcess}");
        //        //var json = await _client.GetStringAsync($"api/AG_GReturn/");
        //        //var _returnList = JsonConvert.DeserializeObject<List<AG_ReturnModel>>(json);

        //        var json = await _client.GetStringAsync("api/AG_GPheader");
        //        var _returnList = JsonConvert.DeserializeObject<List<AG_GHeader>>(json);

        //        return Ok(_returnList);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return BadRequest(new { Error = $"Failed to fetch verse. {ex.Message}" });
        //    }
        //}
    }
}
