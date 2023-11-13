using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EducationC
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeniorHSController : ControllerBase
    {
        private readonly DataContext _context;

        public SeniorHSController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetSeniorHSlist")]
        public async Task<ActionResult<List<Emp_SeniorHST>>> GetSeniorHSlist([FromQuery] string verCode)
        {
            var seniorlist = await _context.Emp_SeniorHST
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(seniorlist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateSeniorHS/{id}")]
        public async Task<ActionResult<List<Emp_SeniorHST>>> PutSeniorHS(int id, Emp_SeniorHST _seniors)
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
        public async Task<ActionResult<Emp_SeniorHST>> CreateSeniorHS([FromBody] Emp_SeniorHST _shs)
        {
            if (_shs == null)
            {
                return BadRequest("Invalid data");
            }
            _context.Emp_SeniorHST.Add(_shs);
            await _context.SaveChangesAsync();

            return Ok(_shs);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Emp_SeniorHST>>> DeleteSHS(int id)
        {
            var dbshs = await _context.Emp_SeniorHST
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbshs == null)
                return NotFound("Sorry, but no senior");

            _context.Emp_SeniorHST.Remove(dbshs);

            await _context.SaveChangesAsync();

            return Ok(dbshs);
        }

        private bool SeniorHSExists(int id)
        {
            return (_context.Emp_SeniorHST?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        private async Task<List<Emp_SeniorHST>> GetDbSeniorHSTable()
        {
            return await _context.Emp_SeniorHST.ToListAsync();
        }

        [HttpGet("GetExistSeniorHS")]
        public async Task<ActionResult<IEnumerable<Emp_SeniorHST>>> GetExistSeniorHS([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.Emp_SeniorHST.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
