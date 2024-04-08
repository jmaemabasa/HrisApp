namespace HrisApp.Server.Controllers.EmployeeDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpRateHistoryController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpRateHistoryController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllHistory")]
        public async Task<ActionResult<List<Emp_RateHistoryT>>> GetAllHistory()
        {
            var empHis = await _context.Emp_RateHistoryT
                .Include(e => e.Employee)
                .ToListAsync();
            return Ok(empHis);
        }

        [HttpGet("GetHistoryList")]
        public async Task<ActionResult<List<Emp_RateHistoryT>>> GetHistoryList([FromQuery] int empid)
        {
            var objlist = await _context.Emp_RateHistoryT
                .Where(x => x.EmployeeId == empid && x.EffEndDate != null)
                .Include(e => e.Employee)
                .OrderByDescending(x => x.DateEnded)
                .ToListAsync();

            return Ok(objlist);
        }


        [HttpGet("GetLastHistory")]
        public async Task<ActionResult<Emp_RateHistoryT>> GetLastHistory([FromQuery] int empid)
        {
            var history = await _context.Emp_RateHistoryT
                .Where(x => x.EmployeeId == empid)
                .Include(e => e.Employee)
                .OrderByDescending(e => e.DateStarted)
                .FirstOrDefaultAsync();

            if (history == null)
            {
                return NotFound("No employment history found for the specified verification code.");
            }

            return Ok(history);
        }

        [HttpGet("GetLastHistoryWithoutDateEnded")]
        public async Task<ActionResult<Emp_RateHistoryT>> GetLastHistoryWithoutDateEnded([FromQuery] int empid)
        {
            var history = await _context.Emp_RateHistoryT
                .Where(x => x.EmployeeId == empid && x.EffEndDate == null)
                .Include(e => e.Employee)
                .OrderByDescending(e => e.DateStarted)
                .FirstOrDefaultAsync();

            if (history == null)
            {
                return NotFound("No history found for the specified id.");
            }

            return Ok(history);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Emp_RateHistoryT>> GetSingleHistory(int id)
        {
            var history = await _context.Emp_RateHistoryT
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (history == null)
            {
                return NotFound("sorry no history here");
            }
            return Ok(history);
        }

        [HttpGet("GetSingleLastHistory/{id}")]
        public async Task<ActionResult<Emp_RateHistoryT>> GetSingleLastHistory(int id)
        {
            var history = await _context.Emp_RateHistoryT
                .Include(e => e.Employee)
                .OrderByDescending(s => s.Id)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (history == null)
            {
                return NotFound("sorry no history here");
            }
            return Ok(history);
        }

        private async Task<List<Emp_RateHistoryT>> GetDBHistory()
        {
            return await _context.Emp_RateHistoryT
                .Include(e => e.Employee)
                .ToListAsync();
        }

        [HttpPost("CreateHistory")]
        public async Task<ActionResult<List<Emp_RateHistoryT>>> CreateHistory(Emp_RateHistoryT history)
        {
            _context.Emp_RateHistoryT.Add(history);
            await _context.SaveChangesAsync();

            return Ok(await GetDBHistory());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Emp_RateHistoryT>>> UpdateHistory(Emp_RateHistoryT emphistory, int id)
        {
            var dbEmployeeHis = await _context.Emp_RateHistoryT.FirstOrDefaultAsync(e => e.Id == emphistory.Id);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.DateModified = emphistory.DateModified;
                dbEmployeeHis.DateEnded = emphistory.DateEnded;
                dbEmployeeHis.EffEndDate = emphistory.EffEndDate;

                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBHistory());
        }

        [HttpDelete("DeleteHistory")]
        public async Task<ActionResult<List<Emp_RateHistoryT>>> DeleteHistory([FromQuery] int id)
        {
            var obj = await _context.Emp_RateHistoryT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (obj == null)
                return NotFound("Sorry, but no history");

            _context.Emp_RateHistoryT.Remove(obj);

            await _context.SaveChangesAsync();

            return Ok(obj);
        }


    }
}
