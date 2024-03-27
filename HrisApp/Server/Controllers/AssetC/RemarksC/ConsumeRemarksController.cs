using HrisApp.Shared.Models.Assets.Consumables;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.AssetC.RemarksC
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumeRemarksController : ControllerBase
    {
        private readonly DataContext _context;

        public ConsumeRemarksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetObjList")]
        public async Task<ActionResult<List<ConsumableRemarksT>>> GetObjList([FromQuery] string code)
        {
            var collegelist = await _context.ConsumableRemarksT
                .Where(x => x.ConsumableCode == code)
                .ToListAsync();

            return Ok(collegelist);
        }


        [HttpPost("CreateObj")]
        public async Task<ActionResult<ConsumableRemarksT>> CreateObj([FromBody] ConsumableRemarksT obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }

            _context.ConsumableRemarksT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }

        [HttpPut("UpdateObj/{VerifyId}")]
        public async Task<ActionResult<List<ConsumableRemarksT>>> UpdateObj(ConsumableRemarksT remarks, string VerifyId)
        {
            var dbEmployeeHis = await _context.ConsumableRemarksT.FirstOrDefaultAsync(e => e.VerifyId == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.Remark = remarks.Remark;

                await _context.SaveChangesAsync();
            }
            return Ok(dbEmployeeHis);
        }

        [HttpDelete("DeleteAllObj/{verId}")]
        public async Task<ActionResult<List<ConsumableRemarksT>>> DeleteAllObj(string verId)
        {
            var dbcol = await _context.ConsumableRemarksT.FirstOrDefaultAsync(h => h.VerifyId == verId);
            if (dbcol == null)
                return NotFound("Sorry, but no remarks");

            _context.ConsumableRemarksT.Remove(dbcol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("GetExistObj")]
        public async Task<ActionResult<int>> GetExistObj([FromQuery] string verifycode)
        {
            var masterlist = await _context.ConsumableRemarksT.ToListAsync();
            var countreturn = masterlist.Where(h => h.VerifyId == verifycode).Count();
            return countreturn;
        }
    }
}
