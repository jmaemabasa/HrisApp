using HrisApp.Shared.Models.Education;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<List<SeniorHST>>> GetSeniorHSlist([FromQuery] string verCode)
        {
            var seniorlist = await _context.SeniorHST
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(seniorlist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateSeniorHS/{id}")]
        public async Task<ActionResult<List<SeniorHST>>> PutSeniorHS(int id, SeniorHST _seniors)
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
                if (!TrainingsExists(id))
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
        public async Task<ActionResult<SeniorHST>> CreateSeniorHS([FromBody] SeniorHST _shs)
        {
            if (_shs == null)
            {
                return BadRequest("Invalid data");
            }
            _context.SeniorHST.Add(_shs);
            await _context.SaveChangesAsync();

            return Ok(_shs);
        }

        private bool TrainingsExists(int id)
        {
            return (_context.SeniorHST?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        private async Task<List<SeniorHST>> GetDbSeniorHSTable()
        {
            return await _context.SeniorHST.ToListAsync();
        }

        [HttpGet("GetExistSeniorHS")]
        public async Task<ActionResult<IEnumerable<SeniorHST>>> GetExistSeniorHS([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.SeniorHST.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
