using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails.Children
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppChildrenController : ControllerBase
    {
        private readonly DataContext _context;

        public AppChildrenController(DataContext context)
        {
            _context = context;
        }
        //ok
        [HttpGet("GetChildrenlist")]
        public async Task<ActionResult<List<App_ChildrenT>>> GetChildrenlist([FromQuery] string verifyCode)
        {
            var licenses = await _context.App_ChildrenT
                .Where(x => x.App_VerifyId == verifyCode)
                .ToListAsync();

            return Ok(licenses);
        }


        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateChildren/{Id}")]
        public async Task<IActionResult> UpdateChildren(int Id, App_ChildrenT _license)
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
                if (!CheckChildrenId(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbChildrens());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<App_ChildrenT>>> DeleteChildren(int id)
        {
            var dblis = await _context.App_ChildrenT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dblis == null)
                return NotFound("Sorry, but no senior");

            _context.App_ChildrenT.Remove(dblis);

            await _context.SaveChangesAsync();

            return Ok(dblis);
        }

        private bool CheckChildrenId(int id)
        {
            return _context.App_ChildrenT.Any(x => x.Id == id);
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("InsertChildren")]
        public async Task<ActionResult<App_ChildrenT>> InsertChildren(App_ChildrenT _license)
        {
            if (_license == null)
            {
                return BadRequest("Invalid data");
            }

            _context.App_ChildrenT.Add(_license);
            await _context.SaveChangesAsync();

            return Ok(_license);
        }

        [HttpGet("GetChildrenisexist")]
        public async Task<ActionResult<IEnumerable<App_ChildrenT>>> Getsettlementreportcount([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.App_ChildrenT.Where(a => a.App_VerifyId == verifyId && a.Id == id).ToListAsync();
        }

        private async Task<List<App_ChildrenT>> GetDbChildrens()
        {
            return await _context.App_ChildrenT.ToListAsync();
        }
    }
}
