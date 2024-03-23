namespace HrisApp.Server.Controllers.AssetC.Remarks
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessRemarksController : ControllerBase
    {
        private readonly DataContext _context;

        public AccessRemarksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetObjList")]
        public async Task<ActionResult<List<AccessoryRemarksT>>> GetObjList([FromQuery] string code)
        {
            var collegelist = await _context.AccessoryRemarksT
                .Where(x => x.AccAssetCode == code)
                .ToListAsync();

            return Ok(collegelist);
        }


        [HttpPost("CreateObj")]
        public async Task<ActionResult<AccessoryRemarksT>> CreateObj([FromBody] AccessoryRemarksT obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }

            _context.AccessoryRemarksT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }

        [HttpPut("UpdateObj/{VerifyId}")]
        public async Task<ActionResult<List<AccessoryRemarksT>>> UpdateObj(AccessoryRemarksT remarks, string VerifyId)
        {
            var dbEmployeeHis = await _context.AccessoryRemarksT.FirstOrDefaultAsync(e => e.VerifyId == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.Remark = remarks.Remark;

                await _context.SaveChangesAsync();
            }
            return Ok(dbEmployeeHis);
        }

        [HttpDelete("DeleteAllObj/{verId}")]
        public async Task<ActionResult<List<AccessoryRemarksT>>> DeleteAllObj(string verId)
        {
            var dbcol = await _context.AccessoryRemarksT.FirstOrDefaultAsync(h => h.VerifyId == verId);
            if (dbcol == null)
                return NotFound("Sorry, but no remarks");

            _context.AccessoryRemarksT.Remove(dbcol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("GetExistObj")]
        public async Task<ActionResult<int>> GetExistObj([FromQuery] string verifycode)
        {
            var masterlist = await _context.AccessoryRemarksT.ToListAsync();
            var countreturn = masterlist.Where(h => h.VerifyId == verifycode).Count();
            return countreturn;
        }
    }
}
