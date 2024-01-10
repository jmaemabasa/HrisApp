using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails.Education
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppOthersEducController : ControllerBase
    {
        private readonly DataContext _context;

        public AppOthersEducController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetOtherEduclist")]
        public async Task<ActionResult<List<App_OtherEducT>>> GetOtherEduclist([FromQuery] string verCode)
        {
            var otherEduclist = await _context.App_OtherEducT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(otherEduclist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateOtherEduc/{id}")]
        public async Task<ActionResult<List<App_OtherEducT>>> PutOtherEduc(int id, App_OtherEducT _others)
        {
            if (id != _others.Id)
            {
                return BadRequest();
            }

            _context.Entry(_others).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!OtherEducExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbOtherEduc());
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [HttpPost]
        public async Task<ActionResult<App_OtherEducT>> CreateOtherEduc([FromBody] App_OtherEducT _others)
        {
            if (_others == null)
            {
                return BadRequest("Invalid data");
            }


            _context.App_OtherEducT.Add(_others);
            await _context.SaveChangesAsync();

            return Ok(_others);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<App_OtherEducT>>> DeleteOtherEduc(int id)
        {
            var dbother = await _context.App_OtherEducT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbother == null)
                return NotFound("Sorry, but no senior");

            _context.App_OtherEducT.Remove(dbother);

            await _context.SaveChangesAsync();

            return Ok(dbother);
        }

        private bool OtherEducExists(int id)
        {
            return (_context.App_OtherEducT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<App_OtherEducT>> GetDbOtherEduc()
        {
            return await _context.App_OtherEducT.ToListAsync();
        }

        [HttpGet("GetExistOtherEduc")]
        public async Task<ActionResult<IEnumerable<App_OtherEducT>>> GetExistOtherEduc([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.App_OtherEducT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
