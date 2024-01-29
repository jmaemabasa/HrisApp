using HrisApp.Shared.Models.Announcement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.Announcement
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly DataContext _context;

        public AnnouncementController(DataContext context)
        {
            _context = context;
        }

        //GEEEEEEEEEEET
        [HttpGet]
        public async Task<ActionResult<List<AnnouncementT>>> GetAnnouncementList()
        {
            var obj = await _context.AnnouncementT
                .OrderByDescending(x => x.DateStart)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetFilteredAnnouncement")]
        public async Task<ActionResult<List<AnnouncementT>>> GetFilteredAnnouncement()
        {
            var obj = await _context.AnnouncementT
                .OrderByDescending(t => t.DateStart)
                .Where(d => (d.DateStart.Value.Date == DateTime.Now.Date && d.DateEnd.Value.Date >= DateTime.Now.Date)
                         || (d.DateStart.Value.Date <= DateTime.Now.Date && d.DateEnd.Value.Date >= DateTime.Now.Date))
                .ToListAsync();
            return Ok(obj);
        }


        [HttpGet("GetAnnouncement")]
        public async Task<ActionResult<List<AnnouncementT>>> GetAnnouncement()
        {
            var obj = await _context.AnnouncementT
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AnnouncementT>> GetSingleAnnouncement(int id)
        {
            var obj = await _context.AnnouncementT.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        private async Task<List<AnnouncementT>> GetDBAnnouncement()
        {
            return await _context.AnnouncementT
                .ToListAsync();
        }

        //CREATE AND UPDATEEEE

        [HttpPost("CreateAnnouncement")]
        public async Task<ActionResult<AnnouncementT>> CreateAnnouncement(AnnouncementT obj)
        {
            _context.AnnouncementT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(await GetDBAnnouncement());
        }

        [HttpPut("UpdateAnnouncement")]
        public async Task<ActionResult> UpdateAnnouncement(AnnouncementT obj)
        {
            var dbdep = await _context.AnnouncementT.FirstOrDefaultAsync(d => d.Id == obj.Id);

            dbdep.Ann_Title = obj.Ann_Title;
            dbdep.Ann_Desc = obj.Ann_Desc;
            dbdep.Status = obj.Status;
            dbdep.DateStart = obj.DateStart;
            dbdep.DateEnd = obj.DateEnd;

            await _context.SaveChangesAsync();

            return Ok(await GetDBAnnouncement());
        }


        [HttpGet("AnnouncementCount")]
        public async Task<ActionResult<int>> GetAnnouncementCount()
        {
            var Masterlist = await _context.AnnouncementT
                .ToListAsync();

            var returnCount = Masterlist.Count();
            return Ok(returnCount);
        }
    }
}
