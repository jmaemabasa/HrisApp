using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EducationC
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorateController : ControllerBase
    {
        private readonly DataContext _context;

        public DoctorateController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetDoctoratelist")]
        public async Task<ActionResult<List<Emp_DoctorateT>>> GetDoctoratelist([FromQuery] string verCode)
        {
            var doctoratelist = await _context.Emp_DoctorateT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(doctoratelist);
        }

        // PUT: api/WorkExperiences/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("UpdateDoctorate/{id}")]
        public async Task<IActionResult> PutDoctorate(int id, Emp_DoctorateT _doctorates)
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
        public async Task<ActionResult<Emp_DoctorateT>> CreateDoctorate([FromBody] Emp_DoctorateT _doc)
        {
            if (_doc == null)
            {
                return BadRequest("Invalid data");
            }

            _context.Emp_DoctorateT.Add(_doc);
            await _context.SaveChangesAsync();

            return Ok(_doc);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Emp_DoctorateT>>> DeleteDoctorate(int id)
        {
            var dbdoc = await _context.Emp_DoctorateT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbdoc == null)
                return NotFound("Sorry, but no senior");

            _context.Emp_DoctorateT.Remove(dbdoc);

            await _context.SaveChangesAsync();

            return Ok(dbdoc);
        }

        private bool DoctorateExists(int id)
        {
            return (_context.Emp_DoctorateT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<Emp_DoctorateT>> GetDbDoctorate()
        {
            return await _context.Emp_DoctorateT.ToListAsync();
        }

        [HttpGet("GetExistDoctorate")]
        public async Task<ActionResult<IEnumerable<Emp_DoctorateT>>> GetExistDoctorate([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.Emp_DoctorateT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
