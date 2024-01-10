using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails.LicenseTraining
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppLicenseController : ControllerBase
    {
        private readonly DataContext _context;

        public AppLicenseController(DataContext context)
        {
            _context = context;
        }
        //ok
        [HttpGet("GetLicenselist")]
        public async Task<ActionResult<List<App_LicenseT>>> GetLicenselist([FromQuery] string verifyCode)
        {
            var licenses = await _context.App_LicenseT
                .Where(x => x.Verify_Id == verifyCode)
                .ToListAsync();

            return Ok(licenses);
        }


        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Updatelicense/{Id}")]
        public async Task<IActionResult> UpdateLicense(int Id, App_LicenseT _license)
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
        public async Task<ActionResult<List<App_LicenseT>>> DeleteLicense(int id)
        {
            var dblis = await _context.App_LicenseT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dblis == null)
                return NotFound("Sorry, but no senior");

            _context.App_LicenseT.Remove(dblis);

            await _context.SaveChangesAsync();

            return Ok(dblis);
        }

        private bool CheckLicenseId(int id)
        {
            return _context.App_LicenseT.Any(x => x.Id == id);
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("InsertLicense")]
        public async Task<ActionResult<App_LicenseT>> InsertLicense(App_LicenseT _license)
        {
            if (_license == null)
            {
                return BadRequest("Invalid data");
            }

            _context.App_LicenseT.Add(_license);
            await _context.SaveChangesAsync();

            return Ok(_license);
        }

        [HttpGet("Getlicenseisexist")]
        public async Task<ActionResult<IEnumerable<App_LicenseT>>> Getsettlementreportcount([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.App_LicenseT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }

        private async Task<List<App_LicenseT>> GetDbLicenses()
        {
            return await _context.App_LicenseT.ToListAsync();
        }
    }
}
