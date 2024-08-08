using HrisApp.Shared.Models.SettingsM;
using System.Linq;

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
            var obj = await _context.ExtractLogsModel.OrderByDescending(e=>e.Date_Create).ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<ExtractLogsModel>>> GetObj()
        {
            var obj = await _context.ExtractLogsModel.OrderByDescending(e => e.Date_Create).ToListAsync();
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
            dbarea!.Date_Extract = model.Date_Extract;
            dbarea!.Is_Active = model.Is_Active;
            dbarea!.BioId = model.BioId;

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
            var returnmodel = await _context.ExtractLogsModel.Where(e => e.Is_Start == true && e.Date_Create.Date == datetoday.Date && e.Status.Equals("Processing"))
                .FirstOrDefaultAsync();

            if (returnmodel == null)
            {
                return null;
            }

            return Ok(returnmodel);
        }

        [HttpGet("GetExtractingCheckingModel")]
        public async Task<ActionResult<ExtractLogsModel>> GetExtractingCheckingModel()
        {
            var datetoday = DateTime.Now;
            var returnmodel = await _context.ExtractLogsModel.Where(e => e.Is_Start == true && e.Date_Create.Date == datetoday.Date && e.Status.Equals("Checking"))
                .FirstOrDefaultAsync();

            if (returnmodel == null)
            {
                return null!;
            }

            return Ok(returnmodel);
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

        [HttpGet("CleanLogs")]
        public async Task<ActionResult<string>> CleanLogs()
        {
            try
            {
                var threeMonthsAgo = DateTime.Now.AddMonths(-3);

                // Retrieve logs older than three months
                var oldLogs = await _context.ExtractLogsModel
                                            .Where(log => log.Date_Create < threeMonthsAgo)
                                            .ToListAsync();

                if (oldLogs.Count == 0)
                {
                    return Ok("NoLogs");
                }

                foreach (var item in oldLogs)
                {
                    ExtractLogsModelArchive archive = new()
                    {
                        Id = 0,
                        EmployeeUserId = item.EmployeeUserId,
                        Action = item.Action,
                        Type = item.Type,
                        Description = item.Description,
                        Is_Start = item.Is_Start,
                        Date_Start = item.Date_Start,
                        Date_Stop = item.Date_Stop,
                        Date_Create = item.Date_Create,
                        Status = item.Status,
                        Date_Extract = item.Date_Extract,
                        Is_Active = item.Is_Active,
                        BioId = item.BioId,
                    };
                    
                    // Insert old logs into ExtractLogsModelArchive
                    _context.ExtractLogsModelArchive.Add(archive);

                    // remove old logs from ExtractLogsModel
                    _context.ExtractLogsModel.Remove(item);

                    // Save changes to both contexts
                    await _context.SaveChangesAsync();
                }

                return Ok("Success");
            }
            catch (Exception)
            {
                // Log the exception if needed
                return Ok("Error");
            }
        }
    }
}
