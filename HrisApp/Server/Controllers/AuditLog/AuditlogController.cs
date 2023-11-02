using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrisApp.Server.Controllers.AuditLog
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditlogController : ControllerBase
    {
        private readonly DataContext _context;

        public AuditlogController(DataContext context)
        {
            _context = context;
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateAudit")]
        public async Task<ActionResult<AuditLogT>> CreateAudit(AuditLogT audit)
        {
            _context.AuditLogT.Add(audit);
            await _context.SaveChangesAsync();

            return Ok(await GetDBAudit());
        }

        private async Task<List<AuditLogT>> GetDBAudit()
        {
            return await _context.AuditLogT.ToListAsync();
        }
    }
}
