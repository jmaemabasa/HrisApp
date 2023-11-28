using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EmployeeDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpHistoryController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpHistoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetEmpHistorylist")]
        public async Task<ActionResult<List<Emp_PosHistoryT>>> GetEmpHistorylist([FromQuery] string verCode)
        {
            var histlist = await _context.Emp_PosHistoryT
                .Where(x => x.Verify_Id == verCode && x.DateEnded != null)
                .OrderByDescending(x => x.DateEnded)
                .ToListAsync();

            return Ok(histlist);
        }

        [HttpGet("GetEmpLastHistory")]
        public async Task<ActionResult<Emp_PosHistoryT>> GetEmpLastHistory([FromQuery] string verCode)
        {
            var history = await _context.Emp_PosHistoryT
                .Where(x => x.Verify_Id == verCode)
                .OrderByDescending(e => e.Id)
                .FirstOrDefaultAsync();

            if (history == null)
            {
                return NotFound("No employment history found for the specified verification code.");
            }

            return Ok(history);
        }

        [HttpGet("GetEmpHistory")]
        public async Task<ActionResult<List<Emp_PosHistoryT>>> GetEmpHistory()
        {
            var empHis = await _context.Emp_PosHistoryT
                .ToListAsync();
            return Ok(empHis);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Emp_PosHistoryT>> GetSingleEmpHistory(int id)
        {
            var history = await _context.Emp_PosHistoryT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (history == null)
            {
                return NotFound("sorry no history here");
            }
            return Ok(history);
        }

        [HttpGet("GetSingleLastEmpHistory/{id}")]
        public async Task<ActionResult<Emp_PosHistoryT>> GetSingleLastEmpHistory(int id)
        {
            var history = await _context.Emp_PosHistoryT
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (history == null)
            {
                return NotFound("sorry no history here");
            }
            return Ok(history);
        }

        private async Task<List<Emp_PosHistoryT>> GetDBEmpHistory()
        {
            return await _context.Emp_PosHistoryT
                .ToListAsync();
        }

        [HttpPost("CreateEmpHistory")]
        public async Task<ActionResult<List<Emp_PosHistoryT>>> CreateEmpHistory(Emp_PosHistoryT history)
        {
            _context.Emp_PosHistoryT.Add(history);
            await _context.SaveChangesAsync();

            return Ok(await GetDBEmpHistory());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Emp_PosHistoryT>>> UpdateEmpHistory(Emp_PosHistoryT emphistory, int id)
        {
            var dbEmployeeHis = await _context.Emp_PosHistoryT.FirstOrDefaultAsync(e => e.Id == emphistory.Id);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.DateModified = emphistory.DateModified;
                dbEmployeeHis.DateEnded = emphistory.DateEnded;

                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBEmpHistory());
        }
    }
}
