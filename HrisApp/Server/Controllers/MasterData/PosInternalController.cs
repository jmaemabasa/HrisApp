using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MasterData
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosInternalController : ControllerBase
    {
        private readonly DataContext _context;

        public PosInternalController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<PosMPInternalT>>> GetInternalList()
        {
            var obj = await _context.PosMPInternalT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetInternal")]
        public async Task<ActionResult<List<PosMPInternalT>>> GetInternal()
        {
            var obj = await _context.PosMPInternalT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PosMPInternalT>> GetSingleInternal(int id)
        {
            var obj = await _context.PosMPInternalT.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        private async Task<List<PosMPInternalT>> GetDBInternal()
        {
            return await _context.PosMPInternalT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateInternal")]
        public async Task<ActionResult<PosMPInternalT>> CreateInternal(PosMPInternalT obj)
        {
            _context.PosMPInternalT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(await GetDBInternal());
        }

        [HttpPut("UpdateInternal")]
        public async Task<ActionResult> UpdateInternal(PosMPInternalT obj)
        {
            var dbdiv = await _context.PosMPInternalT.FirstOrDefaultAsync(d => d.Id == obj.Id);

            dbdiv.Internal_Name = obj.Internal_Name;
            await _context.SaveChangesAsync();

            return Ok(await GetDBInternal());
        }
    }
}
