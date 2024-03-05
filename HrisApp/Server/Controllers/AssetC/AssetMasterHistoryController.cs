namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetMasterHistoryController : ControllerBase
    {
        private readonly DataContext _context;

        public AssetMasterHistoryController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetMasterHistoryT>>> GetObjList()
        {
            var obj = await _context.AssetMasterHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.Employee)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<AssetMasterHistoryT>>> GetObj()
        {
            var obj = await _context.AssetMasterHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.Employee)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetMasterHistoryT>> GetSingleObj(int id)
        {
            var obj = await _context.AssetMasterHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<AssetMasterHistoryT>> GetDBObj()
        {
            return await _context.AssetMasterHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.Employee)
                .ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetMasterHistoryT>> CreateArea(AssetMasterHistoryT model)
        {
            _context.AssetMasterHistoryT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(AssetMasterHistoryT model)
        {
            var dbObj = await _context.AssetMasterHistoryT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbObj.MainAssetId = model.MainAssetId;
            dbObj.MainAssetCode = model.MainAssetCode;
            dbObj.EmployeeId = model.EmployeeId;
            dbObj.AssignedDateReleased = model.AssignedDateReleased;
            dbObj.AssignedDateToReturn = model.AssignedDateToReturn;
            dbObj.EndDate = model.EndDate;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateDateReturned")]
        public async Task<ActionResult> UpdateDateReturned([FromQuery] int empid, [FromQuery] int mainassetid, [FromQuery] DateTime? released, AssetMasterHistoryT model)
        {
            var dbObj = await _context.AssetMasterHistoryT.Where(
                d => d.EmployeeId == empid
                     && d.MainAssetId == mainassetid
                     && d.AssignedDateReleased.Value.Date == released.Value.Date)
                .FirstOrDefaultAsync();

            dbObj.EndDate = model.EndDate;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }
    }
}