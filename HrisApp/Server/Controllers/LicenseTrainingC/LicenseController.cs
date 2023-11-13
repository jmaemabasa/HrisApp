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
        public async Task<ActionResult<List<Emp_LicenseT>>> GetLicenselist([FromQuery] string verifyCode)
        {
            var licenses = await _context.Emp_LicenseT
                .Where(x => x.Verify_Id == verifyCode)
                .ToListAsync();

            return Ok(licenses);
        }


        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Updatelicense/{Id}")]
        public async Task<IActionResult> UpdateLicense(int Id, Emp_LicenseT _license)
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
        public async Task<ActionResult<List<Emp_LicenseT>>> DeleteLicense(int id)
        {
            var dblis = await _context.Emp_LicenseT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dblis == null)
                return NotFound("Sorry, but no senior");

            _context.Emp_LicenseT.Remove(dblis);

            await _context.SaveChangesAsync();

            return Ok(dblis);
        }

        private bool CheckLicenseId(int id)
        {
            return _context.Emp_LicenseT.Any(x => x.Id == id);
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("InsertLicense")]
        public async Task<ActionResult<Emp_LicenseT>> InsertLicense(Emp_LicenseT _license)
        {
            if (_license == null)
            {
                return BadRequest("Invalid data");
            }

            _context.Emp_LicenseT.Add(_license);
            await _context.SaveChangesAsync();

            return Ok(_license);
        }

        [HttpGet("Getlicenseisexist")]
        public async Task<ActionResult<IEnumerable<Emp_LicenseT>>> Getsettlementreportcount([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.Emp_LicenseT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }

        private async Task<List<Emp_LicenseT>> GetDbLicenses()
        {
            return await _context.Emp_LicenseT.ToListAsync();
        }
    }
}
