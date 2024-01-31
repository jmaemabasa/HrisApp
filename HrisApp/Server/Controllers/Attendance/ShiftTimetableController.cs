using HrisApp.Shared.Models.Attendance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.Attendance
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftTimetableController : ControllerBase
    {
        private readonly DataContext _context;

        public ShiftTimetableController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<ShiftTimetableT>>> GetTimetableList()
        {
            var obj = await _context.ShiftTimetableT
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetTimetable")]
        public async Task<ActionResult<List<ShiftTimetableT>>> GetTimetable()
        {
            var obj = await _context.ShiftTimetableT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShiftTimetableT>> GetSingleTimetable(int id)
        {
            var area = await _context.ShiftTimetableT.FirstOrDefaultAsync(h => h.Id == id);

            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        private async Task<List<ShiftTimetableT>> GetDBTimetable()
        {
            return await _context.ShiftTimetableT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateTimetable")]
        public async Task<ActionResult<ShiftTimetableT>> CreateTimetable(ShiftTimetableT obj)
        {
            _context.ShiftTimetableT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(await GetDBTimetable());
        }

        [HttpPut("UpdateTimetable")]
        public async Task<ActionResult> UpdateLeave(ShiftTimetableT obj)
        {
            var dbobj = await _context.ShiftTimetableT.FirstOrDefaultAsync(d => d.Id == obj.Id);

            dbobj.Timetable_Name = obj.Timetable_Name;
            dbobj.OnDuty_Time = obj.OnDuty_Time;
            dbobj.OffDuty_Time = obj.OffDuty_Time;
            dbobj.Begin_C_In = obj.Begin_C_In;
            dbobj.Ending_C_In = obj.Ending_C_In;
            dbobj.Begin_C_Out = obj.Begin_C_Out;
            dbobj.Ending_C_Out = obj.Ending_C_Out;
            dbobj.Workday_Count = obj.Workday_Count;
            dbobj.Minute_Count = obj.Minute_Count;
            dbobj.Late_Time = obj.Late_Time;
            dbobj.LeaveEarly_Time = obj.LeaveEarly_Time;
            dbobj.Must_C_In = obj.Must_C_In;
            dbobj.Must_C_Out = obj.Must_C_Out;

            await _context.SaveChangesAsync();

            return Ok(await GetDBTimetable());
        }
    }
}
