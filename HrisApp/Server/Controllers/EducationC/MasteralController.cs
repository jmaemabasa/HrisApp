using HrisApp.Shared.Models.Education;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EducationC
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasteralController : ControllerBase
    {
        private readonly DataContext _context;

        public MasteralController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("GetMasterlist")]
        public async Task<ActionResult<List<MasteralT>>> GetMasterlist([FromQuery] string verCode)
        {
            var masterlist = await _context.MasteralT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();


            return Ok(masterlist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateMasteral/{id}")]
        public async Task<IActionResult> PutMasteral(int id, MasteralT _masters)
        {
            if (id != _masters.Id)
            {
                return BadRequest();
            }

            _context.Entry(_masters).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!MasteralExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(await GetDbMasteral());
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MasteralT>> CreateMasteral([FromBody] MasteralT _mas)
        {
            if (_mas == null)
            {
                return BadRequest("Invalid data");
            }

            _context.MasteralT.Add(_mas);
            await _context.SaveChangesAsync();

            return Ok(_mas);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<MasteralT>>> DeleteMasteral(int id)
        {
            var dbmas = await _context.MasteralT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbmas == null)
                return NotFound("Sorry, but no senior");

            _context.MasteralT.Remove(dbmas);

            await _context.SaveChangesAsync();

            return Ok(dbmas);
        }

        private bool MasteralExists(int id)
        {
            return (_context.MasteralT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<MasteralT>> GetDbMasteral()
        {
            return await _context.MasteralT.ToListAsync();
        }

        [HttpGet("GetExistMasteral")]
        public async Task<ActionResult<IEnumerable<MasteralT>>> GetExistMasteral([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.MasteralT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
