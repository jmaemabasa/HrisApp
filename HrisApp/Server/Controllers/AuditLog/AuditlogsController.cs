using HrisApp.Shared.Models.Audit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.AuditLog
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditlogsController : ControllerBase
    {
        private readonly DataContext _context;

        public AuditlogsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetLogs")]
        public async Task<ActionResult<List<AuditlogsT>>> GetLogs()
        {
            var audit = await _context.AuditlogsT
                .Include(a => a.EmployeeUSer)
                .ToListAsync();
            return Ok(audit);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuditlogsT>> GetSingleLog(int id)
        {
            var log = await _context.AuditlogsT
               .Include(a => a.EmployeeUSer)
               .FirstOrDefaultAsync(h => h.Id == id);

            if (log == null)
            {
                return NotFound("sorry no logs here");
            }
            return Ok(log);
        }

        private async Task<List<AuditlogsT>> GetDBLogs()
        {
            return await _context.AuditlogsT
               .Include(a => a.EmployeeUSer)
               .ToListAsync();
        }

        //CREATE AND UPDATEEEE EMPLOYEEE

        [HttpPost("CreateLogs")]
        public async Task<ActionResult<List<AuditlogsT>>> CreateLogs(AuditlogsT log)
        {
            _context.AuditlogsT.Add(log);
            await _context.SaveChangesAsync();

            return Ok(await GetDBLogs());
        }
    }
}
