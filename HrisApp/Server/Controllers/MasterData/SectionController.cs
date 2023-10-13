using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MasterData
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly DataContext _context;

        public SectionController(DataContext context)
        {
            _context = context;
        }

        //GEEEEEEEEEEET
        [HttpGet("SectByDepartment/{departmentId}")]
        public async Task<ActionResult<List<SectionT>>> GetSectByDepartment(int departmentId)
        {
            var section = await _context.SectionT
                .Where(sect => sect.DepartmentId == departmentId)
                .ToListAsync();
            return Ok(section);
        }

        [HttpGet]
        public async Task<ActionResult<List<SectionT>>> GetSectionList()
        {
            var section = await _context.SectionT
                .ToListAsync();
            return Ok(section);
        }

        [HttpGet("GetSection")]
        public async Task<ActionResult<List<SectionT>>> GetSection()
        {
            var sect = await _context.SectionT
                .Include(sect => sect.Department)
                .ToListAsync();
            return Ok(sect);

        }

        private async Task<List<SectionT>> GetDBSection()
        {
            return await _context.SectionT
                .ToListAsync();
        }

        //CREATE AND UPDATEEEE

        [HttpPost("CreateSection")]
        public async Task<ActionResult<SectionT>> CreateSection(SectionT sec)
        {
            _context.SectionT.Add(sec);
            await _context.SaveChangesAsync();

            return Ok(await GetDBSection());
        }

        [HttpPut("UpdateSection")]
        public async Task<ActionResult> UpdateSection(SectionT sect)
        {
            var dbsect = await _context.SectionT.FirstOrDefaultAsync(d => d.Id == sect.Id);

            dbsect.Name = sect.Name;

            await _context.SaveChangesAsync();

            return Ok(await GetDBSection());
        }
    }
}
