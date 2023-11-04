using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EmployeeDetails.EmploymentDateC
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploymentDateController : ControllerBase
    {
        private readonly DataContext _context;

        public EmploymentDateController(DataContext context)
        {
            _context = context;
        }

        // GET: api/EmploymentDate
        [HttpGet("GetEmploymentDate")]
        public async Task<ActionResult<IEnumerable<EmploymentDateT>>> GetEmploymentDate()
        {
            var date = await _context.EmploymentDateT.ToListAsync();
            return Ok(date);
        }

        // GET: api/EmploymentDate/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmploymentDateT>> GetSingleEmploymentDate(int id)
        {
            var date = await _context.EmploymentDateT.FirstOrDefaultAsync(h => h.Id == id);
            if (date == null)
            {
                return NotFound("sorry");
            }
            return Ok(date);
        }

        // PUT: api/EmploymentDate/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploymentDate(int id, EmploymentDateT date)
        {
            var dbdate = await _context.EmploymentDateT
                 .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbdate == null)
                return NotFound("Sorry, but no users for you. :/");

            dbdate.Verify_Id = date.Verify_Id;

            dbdate.ProbationStartDate = date.ProbationStartDate;
            dbdate.ProbationEndDate = date.ProbationEndDate;

            dbdate.CasualStartDate = date.CasualStartDate;
            dbdate.CasualEndDate = date.CasualEndDate;
            
            dbdate.RegularizationDate = date.RegularizationDate;
            dbdate.ResignationDate = date.ResignationDate;

            dbdate.FixedStartDate = date.FixedStartDate;
            dbdate.FixedEndDate = date.FixedEndDate;

            dbdate.ProjStartDate = date.ProjStartDate;
            dbdate.ProjEndDate = date.ProjEndDate;
            dbdate.EmpmentStatusId = date.EmpmentStatusId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbEmploymentDate());

        }

        // POST: api/EmploymentDate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmploymentDateT>> PostEmploymentDate(EmploymentDateT date)
        {
            _context.EmploymentDateT.Add(date);
            await _context.SaveChangesAsync();

            return Ok(await GetDbEmploymentDate());
        }

        // DELETE: api/EmploymentDate/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploymentDate(int id)
        {
            if (_context.EmploymentDateT == null)
            {
                return NotFound();
            }
            var date = await _context.EmploymentDateT.FindAsync(id);
            if (date == null)
            {
                return NotFound();
            }

            _context.EmploymentDateT.Remove(date);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<List<EmploymentDateT>> GetDbEmploymentDate()
        {
            return await _context.EmploymentDateT.ToListAsync();
        }
    }
}
