using Newtonsoft.Json;
using NPOI.HPSF;

namespace HrisApp.Server.Controllers.APiSC
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterDataApiController : ControllerBase
    {
        private readonly HttpClient _http;
        private readonly DataContext _context;

        private static string BaseUrl = "http://sonicsales.net:1115/"; //WMS MASTER DATA


        public MasterDataApiController(HttpClient http, DataContext context)
        {
            _http = http;
            _context = context;
        }


        private static HttpClient GetClient()
        {
            HttpClient _client = new();
            _client.BaseAddress = new Uri(BaseUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return _client;
        }

        [HttpPut("UpdateFSSStatus")]
        public async Task UpdateFSSStatus([FromQuery] int empid, [FromQuery] int status)
        {
            var _cliens = GetClient();
            await _cliens.PutAsJsonAsync($"api/Fss/UpdateStatusByHris?empid={empid}&status={status}", empid);
        }

        [HttpPut("UpdateSalesmanStatus")]
        public async Task UpdateSalesmanStatus([FromQuery] int empid, [FromQuery] int status)
        {
            var _cliens = GetClient();
            await _cliens.PutAsJsonAsync($"api/Salesman/UpdateStatusByHris?empid={empid}&status={status}", empid);
        }

        [HttpPut("UpdateWMSUserStatus")]
        public async Task UpdateWMSUserStatus([FromQuery] int empid, [FromQuery] int status)
        {
            var _cliens = GetClient();
            await _cliens.PutAsJsonAsync($"api/UserMaster/UpdateStatusByHris?empid={empid}&status={status}", empid);
        }
        [HttpGet("getimage")]
        public async Task<byte[]> getimage()
        {
            var _cliens = GetClient();
            var json = await _cliens.GetStringAsync($"api/OutletAttachments/GetAttachmentView?fileName={"Img01_26062024153141582.png"}&secName={"ImgO001"}&siteCode={"Main"}");
            var _masterdata = JsonConvert.DeserializeObject<byte[]> (json);
            return _masterdata!;

        }
    }
}
