using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.LicenseTrainingC
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfBackgroundController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfBackgroundController(DataContext context)
        {
            _context = context;
        }
        //ok
        [HttpGet("GetProfBglist")]
        public async Task<ActionResult<List<Emp_ProfBackgroundT>>> GetProfBglist([FromQuery] string verifyCode)
        {
            var licenses = await _context.Emp_ProfBackgroundT
                .Where(x => x.Verify_Id == verifyCode)
                .ToListAsync();

            return Ok(licenses);
        }


        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateProfBg/{Id}")]
        public async Task<IActionResult> UpdateProfBg(int Id, Emp_ProfBackgroundT _bg)
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
        public async Task<ActionResult<List<Emp_ProfBackgroundT>>> DeleteProfBg(int id)
        {
            var dbBg = await _context.Emp_ProfBackgroundT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbBg == null)
                return NotFound("Sorry, but no senior");

            _context.Emp_ProfBackgroundT.Remove(dbBg);

            await _context.SaveChangesAsync();

            return Ok(dbBg);
        }

        private bool CheckBgId(int id)
        {
            return _context.Emp_ProfBackgroundT.Any(x => x.Id == id);
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("InsertProfBg")]
        public async Task<ActionResult<Emp_ProfBackgroundT>> InsertProfBg(Emp_ProfBackgroundT _bg)
        {
            if (_bg == null)
            {
                return BadRequest("Invalid data");
            }

            _context.Emp_ProfBackgroundT.Add(_bg);
            await _context.SaveChangesAsync();

            return Ok(_bg);
        }

        [HttpGet("Getbgisexist")]
        public async Task<ActionResult<IEnumerable<Emp_ProfBackgroundT>>> Getsettlementreportcount([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.Emp_ProfBackgroundT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }

        private async Task<List<Emp_ProfBackgroundT>> GetDbProfbg()
        {
            return await _context.Emp_ProfBackgroundT.ToListAsync();
        }
    }
}
