using HrisApp.Shared.Models.Education;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EducationC
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly DataContext _context;

        public CollegeController(DataContext context)
        {
            _context = context;
        }

        //ok
        [HttpGet("GetCollegelist")]
        public async Task<ActionResult<List<CollegeT>>> GetCollegelist([FromQuery] string verCode)
        {
            var collegelist = await _context.CollegeT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(collegelist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateCollege/{id}")]
        public async Task<IActionResult> PutCollege(int id, CollegeT _colleges)
        {
            if (id != _colleges.Id)
            {
                return BadRequest();
            }

            _context.Entry(_colleges).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!CollegeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbCollege());
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollegeT>> CreateCollege([FromBody] CollegeT _colleges)
        {
            if (_colleges == null)
            {
                return BadRequest("Invalid data");
            }

            _context.CollegeT.Add(_colleges);
            await _context.SaveChangesAsync();

            return Ok(_colleges);
        }

        private bool CollegeExists(int id)
        {
            return (_context.CollegeT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<CollegeT>> GetDbCollege()
        {
            return await _context.CollegeT.ToListAsync();
        }

        [HttpGet("GetExistCollege")]
        public async Task<ActionResult<IEnumerable<CollegeT>>> GetExistCollege([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.CollegeT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
