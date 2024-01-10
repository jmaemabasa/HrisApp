using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails.Education
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppSeniorHSController : ControllerBase
    {
        private readonly DataContext _context;

        public AppSeniorHSController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetSeniorHSlist")]
        public async Task<ActionResult<List<App_SeniorHST>>> GetSeniorHSlist([FromQuery] string verCode)
        {
            var seniorlist = await _context.App_SeniorHST
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(seniorlist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateSeniorHS/{id}")]
        public async Task<ActionResult<List<App_SeniorHST>>> PutSeniorHS(int id, App_SeniorHST _seniors)
        {
            if (id != _seniors.Id)
            {
                return BadRequest();
            }

            _context.Entry(_seniors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!SeniorHSExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbSeniorHSTable());
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<App_SeniorHST>> CreateSeniorHS([FromBody] App_SeniorHST _shs)
        {
            if (_shs == null)
            {
                return BadRequest("Invalid data");
            }
            _context.App_SeniorHST.Add(_shs);
            await _context.SaveChangesAsync();

            return Ok(_shs);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<App_SeniorHST>>> DeleteSHS(int id)
        {
            var dbshs = await _context.App_SeniorHST
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbshs == null)
                return NotFound("Sorry, but no senior");

            _context.App_SeniorHST.Remove(dbshs);

            await _context.SaveChangesAsync();

            return Ok(dbshs);
        }

        private bool SeniorHSExists(int id)
        {
            return (_context.App_SeniorHST?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        private async Task<List<App_SeniorHST>> GetDbSeniorHSTable()
        {
            return await _context.App_SeniorHST.ToListAsync();
        }

        [HttpGet("GetExistSeniorHS")]
        public async Task<ActionResult<IEnumerable<App_SeniorHST>>> GetExistSeniorHS([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.App_SeniorHST.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
