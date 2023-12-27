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
    }
}
