using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails.Education
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppMasteralController : ControllerBase
    {
        private readonly DataContext _context;

        public AppMasteralController(DataContext context)
        {
            _context = context;
        }
        [HttpGet("GetMasterlist")]
        public async Task<ActionResult<List<App_MasteralT>>> GetMasterlist([FromQuery] string verCode)
        {
            var masterlist = await _context.App_MasteralT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();


            return Ok(masterlist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateMasteral/{id}")]
        public async Task<IActionResult> PutMasteral(int id, App_MasteralT _masters)
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
        public async Task<ActionResult<App_MasteralT>> CreateMasteral([FromBody] App_MasteralT _mas)
        {
            if (_mas == null)
            {
                return BadRequest("Invalid data");
            }

            _context.App_MasteralT.Add(_mas);
            await _context.SaveChangesAsync();

            return Ok(_mas);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<App_MasteralT>>> DeleteMasteral(int id)
        {
            var dbmas = await _context.App_MasteralT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbmas == null)
                return NotFound("Sorry, but no senior");

            _context.App_MasteralT.Remove(dbmas);

            await _context.SaveChangesAsync();

            return Ok(dbmas);
        }

        private bool MasteralExists(int id)
        {
            return (_context.App_MasteralT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<App_MasteralT>> GetDbMasteral()
        {
            return await _context.App_MasteralT.ToListAsync();
        }

        [HttpGet("GetExistMasteral")]
        public async Task<ActionResult<IEnumerable<App_MasteralT>>> GetExistMasteral([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.App_MasteralT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
