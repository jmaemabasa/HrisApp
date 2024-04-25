using HrisApp.Shared.Models.SettingsM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MaintenanceC
{
#nullable disable
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly DataContext _context;

        public MaintenanceController(DataContext context)
        {
            _context = context;
        }


        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<MaintenanceT>>> GetObjList()
        {
            var obj = await _context.MaintenanceT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<MaintenanceT>>> GetObj()
        {
            var obj = await _context.MaintenanceT.ToListAsync();
            return Ok(obj);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<MaintenanceT>> GetSingleObj(int id)
        {
            var obj = await _context.MaintenanceT.FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<MaintenanceT>> GetDBObj()
        {
            return await _context.MaintenanceT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<MaintenanceT>> CreateObj(MaintenanceT model)
        {
            _context.MaintenanceT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetIsMaintain")]
        public async Task<ActionResult<bool>> GetIsMaintain()
        {
            var datetoday = DateTime.Now;
            MaintenanceT model = new();
            model = await _context.MaintenanceT.Where(e => e.IsMaintain == true && e.DateStart.Value.Date == datetoday.Date || e.DateEnd.Value.Date == datetoday.Date)
                .FirstOrDefaultAsync();

            if (model == null)
                return Ok(false);

            return Ok(model!.IsMaintain);
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateObj(MaintenanceT model)
        {
            var dbarea = await _context.MaintenanceT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea!.IsMaintain = model.IsMaintain;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }
    }
}
