using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails.Education
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppDoctorateController : ControllerBase
    {
        private readonly DataContext _context;

        public AppDoctorateController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetDoctoratelist")]
        public async Task<ActionResult<List<App_DoctorateT>>> GetDoctoratelist([FromQuery] string verCode)
        {
            var doctoratelist = await _context.App_DoctorateT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(doctoratelist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateDoctorate/{id}")]
        public async Task<IActionResult> PutDoctorate(int id, App_DoctorateT _doctorates)
        {
            if (id != _doctorates.Id)
            {
                return BadRequest();
            }

            _context.Entry(_doctorates).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorateExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbDoctorate());
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<App_DoctorateT>> CreateDoctorate([FromBody] App_DoctorateT _doc)
        {
            if (_doc == null)
            {
                return BadRequest("Invalid data");
            }

            _context.App_DoctorateT.Add(_doc);
            await _context.SaveChangesAsync();

            return Ok(_doc);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<App_DoctorateT>>> DeleteDoctorate(int id)
        {
            var dbdoc = await _context.App_DoctorateT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbdoc == null)
                return NotFound("Sorry, but no senior");

            _context.App_DoctorateT.Remove(dbdoc);

            await _context.SaveChangesAsync();

            return Ok(dbdoc);
        }

        private bool DoctorateExists(int id)
        {
            return (_context.App_DoctorateT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<App_DoctorateT>> GetDbDoctorate()
        {
            return await _context.App_DoctorateT.ToListAsync();
        }

        [HttpGet("GetExistDoctorate")]
        public async Task<ActionResult<IEnumerable<App_DoctorateT>>> GetExistDoctorate([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.App_DoctorateT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
