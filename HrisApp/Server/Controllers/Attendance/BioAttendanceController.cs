using HrisApp.Shared.Models.Attendance;
using NPOI.OpenXmlFormats.Wordprocessing;

namespace HrisApp.Server.Controllers.Attendance
{
    [Route("api/[controller]")]
    [ApiController]
    public class BioAttendanceController : ControllerBase
    {
        private readonly DataContext _context;

        public BioAttendanceController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<BioModelT>>> GetAttendanceRecordList()
        {
            var obj = await _context.BioModelT
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetAttendanceRecord")]
        public async Task<ActionResult<List<BioModelT>>> GetAttendanceRecord()
        {
            var obj = await _context.BioModelT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BioModelT>> GetSingleAttendanceRecord(int id)
        {
            var area = await _context.BioModelT.FirstOrDefaultAsync(h => h.Id == id);

            if (area == null)
            {
                return NotFound();
            }
            return Ok(area);
        }

        private async Task<List<BioModelT>> GetDBAttendanceRecord()
        {
            return await _context.BioModelT.ToListAsync();
        }

        //CREATE
        //[HttpPost("CreateAttendanceRecord")]
        //public async Task<ActionResult<BioModelT>> CreateAttendanceRecord(BioModelT obj)
        //{

        //    _context.BioModelT.Add(obj);
        //    await _context.SaveChangesAsync();
        //    return Ok(await GetDBAttendanceRecord());
        //}

        [HttpPost("CreateAttendanceRecord")]
        public async Task<ActionResult<BioModelT>> CreateAttendanceRecord(BioModelT obj)
        {

            var _getexistdata = await _context.BioModelT.Where(a => a.DateOnlyRecord.Date == obj.DateOnlyRecord.Date).ToListAsync();
            var _getcountexist = _getexistdata.Where(b => b.TimeOnlyRecord.ToString("hh:mm tt") == obj.TimeOnlyRecord.ToString("hh:mm tt")).Count();
            if (_getcountexist == 0)
            {
                _context.BioModelT.Add(obj);
                await _context.SaveChangesAsync();
                return Ok(await GetDBAttendanceRecord());
            }
            else
            {
                return null!;
            }

        }

        [HttpGet("GetExistingObj")]
        public async Task<ActionResult<int>> GetExistingObj([FromQuery] string time, [FromQuery] string no)
        {
            var obj = await _context.BioModelT.ToListAsync();
            var poslist = obj.Where(h => h.IndRegID.ToString() == no && h.DateTimeRecord == time).ToList();

            if (poslist == null)
            {
                return 0;
            }
            else
            {
                return poslist.Count();
            }
        }


        [HttpGet("GetRecordByDate")]
        public async Task<ActionResult<List<BioModelT>>> GetRecordByDate()
        {
            var _todayDate = DateTime.Now.Date;
            var obj = await _context.BioModelT.ToListAsync();
            var _returnList = obj.Where(a => a.DateOnlyRecord.Date == _todayDate.Date).ToList();
            return Ok(_returnList);
        } 


        [HttpGet("GetEmployeeAttendance")]
        public async Task<ActionResult<List<BioModelT>>> GetEmployeeAttendance([FromQuery] int bioid)
        {
            var obj = await _context.BioModelT.ToListAsync();
            var _returnList = obj.Where(a => a.IndRegID == bioid).ToList();
            return Ok(_returnList);
        } 
    }
}
