using HrisApp.Shared.Models.Payroll;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.Payroll
{
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
        public async Task<ActionResult<List<PayrollT>>> GetPayroll()
        {
            var payroll = await _context.PayrollT
                .Include(em => em.Cashbond)
                .Include(em => em.RateType)
                .Include(em => em.ScheduleType)
                 .ToListAsync();
            return Ok(payroll);
        }

        [HttpGet("GetOPayrollList")]
        public async Task<ActionResult<List<PayrollT>>> GetPayrollList()
        {
            var payroll = await _context.PayrollT
                .Include(em => em.Cashbond)
                .Include(em => em.RateType)
                .Include(em => em.ScheduleType)
                 .ToListAsync();
            return Ok(payroll);
        }

        // GET: api/Payroll/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PayrollT>> GetSinglePayroll(int id)
        {
            var pr = await _context.PayrollT
                .Include(em => em.Cashbond)
                .Include(em => em.RateType)
                .Include(em => em.ScheduleType)
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
        public async Task<ActionResult<PayrollT>> UpdatePayroll(int id, PayrollT payroll)
        {
            var dbPayroll = await _context.PayrollT
                 .FirstOrDefaultAsync(sh => sh.Id == id);

            dbPayroll.Salary = payroll.Salary;
            dbPayroll.BankAcc = payroll.BankAcc;
            dbPayroll.Verify_Id = payroll.Verify_Id;
            dbPayroll.TINNum = payroll.TINNum;
            dbPayroll.SSSNum = payroll.SSSNum;
            dbPayroll.PhilHealthNum = payroll.PhilHealthNum;
            dbPayroll.HDMFNum = payroll.HDMFNum;
            dbPayroll.BiometricID = payroll.HDMFNum;
            dbPayroll.Restday = payroll.Restday;
            dbPayroll.ScheduleType = payroll.ScheduleType;
            dbPayroll.ScheduleTypeId = payroll.ScheduleTypeId;
            dbPayroll.Paytype = payroll.Paytype;
            dbPayroll.Rate = payroll.Rate;
            dbPayroll.RateTypeId = payroll.RateTypeId;
            dbPayroll.MealAllowance = payroll.MealAllowance;
            dbPayroll.Cashbond = payroll.Cashbond;

            await _context.SaveChangesAsync();

            return Ok(await GetDBPayroll());
        }

        // POST: api/Others
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<PayrollT>>> CreatePayroll(PayrollT pr)
        {
            pr.Cashbond = null;
            _context.PayrollT.Add(pr);
            await _context.SaveChangesAsync();

            return Ok(await GetDBPayroll());
        }

        // DELETE: api/Others/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayroll(int id)
        {
            if (_context.PayrollT == null)
            {
                return NotFound();
            }
            var pr = await _context.PayrollT.FindAsync(id);
            if (pr == null)
            {
                return NotFound();
            }

            _context.PayrollT.Remove(pr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OthersExists(int id)
        {
            return (_context.PayrollT?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private async Task<List<PayrollT>> GetDBPayroll()
        {
            return await _context.PayrollT
                .Include(em => em.Cashbond)
                .Include(em => em.RateType)
                .Include(em => em.ScheduleType)
                .ToListAsync();
        }

        //FK
        [HttpGet("ratetype")]
        public async Task<ActionResult<List<RateTypeT>>> GetRateType()
        {
            var Salary = await _context.RateTypeT.ToListAsync();
            return Ok(Salary);
        }

        [HttpGet("cashbond")]
        public async Task<ActionResult<List<CashBondT>>> GetCashbond()
        {
            var cash = await _context.CashBondT.ToListAsync();
            return Ok(cash);
        }

        [HttpGet("scheduletype")]
        public async Task<ActionResult<List<ScheduleTypeT>>> GetScheduleType()
        {
            var sched = await _context.ScheduleTypeT.ToListAsync();
            return Ok(sched);
        }
    }
}
