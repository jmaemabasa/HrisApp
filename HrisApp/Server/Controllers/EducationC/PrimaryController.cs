using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EducationC
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimaryController : ControllerBase
    {
        public DataContext _context { get; }

        public PrimaryController(DataContext context)
        {
            _context = context;
        }

        //ok
        [HttpGet("GetPrimarylist")]
        public async Task<ActionResult<List<Emp_PrimaryT>>> GetPrimarylist([FromQuery] string verCode)
        {
            var primarylist = await _context.Emp_PrimaryT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(primarylist);
        }

        [HttpPut("UpdatePrimary/{id}")]
        public async Task<IActionResult> PutPrimary(int id, Emp_PrimaryT _primaries)
        {
            if (id != _primaries.Id)
            {
                return BadRequest();
            }

            _context.Entry(_primaries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!TrainingsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbPrimary());
        }

        private bool TrainingsExists(int id)
        {
            return (_context.Emp_PrimaryT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        [HttpGet("Getprimarycount")]
        public async Task<ActionResult<int>> GetImageCount([FromQuery] string verifyId)
        {
            var _crrList = await _context.Emp_PrimaryT.Where(a => a.Verify_Id == verifyId).ToListAsync();
            return _crrList.Count();
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emp_PrimaryT>> CreatePrimary([FromBody] Emp_PrimaryT primary)
        {
            if (primary == null)
            {
                return BadRequest("Invalid data");
            }

            _context.Emp_PrimaryT.Add(primary);
            await _context.SaveChangesAsync();
            return Ok(primary);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Emp_PrimaryT>>> DeletePrimary(int id)
        {
            var dbprimary = await _context.Emp_PrimaryT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbprimary == null)
                return NotFound("Sorry, but no primary");

            _context.Emp_PrimaryT.Remove(dbprimary);

            await _context.SaveChangesAsync();

            return Ok(dbprimary);
        }

        private async Task<List<Emp_PrimaryT>> GetDbPrimary()
        {
            return await _context.Emp_PrimaryT.ToListAsync();
        }

        [HttpGet("GetExistPrimary")]
        public async Task<ActionResult<IEnumerable<Emp_PrimaryT>>> GetExistPrimary([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.Emp_PrimaryT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
