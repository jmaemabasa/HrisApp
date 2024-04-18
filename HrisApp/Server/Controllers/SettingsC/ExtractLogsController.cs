using HrisApp.Shared.Models.SettingsM;

namespace HrisApp.Server.Controllers.SettingsC
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtractLogsController : ControllerBase
    {
        private readonly DataContext _context;

        public ExtractLogsController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<ExtractLogsModel>>> GetObjList()
        {
            var obj = await _context.ExtractLogsModel.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<ExtractLogsModel>>> GetObj()
        {
            var obj = await _context.ExtractLogsModel.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExtractLogsModel>> GetSingleObj(int id)
        {
            var obj = await _context.ExtractLogsModel.FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<ExtractLogsModel>> GetDBObj()
        {
            return await _context.ExtractLogsModel.ToListAsync();
        }

        //CREATE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<ExtractLogsModel>> CreateObj(ExtractLogsModel model)
        {
            _context.ExtractLogsModel.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(ExtractLogsModel model)
        {
            var dbarea = await _context.ExtractLogsModel.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea!.EmployeeUserId = model.EmployeeUserId;
            dbarea!.Action = model.Action;
            dbarea!.Type = model.Type;
            dbarea!.Description = model.Description;
            dbarea!.Is_Start = model.Is_Start;
            dbarea!.Date_Start = model.Date_Start;
            dbarea!.Date_Stop = model.Date_Stop;
            dbarea!.Date_Create = model.Date_Create;
            dbarea!.Status = model.Status;

            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetExistExtract")]
        public async Task<ActionResult<int>> GetExistExtract([FromQuery]string status)
        {
            var datetoday = DateTime.Now;
            var count = await _context.ExtractLogsModel.Where(e=> e.Is_Start == true && e.Date_Create.Date == datetoday.Date && e.Status.Equals(status))
                .CountAsync();

            return Ok(count);
        }

        [HttpGet("GetExtractingModel")]
        public async Task<ActionResult<ExtractLogsModel>> GetExtractingModel()
        {
            var datetoday = DateTime.Now;
            var count = await _context.ExtractLogsModel.Where(e => e.Is_Start == true && e.Date_Create.Date == datetoday.Date && e.Status.Equals("Processing"))
                .FirstOrDefaultAsync();

            return Ok(count);
        }


        [HttpGet("GetExtractStatus")]
        public async Task<ActionResult<bool>> GetExtractStatus()
        {
            var datetoday = DateTime.Now;
            ExtractLogsModel model = new();
            model = await _context.ExtractLogsModel.Where(e => e.Is_Start == true && e.Date_Create.Date == datetoday.Date && e.Status.Equals("Processing"))
                .FirstOrDefaultAsync();

            if (model == null)
                return Ok(false);

            return Ok(model!.Is_Start);
        }
    }
}
