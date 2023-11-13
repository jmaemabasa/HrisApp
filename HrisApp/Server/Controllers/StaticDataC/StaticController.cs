using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.StaticDataC
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticController : ControllerBase
    {
        private readonly DataContext _context;

        public StaticController(DataContext context)
        {
            _context = context;
        }

        //status
        [HttpGet("GetStatusList")]
        public async Task<ActionResult<List<StatusT>>> GetStatusList()
        {
            var status = await _context.StatusT
                .ToListAsync();
            return Ok(status);
        }

        //employmentstatus
        [HttpGet("GetEmploymentStatusList")]
        public async Task<ActionResult<List<EmploymentStatusT>>> GetEmploymentStatusList()
        {
            var empstatus = await _context.EmploymentStatusT
                .ToListAsync();
            return Ok(empstatus);
        }

        //emerRelationship
        [HttpGet("GetEmerRelationshipList")]
        public async Task<ActionResult<List<EmerRelationshipT>>> GetEmerRelationshipList()
        {
            var rel = await _context.EmerRelationshipT
                .ToListAsync();
            return Ok(rel);
        }

        //gender
        [HttpGet("GetGenderList")]
        public async Task<ActionResult<List<GenderT>>> GetGenderList()
        {
            var gender = await _context.GenderT
                .ToListAsync();
            return Ok(gender);
        }

        //civilstatus
        [HttpGet("GetCivilStatusList")]
        public async Task<ActionResult<List<CivilStatusT>>> GetCivilStatusList()
        {
            var cs = await _context.CivilStatusT
                .ToListAsync();
            return Ok(cs);
        }

        //regligion
        [HttpGet("GetReligionList")]
        public async Task<ActionResult<List<ReligionT>>> GetReligionList()
        {
            var rel = await _context.ReligionT
                .ToListAsync();
            return Ok(rel);
        }

        //inactivestatus
        [HttpGet("GetInactiveStatusList")]
        public async Task<ActionResult<List<InactiveStatusT>>> GetInactiveStatusList()
        {
            var ias = await _context.InactiveStatusT
                .ToListAsync();
            return Ok(ias);
        }

        //PAYROLL
        [HttpGet("ratetype")]
        public async Task<ActionResult<List<RateTypeT>>> GetRateType()
        {
            var Salary = await _context.RateTypeT.ToListAsync();
            return Ok(Salary);
        }

        [HttpGet("cashbond")]
        public async Task<ActionResult<List<CashBondT>>> GetCashbond()
        {
            var cash = await _context.CashBondT.ToListAsync();
            return Ok(cash);
        }

        [HttpGet("restday")]
        public async Task<ActionResult<List<RestDayT>>> GetRestDay()
        {
            var rest = await _context.RestDayT.ToListAsync();
            return Ok(rest);
        }
    }
}
