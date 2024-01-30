using HrisApp.Shared.Models.Attendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.Attendance
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceRecController : ControllerBase
    {
        private readonly DataContext _context;

        public AttendanceRecController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AttendanceRecordT>>> GetAttendanceRecordList()
        {
            var obj = await _context.AttendanceRecordT
                .OrderByDescending(x => x.Time)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetAttendanceRecord")]
        public async Task<ActionResult<List<AttendanceRecordT>>> GetAttendanceRecord()
        {
            var obj = await _context.AttendanceRecordT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AttendanceRecordT>> GetSingleAttendanceRecord(int id)
        {
            var area = await _context.AttendanceRecordT.FirstOrDefaultAsync(h => h.Id == id);

            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        private async Task<List<AttendanceRecordT>> GetDBAttendanceRecord()
        {
            return await _context.AttendanceRecordT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateAttendanceRecord")]
        public async Task<ActionResult<AttendanceRecordT>> CreateAttendanceRecord(AttendanceRecordT obj)
        {
            _context.AttendanceRecordT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(await GetDBAttendanceRecord());
        }


        [HttpGet("GetExistingObj")]
        public async Task<ActionResult<int>> GetExistingObj([FromQuery] string time, [FromQuery] string no, [FromQuery] string state)
        {
            var obj = await _context.AttendanceRecordT.ToListAsync();
            var poslist = obj.Where(h => h.AC_No == no && h.Time?.ToString("MM/dd/yyyy") == time && h.State == state).ToList();

            if (poslist == null)
            {
                return 0;
            }
            else
            {
                return poslist.Count();
            }
        }
    }
}
