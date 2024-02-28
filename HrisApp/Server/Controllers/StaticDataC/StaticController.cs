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

        [HttpGet("GetStatusId/{name}")]
        public async Task<ActionResult<int>> GetStatusId(string name)
        {
            var Masterlist = await _context.StatusT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        //employmentstatus
        [HttpGet("GetEmploymentStatusList")]
        public async Task<ActionResult<List<EmploymentStatusT>>> GetEmploymentStatusList()
        {
            var empstatus = await _context.EmploymentStatusT
                .ToListAsync();
            return Ok(empstatus);
        }

        [HttpGet("GetEmploymentStatusId/{name}")]
        public async Task<ActionResult<int>> GetEmploymentStatusId(string name)
        {
            var Masterlist = await _context.EmploymentStatusT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        //emerRelationship
        [HttpGet("GetEmerRelationshipList")]
        public async Task<ActionResult<List<EmerRelationshipT>>> GetEmerRelationshipList()
        {
            var rel = await _context.EmerRelationshipT
                .ToListAsync();
            return Ok(rel);
        }

        [HttpGet("GetEmerRelationshipId/{name}")]
        public async Task<ActionResult<int>> GetEmerRelationshipId(string name)
        {
            var Masterlist = await _context.EmerRelationshipT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        //gender
        [HttpGet("GetGenderList")]
        public async Task<ActionResult<List<GenderT>>> GetGenderList()
        {
            var gender = await _context.GenderT
                .ToListAsync();
            return Ok(gender);
        }

        [HttpGet("GetGenderId/{name}")]
        public async Task<ActionResult<int>> GetGenderId(string name)
        {
            var Masterlist = await _context.GenderT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        //civilstatus
        [HttpGet("GetCivilStatusList")]
        public async Task<ActionResult<List<CivilStatusT>>> GetCivilStatusList()
        {
            var cs = await _context.CivilStatusT
                .ToListAsync();
            return Ok(cs);
        }

        [HttpGet("GetCivilStatusId/{name}")]
        public async Task<ActionResult<int>> GetCivilStatusId(string name)
        {
            var Masterlist = await _context.CivilStatusT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        //regligion
        [HttpGet("GetReligionList")]
        public async Task<ActionResult<List<ReligionT>>> GetReligionList()
        {
            var rel = await _context.ReligionT
                .ToListAsync();
            return Ok(rel);
        }

        [HttpGet("GetReligionId/{name}")]
        public async Task<ActionResult<int>> GetReligionId(string name)
        {
            var Masterlist = await _context.ReligionT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
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

        [HttpGet("GetRateTypeId/{name}")]
        public async Task<ActionResult<int>> GetRateTypeId(string name)
        {
            var Masterlist = await _context.RateTypeT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        [HttpGet("cashbond")]
        public async Task<ActionResult<List<CashBondT>>> GetCashbond()
        {
            var cash = await _context.CashBondT.ToListAsync();
            return Ok(cash);
        }

        [HttpGet("GetCashbondId/{name}")]
        public async Task<ActionResult<int>> GetCashbondId(string name)
        {
            var Masterlist = await _context.CashBondT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        [HttpGet("restday")]
        public async Task<ActionResult<List<RestDayT>>> GetRestDay()
        {
            var rest = await _context.RestDayT.ToListAsync();
            return Ok(rest);
        }

        [HttpGet("assetstatus")]
        public async Task<ActionResult<List<RestDayT>>> GetAssetStatus()
        {
            var rest = await _context.AssetStatusT.ToListAsync();
            return Ok(rest);
        }
    }
}