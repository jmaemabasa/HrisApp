using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.Payroll
{
#nullable disable
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly DataContext _context;

        public PayrollController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Payroll
        [HttpGet]
        public async Task<ActionResult<List<Emp_PayrollT>>> GetPayroll()
        {
            var payroll = await _context.Emp_PayrollT
                .Include(em => em.Cashbond)
                .Include(em => em.RateType)
                .Include(em => em.ScheduleType)
                .Include(em => em.RestDay)
                .ToListAsync();
            return Ok(payroll);
        }

        [HttpGet("GetOPayrollList")]
        public async Task<ActionResult<List<Emp_PayrollT>>> GetPayrollList()
        {
            var payroll = await _context.Emp_PayrollT
                .Include(em => em.Cashbond)
                .Include(em => em.RateType)
                .Include(em => em.ScheduleType)
                .Include(em => em.RestDay)
                 .ToListAsync();
            return Ok(payroll);
        }

        // GET: api/Payroll/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emp_PayrollT>> GetSinglePayroll(int id)
        {
            var pr = await _context.Emp_PayrollT
                .Include(em => em.Cashbond)
                .Include(em => em.RateType)
                .Include(em => em.ScheduleType)
                .Include(em => em.RestDay)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (pr == null)
            {
                return NotFound("no document here");
            }
            return Ok(pr);
        }

        // PUT: api/Others/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Emp_PayrollT>> UpdatePayroll(int id, Emp_PayrollT payroll)
        {
            var dbPayroll = await _context.Emp_PayrollT
                 .FirstOrDefaultAsync(sh => sh.Id == id);

            dbPayroll.Salary = payroll.Salary;
            dbPayroll.BankAcc = payroll.BankAcc;
            dbPayroll.Verify_Id = payroll.Verify_Id;
            dbPayroll.TINNum = payroll.TINNum;
            dbPayroll.SSSNum = payroll.SSSNum;
            dbPayroll.PhilHealthNum = payroll.PhilHealthNum;
            dbPayroll.HDMFNum = payroll.HDMFNum;
            dbPayroll.BiometricID = payroll.HDMFNum;
            dbPayroll.RestDayId = payroll.RestDayId;
            dbPayroll.ScheduleTypeId = payroll.ScheduleTypeId;
            dbPayroll.Paytype = payroll.Paytype;
            dbPayroll.Rate = payroll.Rate;
            dbPayroll.RateTypeId = payroll.RateTypeId;
            dbPayroll.MealAllowance = payroll.MealAllowance;
            dbPayroll.CashbondId = payroll.CashbondId;

            await _context.SaveChangesAsync();

            return Ok(await GetDBPayroll());
        }

        // POST: api/Others
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<Emp_PayrollT>>> CreatePayroll(Emp_PayrollT pr)
        {
            pr.Cashbond = null;
            pr.RestDay = null;
            pr.RateType = null;
            pr.ScheduleType = null;
            _context.Emp_PayrollT.Add(pr);
            await _context.SaveChangesAsync();

            return Ok(await GetDBPayroll());
        }

        // DELETE: api/Others/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayroll(int id)
        {
            if (_context.Emp_PayrollT == null)
            {
                return NotFound();
            }
            var pr = await _context.Emp_PayrollT.FindAsync(id);
            if (pr == null)
            {
                return NotFound();
            }

            _context.Emp_PayrollT.Remove(pr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OthersExists(int id)
        {
            return (_context.Emp_PayrollT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<Emp_PayrollT>> GetDBPayroll()
        {
            return await _context.Emp_PayrollT
                .Include(em => em.Cashbond)
                .Include(em => em.RateType)
                .Include(em => em.ScheduleType)
                .Include(em => em.RestDay)
                .ToListAsync();
        }

        //FK

        [HttpGet("scheduletype")]
        public async Task<ActionResult<List<ScheduleTypeT>>> GetScheduleType()
        {
            var sched = await _context.ScheduleTypeT.ToListAsync();
            return Ok(sched);
        }
    }
}
