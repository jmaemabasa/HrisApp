using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MasterData
{
#nullable disable
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
                .OrderBy(d => d.DivisionId)
                .ToListAsync();
            return Ok(section);
        }

        [HttpGet("SectByDivision/{divisionId}")]
        public async Task<ActionResult<List<SectionT>>> GetSectByDivision(int divisionId)
        {
            var section = await _context.SectionT
                .Where(sect => sect.DivisionId == divisionId)
                .OrderBy(d => d.DepartmentId)
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
                .ToListAsync();
            return Ok(sect);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SectionT>> GetSingleSection(int id)
        {
            var sect = await _context.SectionT.FindAsync(id);

            if (sect == null)
            {
                return NotFound();
            }

            return sect;
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


        [HttpGet("GetSectionId/{name}")]
        public async Task<ActionResult<int>> GetSectionId(string name)
        {
            var Masterlist = await _context.SectionT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }
    }
}
