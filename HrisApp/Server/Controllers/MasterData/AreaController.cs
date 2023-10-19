using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MasterData
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly DataContext _context;

        public AreaController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AreaT>>> GetAreaList()
        {
            var area = await _context.AreaT.ToListAsync();
            return Ok(area);
        }

        [HttpGet("GetArea")]
        public async Task<ActionResult<List<AreaT>>> GeArea()
        {
            var area = await _context.AreaT.ToListAsync();
            return Ok(area);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AreaT>> GetSingleArea(int id)
        {
            var area = await _context.AreaT.FindAsync(id);

            if (area == null)
            {
                return NotFound();
            }
            return area;
        }

        private async Task<List<AreaT>> GetDBArea()
        {
            return await _context.AreaT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateArea")]
        public async Task<ActionResult<AreaT>> CreateArea(AreaT area)
        {
            _context.AreaT.Add(area);
            await _context.SaveChangesAsync();

            return Ok(await GetDBArea());
        }

        [HttpPut("UpdateArea")]
        public async Task<ActionResult> UpdateArea(AreaT area)
        {
            var dbarea = await _context.AreaT.FirstOrDefaultAsync(d => d.Id == area.Id);

            dbarea.Name = area.Name;
            await _context.SaveChangesAsync();

            return Ok(await GetDBArea());
        }
    }
}
