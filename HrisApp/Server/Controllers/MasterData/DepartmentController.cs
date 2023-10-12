using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.MasterData
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DataContext _context;

        public DepartmentController(DataContext context)
        {
            _context = context;
        }

        //GEEEEEEEEEEET
        [HttpGet("DeptByDivision/{divisionId}")]
        public async Task<ActionResult<List<DepartmentT>>> GetDeptByDivision(int divisionId)
        {
            var dept = await _context.DepartmentT
                .Where(dept => dept.DivisionId == divisionId)
                .ToListAsync();
            return Ok(dept);
        }

        [HttpGet]
        public async Task<ActionResult<List<DepartmentT>>> GetDepartmentList()
        {
            var departments = await _context.DepartmentT
                .ToListAsync();
            return Ok(departments);
        }

        [HttpGet("GetDepartment")]
        public async Task<ActionResult<List<DepartmentT>>> GetDepartment()
        {
            var dept = await _context.DepartmentT
                .Include(d => d.Division)
                .OrderBy(d => d.Division.Name)
                .ToListAsync();
            return Ok(dept);
        }

        private async Task<List<DepartmentT>> GetDBDepartment()
        {
            return await _context.DepartmentT
                .ToListAsync();
        }

        //CREATE AND UPDATEEEE

        [HttpPost("CreateDepartment")]
        public async Task<ActionResult<DepartmentT>> CreateDepartment(DepartmentT dept)
        {
            _context.DepartmentT.Add(dept);
            await _context.SaveChangesAsync();

            return Ok(await GetDBDepartment());
        }

        [HttpPut("UpdateDepartment")]
        public async Task<ActionResult> UpdateDepartment(DepartmentT dept)
        {
            var dbdep = await _context.DepartmentT.FirstOrDefaultAsync(d =>  d.Id == dept.Id);

            dbdep.Name = dept.Name;

            await _context.SaveChangesAsync();

            return Ok(await GetDBDepartment());
        }


    }
}
