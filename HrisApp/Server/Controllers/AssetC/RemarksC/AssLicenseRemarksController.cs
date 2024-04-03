using HrisApp.Shared.Models.Assets.Licenses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.AssetC.RemarksC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssLicenseRemarksController : ControllerBase
    {
        private readonly DataContext _context;

        public AssLicenseRemarksController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("GetObjList")]
        public async Task<ActionResult<List<AssetLicenseRemarksT>>> GetObjList([FromQuery] string code)
        {
            var collegelist = await _context.AssetLicenseRemarksT
                .Where(x => x.LicenseAssetCode == code)
                .ToListAsync();

            return Ok(collegelist);
        }


        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetLicenseRemarksT>> CreateObj([FromBody] AssetLicenseRemarksT obj)
        {
            if (obj == null)
            {
                return BadRequest("Invalid data");
            }

            _context.AssetLicenseRemarksT.Add(obj);
            await _context.SaveChangesAsync();

            return Ok(obj);
        }

        [HttpPut("UpdateObj/{VerifyId}")]
        public async Task<ActionResult<List<AssetLicenseRemarksT>>> UpdateObj(AssetLicenseRemarksT remarks, string VerifyId)
        {
            var dbEmployeeHis = await _context.AssetLicenseRemarksT.FirstOrDefaultAsync(e => e.VerifyId == VerifyId);

            if (dbEmployeeHis != null)
            {
                dbEmployeeHis.Remark = remarks.Remark;

                await _context.SaveChangesAsync();
            }
            return Ok(dbEmployeeHis);
        }

        [HttpDelete("DeleteAllObj/{verId}")]
        public async Task<ActionResult<List<AssetLicenseRemarksT>>> DeleteAllObj(string verId)
        {
            var dbcol = await _context.AssetLicenseRemarksT.FirstOrDefaultAsync(h => h.VerifyId == verId);
            if (dbcol == null)
                return NotFound("Sorry, but no remarks");

            _context.AssetLicenseRemarksT.Remove(dbcol);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("GetExistObj")]
        public async Task<ActionResult<int>> GetExistObj([FromQuery] string verifycode)
        {
            var masterlist = await _context.AssetLicenseRemarksT.ToListAsync();
            var countreturn = masterlist.Where(h => h.VerifyId == verifycode).Count();
            return countreturn;
        }
    }
}
