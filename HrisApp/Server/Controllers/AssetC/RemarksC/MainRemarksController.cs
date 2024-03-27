namespace HrisApp.Server.Controllers.AssetC.Remarks
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainRemarksController : ControllerBase
    {
        private readonly DataContext _context;

        public MainRemarksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetObjList")]
        public async Task<ActionResult<List<MainRemarksT>>> GetObjList([FromQuery] string code)
        {
            var collegelist = await _context.MainRemarksT
                .Where(x => x.MainAssetCode == code)
                .ToListAsync();

            return Ok(collegelist);
        }


        [HttpPost("CreateObj")]
        public async Task<ActionResult<MainRemarksT>> CreateObj([FromBody] MainRemarksT obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }

            _context.MainRemarksT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }

        [HttpPut("UpdateObj/{VerifyId}")]
        public async Task<ActionResult<List<MainRemarksT>>> UpdateObj(MainRemarksT remarks, string VerifyId)
        {
            var dbEmployeeHis = await _context.MainRemarksT.FirstOrDefaultAsync(e => e.VerifyId == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.Remark = remarks.Remark;

                await _context.SaveChangesAsync();
            }
            return Ok(dbEmployeeHis);
        }

        [HttpDelete("DeleteAllObj/{verId}")]
        public async Task<ActionResult<List<MainRemarksT>>> DeleteAllObj(string verId)
        {
            var dbcol = await _context.MainRemarksT.FirstOrDefaultAsync(h => h.VerifyId == verId);
            if (dbcol == null)
                return NotFound("Sorry, but no remarks");

            _context.MainRemarksT.Remove(dbcol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("GetExistObj")]
        public async Task<ActionResult<int>> GetExistObj([FromQuery] string verifycode)
        {
            var masterlist = await _context.MainRemarksT.ToListAsync();
            var countreturn = masterlist.Where(h => h.VerifyId == verifycode).Count();
            return countreturn;
        }
    }
}
