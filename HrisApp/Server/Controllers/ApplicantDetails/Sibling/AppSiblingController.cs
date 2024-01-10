using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails.Sibling
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppSiblingController : ControllerBase
    {
        private readonly DataContext _context;

        public AppSiblingController(DataContext context)
        {
            _context = context;
        }
        //ok
        [HttpGet("GetSiblinglist")]
        public async Task<ActionResult<List<App_SiblingT>>> GetSiblinglist([FromQuery] string verifyCode)
        {
            var licenses = await _context.App_SiblingT
                .Where(x => x.App_VerifyId == verifyCode)
                .ToListAsync();

            return Ok(licenses);
        }


        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateSibling/{Id}")]
        public async Task<IActionResult> UpdateSibling(int Id, App_SiblingT _license)
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
                if (!CheckSiblingId(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbSiblings());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<App_SiblingT>>> DeleteSibling(int id)
        {
            var dblis = await _context.App_SiblingT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dblis == null)
                return NotFound("Sorry, but no senior");

            _context.App_SiblingT.Remove(dblis);

            await _context.SaveChangesAsync();

            return Ok(dblis);
        }

        private bool CheckSiblingId(int id)
        {
            return _context.App_SiblingT.Any(x => x.Id == id);
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("InsertSibling")]
        public async Task<ActionResult<App_SiblingT>> InsertSibling(App_SiblingT _license)
        {
            if (_license == null)
            {
                return BadRequest("Invalid data");
            }

            _context.App_SiblingT.Add(_license);
            await _context.SaveChangesAsync();

            return Ok(_license);
        }

        [HttpGet("Getlicenseisexist")]
        public async Task<ActionResult<IEnumerable<App_SiblingT>>> Getsettlementreportcount([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.App_SiblingT.Where(a => a.App_VerifyId == verifyId && a.Id == id).ToListAsync();
        }

        private async Task<List<App_SiblingT>> GetDbSiblings()
        {
            return await _context.App_SiblingT.ToListAsync();
        }
    }
}
