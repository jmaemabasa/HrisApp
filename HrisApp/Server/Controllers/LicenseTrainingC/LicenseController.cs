using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace HrisApp.Server.Controllers.LicenseTrainingC
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly DataContext _context;

        public LicenseController(DataContext context)
        {
            _context = context;
        }
        //ok
        [HttpGet("GetLicenselist")]
        public async Task<ActionResult<List<LicenseT>>> GetLicenselist([FromQuery] string verifyCode)
        {
            var licenses = await _context.LicenseT
                .Where(x => x.Verify_Id == verifyCode)
                .ToListAsync();

            return Ok(licenses);
        }


        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Updatelicense/{Id}")]
        public async Task<IActionResult> UpdateLicense(int Id, LicenseT _license)
        {

            if (Id != _license.Id)
            {
                return BadRequest();
            }

            _context.Entry(_license).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!CheckLicenseId(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbLicenses());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LicenseT>>> DeleteLicense(int id)
        {
            var dblis = await _context.LicenseT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dblis == null)
                return NotFound("Sorry, but no senior");

            _context.LicenseT.Remove(dblis);

            await _context.SaveChangesAsync();

            return Ok(dblis);
        }

        private bool CheckLicenseId(int id)
        {
            return _context.LicenseT.Any(x => x.Id == id);
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("InsertLicense")]
        public async Task<ActionResult<LicenseT>> InsertLicense(LicenseT _license)
        {
            if (_license == null)
            {
                return BadRequest("Invalid data");
            }

            _context.LicenseT.Add(_license);
            await _context.SaveChangesAsync();

            return Ok(_license);
        }

        [HttpGet("Getlicenseisexist")]
        public async Task<ActionResult<IEnumerable<LicenseT>>> Getsettlementreportcount([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.LicenseT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }

        private async Task<List<LicenseT>> GetDbLicenses()
        {
            return await _context.LicenseT.ToListAsync();
        }
    }
}
