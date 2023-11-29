//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace HrisApp.Server.Controllers.EmployeeDetails
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EmpEvaluationController : ControllerBase
//    {

//        private readonly DataContext _context;

//        public EmpEvaluationController(DataContext context)
//        {
//            _context = context;
//        }

//        [HttpGet("GetForEvallist")]
//        public async Task<ActionResult<List<EmployeeEvaluationT>>> GetForEvallist([FromQuery] string verCode)
//        {
//            var histlist = await _context.EmployeeEvaluationT
//                //.Where(x => x.Verify_Id == verCode && x.Employee.DateHired != null)
//                //.OrderByDescending(x => x.DateEnded)
//                .ToListAsync();

//            return Ok(histlist);
//        }

//        [HttpGet("GetForEval")]
//        public async Task<ActionResult<List<EmployeeEvaluationT>>> GetForEval()
//        {
//            var empHis = await _context.EmployeeEvaluationT
//                .ToListAsync();
//            return Ok(empHis);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<EmployeeEvaluationT>> GetSingleEval(int id)
//        {
//            var history = await _context.EmployeeEvaluationT
//                .FirstOrDefaultAsync(h => h.Id == id);
//            if (history == null)
//            {
//                return NotFound("sorry no history here");
//            }
//            return Ok(history);
//        }

//        private async Task<List<EmployeeEvaluationT>> GetDBEval()
//        {
//            return await _context.EmployeeEvaluationT
//                .ToListAsync();
//        }

//        [HttpPost("CreateForEval")]
//        public async Task<ActionResult<List<EmployeeEvaluationT>>> CreateForEval(EmployeeEvaluationT eval)
//        {
//            _context.EmployeeEvaluationT.Add(eval);
//            await _context.SaveChangesAsync();

//            return Ok(await GetDBEval());
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult<List<EmployeeEvaluationT>>> UpdateForEval(EmployeeEvaluationT emphistory, int id)
//        {
//            var dbEmployeeHis = await _context.EmployeeEvaluationT.FirstOrDefaultAsync(e => e.Id == emphistory.Id);

//            if (dbEmployeeHis != null)
//            {
//                dbEmployeeHis.EvalStatus = emphistory.EvalStatus;

//                await _context.SaveChangesAsync();
//            }
//            return Ok(await GetDBEval());
//        }
//    }
//}
