using HrisApp.Shared.Models.SettingsM;

namespace HrisApp.Server.Controllers.SettingsC
{
    [Route("api/[controller]")]
    [ApiController]
    public class BioIPController : ControllerBase
    {
        private readonly DataContext _context;

        public BioIPController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<BioIPModel>>> GetObjList()
        {
            var obj = await _context.BioIPModel.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<BioIPModel>>> GetObj()
        {
            var obj = await _context.BioIPModel.ToListAsync();
            return Ok(obj);
        }


        [HttpGet("GetAllActivesObj")]
        public async Task<ActionResult<List<BioIPModel>>> GetAllActivesObj()
        {
            var obj = await _context.BioIPModel.Where(e=>e.Status.Equals("Active")).ToListAsync();
            return Ok(obj);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BioIPModel>> GetSingleObj(int id)
        {
            var obj = await _context.BioIPModel.FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<BioIPModel>> GetDBObj()
        {
            return await _context.BioIPModel.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<BioIPModel>> CreateObj(BioIPModel model)
        {
            _context.BioIPModel.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateObj(BioIPModel model)
        {
            var dbarea = await _context.BioIPModel.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea!.Location = model.Location;
            dbarea!.IP_Address = model.IP_Address;
            dbarea!.Port = model.Port;
            dbarea!.Device_Info = model.Device_Info;
            dbarea!.Machine = model.Machine;
            dbarea!.Machine = model.Machine;
            dbarea!.Machine_Reg = model.Machine_Reg;
            dbarea!.Is_AM = model.Is_AM;
            dbarea!.Is_PM = model.Is_PM;
            dbarea!.Status = model.Status;

            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }
    }
}
