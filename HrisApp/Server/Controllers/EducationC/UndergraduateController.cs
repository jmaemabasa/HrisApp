using HrisApp.Shared.Models.Employee.Emp_Education;

namespace HrisApp.Server.Controllers.EducationC
{
    [Route("api/[controller]")]
    [ApiController]
    public class UndergraduateController : ControllerBase
    {
        private readonly DataContext _context;

        public UndergraduateController(DataContext context)
        {
            _context = context;
        }

        //ok
        [HttpGet("GetObjlist")]
        public async Task<ActionResult<List<Emp_UndergraduateT>>> GetObjlist([FromQuery] string verCode)
        {
            var objlist = await _context.Emp_UndergraduateT
                .Where(x => x.Verify_Id == verCode)
                .ToListAsync();

            return Ok(objlist);
        }

        // PUT: api/WorkExperiences/5
        [HttpPut("UpdateObj/{id}")]
        public async Task<IActionResult> UpdateObj(int id, Emp_UndergraduateT _obj)
        {
            if (id != _obj.Id)
            {
                return BadRequest();
            }

            _context.Entry(_obj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ObjExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await GetDbobj());
        }

        // POST: api/WorkExperiences
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emp_UndergraduateT>> CreateObj([FromBody] Emp_UndergraduateT _obj)
        {
            if (_obj == null)
            {
                return BadRequest("Invalid data");
            }

            _context.Emp_UndergraduateT.Add(_obj);
            await _context.SaveChangesAsync();

            return Ok(_obj);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Emp_UndergraduateT>>> DeleteObj(int id)
        {
            var dbcol = await _context.Emp_UndergraduateT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            _context.Emp_UndergraduateT.Remove(dbcol);

            await _context.SaveChangesAsync();

            return Ok(dbcol);
        }

        private bool ObjExists(int id)
        {
            return (_context.Emp_UndergraduateT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<Emp_UndergraduateT>> GetDbobj()
        {
            return await _context.Emp_UndergraduateT.ToListAsync();
        }

        [HttpGet("GetExistobj")]
        public async Task<ActionResult<IEnumerable<Emp_UndergraduateT>>> GetExistobj([FromQuery] string verifyId, [FromQuery] int id)
        {
            return await _context.Emp_UndergraduateT.Where(a => a.Verify_Id == verifyId && a.Id == id).ToListAsync();
        }
    }
}
