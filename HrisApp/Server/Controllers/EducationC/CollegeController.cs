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
        public async Task<ActionResult<List<Emp_CollegeT>>> GetCollegelist([FromQuery] string verCode)
        {
            var collegelist = await _context.Emp_CollegeT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(collegelist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateCollege/{id}")]
        public async Task<IActionResult> PutCollege(int id, Emp_CollegeT _colleges)
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
        public async Task<ActionResult<Emp_CollegeT>> CreateCollege([FromBody] Emp_CollegeT _colleges)
        {
            if (_colleges == null)
            {
                return BadRequest("Invalid data");
            }

            _context.Emp_CollegeT.Add(_colleges);
            await _context.SaveChangesAsync();

            return Ok(_colleges);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Emp_CollegeT>>> DeleteCollege(int id)
        {
            var dbcol = await _context.Emp_CollegeT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            _context.Emp_CollegeT.Remove(dbcol);

            await _context.SaveChangesAsync();

            return Ok(dbcol);
        }

        private bool CollegeExists(int id)
        {
            return (_context.Emp_CollegeT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<Emp_CollegeT>> GetDbCollege()
        {
            return await _context.Emp_CollegeT.ToListAsync();
        }

        [HttpGet("GetExistCollege")]
        public async Task<ActionResult<IEnumerable<Emp_CollegeT>>> GetExistCollege([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.Emp_CollegeT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
