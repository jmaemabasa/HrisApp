namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainAssetLicenseController : ControllerBase
    {
        private readonly DataContext _context;

        public MainAssetLicenseController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<MainAssetLicensesT>>> GetObjList()
        {
            var obj = await _context.MainAssetLicensesT
                .Include(e => e.AssetMaster)
                .Include(e => e.AssetLicense)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<MainAssetLicensesT>>> GetObj()
        {
            var obj = await _context.MainAssetLicensesT
                .Include(e => e.AssetMaster)
                .Include(e => e.AssetLicense)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MainAssetLicensesT>> GetSingleObj(int id)
        {
            var obj = await _context.MainAssetLicensesT
                .Include(e => e.AssetMaster)
                .Include(e => e.AssetLicense)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<MainAssetLicensesT>> GetDBObj()
        {
            return await _context.MainAssetLicensesT
                .Include(e => e.AssetMaster)
                .Include(e => e.AssetLicense)
                .ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<MainAssetLicensesT>> CreateArea(MainAssetLicensesT model)
        {
            _context.MainAssetLicensesT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(MainAssetLicensesT model)
        {
            var dbarea = await _context.MainAssetLicensesT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea!.AssetMasterId = model.AssetMasterId;
            dbarea.AssetMasterCode = model.AssetMasterCode;
            dbarea.AssetLicenseId = model.AssetLicenseId;
            dbarea.DateUsed = model.DateUsed;
            dbarea.DateStatusChanged = model.DateStatusChanged;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpDelete("DeleteAccessory")]
        public async Task<ActionResult<List<MainAssetLicensesT>>> DeleteAccessory([FromQuery] int mainid, [FromQuery] int accid)
        {
            var dbcol = await _context.MainAssetLicensesT
                .Where(h => h.AssetMasterId == mainid && h.AssetLicenseId == accid)
                .FirstOrDefaultAsync();

            if (dbcol == null)
                return NotFound("Sorry, but no senior");

            _context.MainAssetLicensesT.Remove(dbcol);

            await _context.SaveChangesAsync();

            return Ok(dbcol);
        }
    }
}