using HrisApp.Shared.Models.Education;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EducationC
{
    [Route("api/[controller]")]
    [ApiController]
    public class OthersEducController : ControllerBase
    {
        private readonly DataContext _context;

        public OthersEducController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetOtherEduclist")]
        public async Task<ActionResult<List<OtherEducT>>> GetOtherEduclist([FromQuery] string verCode)
        {
            var otherEduclist = await _context.OtherEducT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(otherEduclist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateOtherEduc/{id}")]
        public async Task<ActionResult<List<OtherEducT>>> PutOtherEduc(int id, OtherEducT _others)
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
        public async Task<ActionResult<OtherEducT>> CreateOtherEduc([FromBody] OtherEducT _others)
        {
            if (_others == null)
            {
                return BadRequest("Invalid data");
            }


            _context.OtherEducT.Add(_others);
            await _context.SaveChangesAsync();

            return Ok(_others);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OtherEducT>>> DeleteOtherEduc(int id)
        {
            var dbother = await _context.OtherEducT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbother == null)
                return NotFound("Sorry, but no senior");

            _context.OtherEducT.Remove(dbother);

            await _context.SaveChangesAsync();

            return Ok(dbother);
        }

        private bool OtherEducExists(int id)
        {
            return (_context.OtherEducT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<OtherEducT>> GetDbOtherEduc()
        {
            return await _context.OtherEducT.ToListAsync();
        }

        [HttpGet("GetExistOtherEduc")]
        public async Task<ActionResult<IEnumerable<OtherEducT>>> GetExistOtherEduc([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.OtherEducT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
