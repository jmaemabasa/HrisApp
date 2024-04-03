using HrisApp.Shared.Models.Assets.Licenses;

namespace HrisApp.Server.Controllers.AssetC.LicensesC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssLicenseHistoryController : ControllerBase
    {
        private readonly DataContext _context;

        public AssLicenseHistoryController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetLicenseHistoryT>>> GetObjList()
        {
            var obj = await _context.AssetLicenseHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetLicense)
                .Include(e => e.Employee)
                .OrderByDescending(e => e.AssignedDateMainAss)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<AssetLicenseHistoryT>>> GetObj()
        {
            var obj = await _context.AssetLicenseHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetLicense)
                .Include(e => e.Employee)
                .OrderByDescending(e => e.AssignedDateMainAss)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetLicenseHistoryT>> GetSingleObj(int id)
        {
            var obj = await _context.AssetLicenseHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetLicense)
                .Include(e => e.Employee)
                .OrderByDescending(e => e.AssignedDateMainAss)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpGet("GetObjByAccIDMainId")]
        public async Task<ActionResult<AssetLicenseHistoryT>> GetObjByAccIDMainId([FromQuery] int accid, [FromQuery] int mainid)
        {
            var obj = await _context.AssetLicenseHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetLicense)
                .Include(e => e.Employee)
                .OrderByDescending(e => e.AssignedDateMainAss)
                .FirstOrDefaultAsync(h => h.AssetLicenseId == accid && h.MainAssetId == mainid);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<AssetLicenseHistoryT>> GetDBObj()
        {
            return await _context.AssetLicenseHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetLicense)
                .Include(e => e.Employee)
                .OrderByDescending(e => e.AssignedDateMainAss)
                .ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetLicenseHistoryT>> CreateObj(AssetLicenseHistoryT model)
        {
            _context.AssetLicenseHistoryT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateObj(AssetLicenseHistoryT model)
        {
            var dbObj = await _context.AssetLicenseHistoryT.FirstOrDefaultAsync(d => d.Id == model.Id);

            //dbObj.MainAssetId = model.MainAssetId;
            //dbObj.AssetAccessoryId = model.AssetAccessoryId;
            //dbObj.AssignedDateMainAss = model.AssignedDateMainAss;
            //dbObj.UnassignedDateMainAss = model.UnassignedDateMainAss;
            dbObj!.EmployeeId = model.EmployeeId;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateDateUnassigned")]
        public async Task<ActionResult> UpdateDateUnassigned(AssetLicenseHistoryT obj)
        {
            var dbObj = await _context.AssetLicenseHistoryT.Where(
                d => d.AssetLicenseId == obj.AssetLicenseId
                     && d.MainAssetId == obj.MainAssetId)
                .FirstOrDefaultAsync();

            dbObj!.UnassignedDateMainAss = obj.UnassignedDateMainAss;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetTestConsole")]
        public async Task<ActionResult<string>> GetTestConsole([FromQuery] int obj)
        {
            var test = await _context.AssetLicenseHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetLicense)
                .Include(e => e.Employee)
                .Where(e => e.AssetLicenseId == obj)
                .ToListAsync();

            var model = test.FirstOrDefault();
            var returnstring = $"parameter {obj}, return {model!.UnassignedDateMainAss}";

            return Ok(returnstring);
        }
    }
}
