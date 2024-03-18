using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.EmployeeDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpEvaluationController : ControllerBase
    {
        private readonly DataContext _context;

        public EmpEvaluationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetForEvallist")]
        public async Task<ActionResult<List<Emp_EvaluationT>>> GetForEvallist([FromQuery] string verCode)
        {
            var histlist = await _context.Emp_EvaluationT
                //.Where(x => x.Verify_Id == verCode && x.Employee.DateHired != null)
                //.OrderByDescending(x => x.DateEnded)
                .ToListAsync();

            return Ok(histlist);
        }

        [HttpGet("GetForEval")]
        public async Task<ActionResult<List<Emp_EvaluationT>>> GetForEval()
        {
            var empHis = await _context.Emp_EvaluationT
                .ToListAsync();
            return Ok(empHis);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Emp_EvaluationT>> GetSingleEval(int id)
        {
            var history = await _context.Emp_EvaluationT
                .FirstOrDefaultAsync(h => h.Id == id);
            if (history == null)
            {
                return NotFound("sorry no history here");
            }
            return Ok(history);
        }

        private async Task<List<Emp_EvaluationT>> GetDBEval()
        {
            return await _context.Emp_EvaluationT
                .ToListAsync();
        }

        [HttpPost("CreateForEval")]
        public async Task<ActionResult<List<Emp_EvaluationT>>> CreateForEval(Emp_EvaluationT eval)
        {
            // Delete rows where eval status is "done"
            var evaluationsToDelete = _context.Emp_EvaluationT
                .Where(e => e.EvalStatus == "done")
                .ToList();

            _context.Emp_EvaluationT.RemoveRange(evaluationsToDelete);

            // Add the new evaluation
            _context.Emp_EvaluationT.Add(eval);

            await _context.SaveChangesAsync();

            return Ok(await GetDBEval());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Emp_EvaluationT>>> UpdateForEval(Emp_EvaluationT emphistory, int id)
        {
            var dbEmployeeHis = await _context.Emp_EvaluationT.FirstOrDefaultAsync(e => e.Id == id);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.Eval1Status = emphistory.Eval1Status;
                dbEmployeeHis.Eval2Status = emphistory.Eval2Status;
                dbEmployeeHis.Eval3Status = emphistory.Eval3Status;
                dbEmployeeHis.Eval5Status = emphistory.Eval5Status;
                dbEmployeeHis.EvalStatus = emphistory.EvalStatus;

                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBEval());
        }

        [HttpPut("UpdateFinalStatus/{VerifyId}")]
        public async Task<ActionResult<List<Emp_EvaluationT>>> UpdateFinalStatus(Emp_EvaluationT emphistory, string VerifyId)
        {
            var dbEmployeeHis = await _context.Emp_EvaluationT.FirstOrDefaultAsync(e => e.Verify_Id == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.Eval1Status = emphistory.Eval1Status;
                dbEmployeeHis.Eval2Status = emphistory.Eval2Status;
                dbEmployeeHis.Eval3Status = emphistory.Eval3Status;
                dbEmployeeHis.Eval5Status = emphistory.Eval5Status;

                if (dbEmployeeHis.Eval5Status == "Done")
                {
                    dbEmployeeHis.EvalStatus = "Done";
                }
                else
                {
                    dbEmployeeHis.EvalStatus = "Pending";
                }
                await _context.SaveChangesAsync();
            }
            return Ok(await GetDBEval());
        }
    }
}