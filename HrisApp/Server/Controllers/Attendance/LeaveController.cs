using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.Attendance
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveController : ControllerBase
    {
        private readonly DataContext _context;

        public LeaveController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<LeaveTypesT>>> GetLeaveList()
        {
            var obj = await _context.LeaveTypesT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetLeave")]
        public async Task<ActionResult<List<LeaveTypesT>>> GetLeave()
        {
            var obj = await _context.LeaveTypesT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypesT>> GetSingleLeave(int id)
        {
            var area = await _context.LeaveTypesT.FirstOrDefaultAsync(h => h.Id == id);

            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        private async Task<List<LeaveTypesT>> GetDBLeave()
        {
            return await _context.LeaveTypesT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateLeave")]
        public async Task<ActionResult<LeaveTypesT>> CreateLeave(LeaveTypesT obj)
        {
            _context.LeaveTypesT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(await GetDBLeave());
        }

        [HttpPut("UpdateLeave")]
        public async Task<ActionResult> UpdateLeave(LeaveTypesT obj)
        {
            var dbobj = await _context.LeaveTypesT.FirstOrDefaultAsync(d => d.Id == obj.Id);

            dbobj.Name = obj.Name;
            dbobj.Unit = obj.Unit;
            await _context.SaveChangesAsync();

            return Ok(await GetDBLeave());
        }
    }
}
