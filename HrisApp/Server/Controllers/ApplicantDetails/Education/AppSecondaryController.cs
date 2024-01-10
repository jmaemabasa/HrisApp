using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails.Education
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppSecondaryController : ControllerBase
    {
        private readonly DataContext _context;

        public AppSecondaryController(DataContext context)
        {
            _context = context;

        }

        //ok
        [HttpGet("GetSecondarylist")]
        public async Task<ActionResult<List<App_SecondaryT>>> GetSecondarylist([FromQuery] string verCode)
        {
            var secondarylist = await _context.App_SecondaryT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(secondarylist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateSecondary/{id}")]
        public async Task<IActionResult> PutSecondary(int id, App_SecondaryT _secondaries)
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
            return (_context.App_SecondaryT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<App_SecondaryT>> CreateSecondary([FromBody] App_SecondaryT _secondaries)
        {
            if (_secondaries == null)
            {
                return BadRequest("Invalid data");
            }

            _context.App_SecondaryT.Add(_secondaries);
            await _context.SaveChangesAsync();
            return Ok(_secondaries);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<App_SecondaryT>>> DeleteSecondary(int id)
        {
            var dbsecondary = await _context.App_SecondaryT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbsecondary == null)
                return NotFound("Sorry, but no primary");

            _context.App_SecondaryT.Remove(dbsecondary);

            await _context.SaveChangesAsync();

            return Ok(dbsecondary);
        }

        private async Task<List<App_SecondaryT>> GetDbSecondary()
        {
            return await _context.App_SecondaryT.ToListAsync();
        }

        [HttpGet("GetExistSecondary")]
        public async Task<ActionResult<IEnumerable<App_SecondaryT>>> GetExistSecondary([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.App_SecondaryT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
