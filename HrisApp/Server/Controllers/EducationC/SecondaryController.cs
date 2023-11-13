using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EducationC
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecondaryController : ControllerBase
    {
        private readonly DataContext _context;

        public SecondaryController(DataContext context)
        {
            _context = context;

        }

        //ok
        [HttpGet("GetSecondarylist")]
        public async Task<ActionResult<List<Emp_SecondaryT>>> GetSecondarylist([FromQuery] string verCode)
        {
            var secondarylist = await _context.Emp_SecondaryT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(secondarylist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateSecondary/{id}")]
        public async Task<IActionResult> PutSecondary(int id, Emp_SecondaryT _secondaries)
        {
            if (id != _secondaries.Id)
            {
                return BadRequest();
            }

            _context.Entry(_secondaries).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!SecondaryExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbSecondary());
        }

        private bool SecondaryExist(int id)
        {
            return (_context.Emp_SecondaryT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emp_SecondaryT>> CreateSecondary([FromBody] Emp_SecondaryT _secondaries)
        {
            if (_secondaries == null)
            {
                return BadRequest("Invalid data");
            }

            _context.Emp_SecondaryT.Add(_secondaries);
            await _context.SaveChangesAsync();
            return Ok(_secondaries);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Emp_SecondaryT>>> DeleteSecondary(int id)
        {
            var dbsecondary = await _context.Emp_SecondaryT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbsecondary == null)
                return NotFound("Sorry, but no primary");

            _context.Emp_SecondaryT.Remove(dbsecondary);

            await _context.SaveChangesAsync();

            return Ok(dbsecondary);
        }

        private async Task<List<Emp_SecondaryT>> GetDbSecondary()
        {
            return await _context.Emp_SecondaryT.ToListAsync();
        }

        [HttpGet("GetExistSecondary")]
        public async Task<ActionResult<IEnumerable<Emp_SecondaryT>>> GetExistSecondary([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.Emp_SecondaryT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
