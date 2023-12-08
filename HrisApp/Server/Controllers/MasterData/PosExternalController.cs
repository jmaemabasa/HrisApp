using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MasterData
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosExternalController : ControllerBase
    {
        private readonly DataContext _context;

        public PosExternalController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<PosMPExternalT>>> GetExternalList()
        {
            var obj = await _context.PosMPExternalT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetExternal")]
        public async Task<ActionResult<List<PosMPExternalT>>> GetExternal()
        {
            var obj = await _context.PosMPExternalT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PosMPExternalT>> GetSingleExternal(int id)
        {
            var obj = await _context.PosMPExternalT.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        private async Task<List<PosMPExternalT>> GetDBExternal()
        {
            return await _context.PosMPExternalT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateExternal")]
        public async Task<ActionResult<PosMPExternalT>> CreateExternal(PosMPExternalT obj)
        {
            _context.PosMPExternalT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(await GetDBExternal());
        }

        [HttpPut("UpdateExternal")]
        public async Task<ActionResult> UpdateExternal(PosMPExternalT obj)
        {
            var dbdiv = await _context.PosMPExternalT.FirstOrDefaultAsync(d => d.Id == obj.Id);

            dbdiv.External_Name = obj.External_Name;
            await _context.SaveChangesAsync();

            return Ok(await GetDBExternal());
        }
    }
}
