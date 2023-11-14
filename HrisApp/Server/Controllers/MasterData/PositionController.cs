using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MasterData
{
#nullable disable
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly DataContext _context;

        public PositionController(DataContext context)
        {
            _context = context;
        }

        //GEEEEEEETT
        //Get Position by Section
        [HttpGet("PosBySection/{sectionId}")]
        public async Task<ActionResult<List<PositionT>>> GetPosBySection(int sectionId)
        {
            var pos = await _context.PositionT
                .Where(sect => sect.SectionId == sectionId)
                .OrderBy(d => d.DepartmentId)
                .ToListAsync();
            return Ok(pos);
        }

        //Get Position by Division
        [HttpGet("PosByDivision/{divisionId}")]
        public async Task<ActionResult<List<PositionT>>> GetPosByDivision(int divisionId)
        {
            var pos = await _context.PositionT
                .Where(div => div.DivisionId == divisionId)
                .OrderBy(d => d.DepartmentId)
                .ToListAsync();
            return Ok(pos);
        }

        //Get Position by Department
        [HttpGet("PosByDepartment/{departmentId}")]
        public async Task<ActionResult<List<PositionT>>> GetPosByDepartment(int departmentId)
        {
            var pos = await _context.PositionT
                .Where(dep => dep.DepartmentId == departmentId)
                .OrderBy(d => d.DivisionId)
                .OrderBy(s => s.SectionId)
                .ToListAsync();
            return Ok(pos);
        }

        //Get ALL Position List without Filter
        [HttpGet]
        public async Task<ActionResult<List<PositionT>>> GetPositionList()
        {
            var pos = await _context.PositionT
                .ToListAsync();
            return Ok(pos);
        }

        //GET ALL POSITIONs MAIN
        [HttpGet("GetPosition")]
        public async Task<ActionResult<List<PositionT>>> GetPosition()
        {
            var pos = await _context.PositionT
                .ToListAsync();
            return Ok(pos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PositionT>> GetSinglePosition(int id)
        {
            var pos = await _context.PositionT.FindAsync(id);

            if (pos == null)
            {
                return NotFound();
            }

            return pos;
        }

        //Get all list
        private async Task<List<PositionT>> GetDBPosition()
        {
            return await _context.PositionT
                .ToListAsync();
        }

        //CREATE AND UPDATEEEE

        [HttpPost("CreatePosition")]
        public async Task<ActionResult<PositionT>> CreatePosition(PositionT pos)
        {
            _context.PositionT.Add(pos);
            await _context.SaveChangesAsync();

            return Ok(await GetDBPosition());
        }

        [HttpPut("UpdatePosition")]
        public async Task<ActionResult> UpdatePosition(PositionT pos)
        {
            var dbpos = await _context.PositionT.FirstOrDefaultAsync(d => d.Id == pos.Id);

            dbpos.Name = pos.Name;
            dbpos.Plantilla = pos.Plantilla;

            await _context.SaveChangesAsync();

            return Ok(await GetDBPosition());
        }
    }
}
