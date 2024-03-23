namespace HrisApp.Server.Controllers.AssetC.Remarks
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleRemarksController : ControllerBase
    {
        private readonly DataContext _context;

        public VehicleRemarksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetObjList")]
        public async Task<ActionResult<List<VehicleRemarksT>>> GetObjList([FromQuery] string code)
        {
            var collegelist = await _context.VehicleRemarksT
                .Where(x => x.VhcAssetCode == code)
                .ToListAsync();

            return Ok(collegelist);
        }


        [HttpPost("CreateObj")]
        public async Task<ActionResult<VehicleRemarksT>> CreateObj([FromBody] VehicleRemarksT obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }

            _context.VehicleRemarksT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }

        [HttpPut("UpdateObj/{VerifyId}")]
        public async Task<ActionResult<List<VehicleRemarksT>>> UpdateObj(VehicleRemarksT remarks, string VerifyId)
        {
            var dbEmployeeHis = await _context.VehicleRemarksT.FirstOrDefaultAsync(e => e.VerifyId == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.Remark = remarks.Remark;

                await _context.SaveChangesAsync();
            }
            return Ok(dbEmployeeHis);
        }

        [HttpDelete("DeleteAllObj/{verId}")]
        public async Task<ActionResult<List<VehicleRemarksT>>> DeleteAllObj(string verId)
        {
            var dbcol = await _context.VehicleRemarksT.FirstOrDefaultAsync(h => h.VerifyId == verId);
            if (dbcol == null)
                return NotFound("Sorry, but no remarks");

            _context.VehicleRemarksT.Remove(dbcol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("GetExistObj")]
        public async Task<ActionResult<int>> GetExistObj([FromQuery] string verifycode)
        {
            var masterlist = await _context.VehicleRemarksT.ToListAsync();
            var countreturn = masterlist.Where(h => h.VerifyId == verifycode).Count();
            return countreturn;
        }
    }
}
