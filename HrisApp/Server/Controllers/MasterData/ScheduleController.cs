using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MasterData
{
#nullable disable
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly DataContext _context;

        public ScheduleController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<ScheduleTypeT>>> GetScheduleList()
        {
            var sched = await _context.ScheduleTypeT.ToListAsync();
            return Ok(sched);
        }

        [HttpGet("GetSchedule")]
        public async Task<ActionResult<List<ScheduleTypeT>>> GetSchedule()
        {
            var sched = await _context.ScheduleTypeT.ToListAsync();
            return Ok(sched);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleTypeT>> GetSingleSchedule(int id)
        {
            var sched = await _context.ScheduleTypeT.FirstOrDefaultAsync(h => h.Id == id);

            if (sched == null)
            {
                return NotFound();
            }
            return Ok(sched);
        }

        private async Task<List<ScheduleTypeT>> GetDBSchedule()
        {
            return await _context.ScheduleTypeT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateSchedule")]
        public async Task<ActionResult<ScheduleTypeT>> CreateSchedule(ScheduleTypeT sched)
        {
            _context.ScheduleTypeT.Add(sched);
            await _context.SaveChangesAsync();

            return Ok(await GetDBSchedule());
        }

        [HttpPut("UpdateSchedule")]
        public async Task<ActionResult> UpdateSchedule(ScheduleTypeT sched)
        {
            var dbsched = await _context.ScheduleTypeT.FirstOrDefaultAsync(d => d.Id == sched.Id);
            dbsched.Name = sched.Name;
            dbsched.TimeIn = DateTime.Parse(sched.TimeIn).ToString(@"hh\:mm tt");
            dbsched.TimeOut = DateTime.Parse(sched.TimeOut).ToString(@"hh\:mm tt");
            await _context.SaveChangesAsync();

            return Ok(await GetDBSchedule());
        }
    }
}
