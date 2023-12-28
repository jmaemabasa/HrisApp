using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.Attendance
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveCreditController : ControllerBase
    {
        private readonly DataContext _context;

        public LeaveCreditController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<Emp_LeaveCreditT>>> GetLeaveCreditList()
        {
            var obj = await _context.Emp_LeaveCreditT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetLeaveCredit")]
        public async Task<ActionResult<List<Emp_LeaveCreditT>>> GetLeaveCredit()
        {
            var obj = await _context.Emp_LeaveCreditT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Emp_LeaveCreditT>> GetSingleLeaveCredit(int id)
        {
            var area = await _context.Emp_LeaveCreditT.FirstOrDefaultAsync(h => h.Id == id);

            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        [HttpGet("GetSingleLeaveCreditByVerId/{verid}")]
        public async Task<ActionResult<Emp_LeaveCreditT>> GetSingleLeaveCreditByVerId(string verid)
        {
            var area = await _context.Emp_LeaveCreditT.FirstOrDefaultAsync(h => h.Verify_Id == verid);

            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        private async Task<List<Emp_LeaveCreditT>> GetDBLeaveCredit()
        {
            return await _context.Emp_LeaveCreditT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateLeaveCredit")]
        public async Task<ActionResult<Emp_LeaveCreditT>> CreateLeaveCredit(Emp_LeaveCreditT obj)
        {
            _context.Emp_LeaveCreditT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(await GetDBLeaveCredit());
        }

        [HttpPut("UpdateLeaveCredit")]
        public async Task<ActionResult> UpdateLeaveCredit(Emp_LeaveCreditT obj)
        {
            var dbobj = await _context.Emp_LeaveCreditT.FirstOrDefaultAsync(d => d.Id == obj.Id);

            dbobj.EL = obj.EL;
            dbobj.ML = obj.ML;
            dbobj.PL = obj.PL;
            dbobj.SL = obj.SL;
            dbobj.VL = obj.VL;
            dbobj.OL = obj.OL;
            await _context.SaveChangesAsync();

            return Ok(await GetDBLeaveCredit());
        }
    }
}
