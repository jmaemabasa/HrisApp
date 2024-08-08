using HrisApp.Shared.Models.Audit;
using HrisApp.Shared.Models.SettingsM;
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

        [HttpGet("CleanLogs")]
        public async Task<ActionResult<string>> CleanLogs()
        {
            try
            {
                var threeMonthsAgo = DateTime.Now.AddMonths(-3);

                // Retrieve logs older than three months
                var oldLogs = await _context.AuditlogsT
                                            .Where(log => log.Date < threeMonthsAgo)
                                            .ToListAsync();

                if (oldLogs.Count == 0)
                {
                    return Ok("NoLogs");
                }

                foreach (var item in oldLogs)
                {
                    AuditLogsArchiveT archive = new()
                    {
                        Id = 0,
                        EmployeeUserId = item.EmployeeUserId,
                        Action = item.Action,
                        Type = item.Type,
                        Date = item.Date,
                    };

                    // Insert old logs into ExtractLogsModelArchive
                    _context.AuditLogsArchiveT.Add(archive);

                    // remove old logs from ExtractLogsModel
                    _context.AuditlogsT.Remove(item);

                    // Save changes to both contexts
                    await _context.SaveChangesAsync();
                }

                return Ok("Success");
            }
            catch (Exception)
            {
                // Log the exception if needed
                return Ok("Error");
            }
        }
    }
}
