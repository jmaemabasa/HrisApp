using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails.LicenseTraining
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppProfBackgroundController : ControllerBase
    {
        private readonly DataContext _context;

        public AppProfBackgroundController(DataContext context)
        {
            _context = context;
        }
        //ok
        [HttpGet("GetProfBglist")]
        public async Task<ActionResult<List<App_ProfBackgroundT>>> GetProfBglist([FromQuery] string verifyCode)
        {
            var licenses = await _context.App_ProfBackgroundT
                .Where(x => x.App_VerifyId == verifyCode)
                .ToListAsync();

            return Ok(licenses);
        }


        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateProfBg/{Id}")]
        public async Task<IActionResult> UpdateProfBg(int Id, App_ProfBackgroundT _bg)
        {

            if (Id != _bg.Id)
            {
                return BadRequest();
            }

            _context.Entry(_bg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!CheckBgId(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbProfbg());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<App_ProfBackgroundT>>> DeleteProfBg(int id)
        {
            var dbBg = await _context.App_ProfBackgroundT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbBg == null)
                return NotFound("Sorry, but no senior");

            _context.App_ProfBackgroundT.Remove(dbBg);

            await _context.SaveChangesAsync();

            return Ok(dbBg);
        }

        private bool CheckBgId(int id)
        {
            return _context.App_ProfBackgroundT.Any(x => x.Id == id);
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("InsertProfBg")]
        public async Task<ActionResult<App_ProfBackgroundT>> InsertProfBg(App_ProfBackgroundT _bg)
        {
            if (_bg == null)
            {
                return BadRequest("Invalid data");
            }

            _context.App_ProfBackgroundT.Add(_bg);
            await _context.SaveChangesAsync();

            return Ok(_bg);
        }

        [HttpGet("Getbgisexist")]
        public async Task<ActionResult<IEnumerable<App_ProfBackgroundT>>> Getsettlementreportcount([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.App_ProfBackgroundT.Where(a => a.App_VerifyId == verifyId && a.Id == id).ToListAsync();
        }

        private async Task<List<App_ProfBackgroundT>> GetDbProfbg()
        {
            return await _context.App_ProfBackgroundT.ToListAsync();
        }
    }
}
