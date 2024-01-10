using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails.OtherAwardsTraining
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppOtherAwardsController : ControllerBase
    {
        private readonly DataContext _context;

        public AppOtherAwardsController(DataContext context)
        {
            _context = context;
        }
        //ok
        [HttpGet("GetOtherAwardslist")]
        public async Task<ActionResult<List<App_OtherAwardsT>>> GetOtherAwardslist([FromQuery] string verifyCode)
        {
            var licenses = await _context.App_OtherAwardsT
                .Where(x => x.Verify_Id == verifyCode)
                .ToListAsync();

            return Ok(licenses);
        }


        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateOtherAwards/{Id}")]
        public async Task<IActionResult> UpdateOtherAwards(int Id, App_OtherAwardsT _license)
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
                if (!CheckOtherAwardsId(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbOtherAwardss());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<App_OtherAwardsT>>> DeleteOtherAwards(int id)
        {
            var dblis = await _context.App_OtherAwardsT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dblis == null)
                return NotFound("Sorry, but no senior");

            _context.App_OtherAwardsT.Remove(dblis);

            await _context.SaveChangesAsync();

            return Ok(dblis);
        }

        private bool CheckOtherAwardsId(int id)
        {
            return _context.App_OtherAwardsT.Any(x => x.Id == id);
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("InsertOtherAwards")]
        public async Task<ActionResult<App_OtherAwardsT>> InsertOtherAwards(App_OtherAwardsT _license)
        {
            if (_license == null)
            {
                return BadRequest("Invalid data");
            }

            _context.App_OtherAwardsT.Add(_license);
            await _context.SaveChangesAsync();

            return Ok(_license);
        }

        [HttpGet("GetOtherAwardsisexist")]
        public async Task<ActionResult<IEnumerable<App_OtherAwardsT>>> Getsettlementreportcount([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.App_OtherAwardsT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }

        private async Task<List<App_OtherAwardsT>> GetDbOtherAwardss()
        {
            return await _context.App_OtherAwardsT.ToListAsync();
        }
    }
}
