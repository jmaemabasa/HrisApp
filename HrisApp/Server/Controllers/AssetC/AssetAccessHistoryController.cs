namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetAccessHistoryController : ControllerBase
    {
        private readonly DataContext _context;

        public AssetAccessHistoryController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetAccessHistoryT>>> GetObjList()
        {
            var obj = await _context.AssetAccessHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetAccessory)
                .Include(e => e.Employee)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<AssetAccessHistoryT>>> GetObj()
        {
            var obj = await _context.AssetAccessHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetAccessory)
                .Include(e => e.Employee)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetAccessHistoryT>> GetSingleObj(int id)
        {
            var obj = await _context.AssetAccessHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetAccessory)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpGet("GetObjByAccIDMainId")]
        public async Task<ActionResult<AssetAccessHistoryT>> GetObjByAccIDMainId([FromQuery] int accid, [FromQuery] int mainid)
        {
            var obj = await _context.AssetAccessHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetAccessory)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(h => h.AssetAccessoryId == accid && h.MainAssetId == mainid);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<AssetAccessHistoryT>> GetDBObj()
        {
            return await _context.AssetAccessHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetAccessory)
                .Include(e => e.Employee)
                .ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetAccessHistoryT>> CreateObj(AssetAccessHistoryT model)
        {
            _context.AssetAccessHistoryT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateObj(AssetAccessHistoryT model)
        {
            var dbObj = await _context.AssetAccessHistoryT.FirstOrDefaultAsync(d => d.Id == model.Id);

            //dbObj.MainAssetId = model.MainAssetId;
            //dbObj.AssetAccessoryId = model.AssetAccessoryId;
            //dbObj.AssignedDateMainAss = model.AssignedDateMainAss;
            //dbObj.UnassignedDateMainAss = model.UnassignedDateMainAss;
            dbObj.EmployeeId = model.EmployeeId;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateDateUnassigned")]
        public async Task<ActionResult> UpdateDateUnassigned(AssetAccessHistoryT obj)
        {
            var dbObj = await _context.AssetAccessHistoryT.Where(
                d => d.AssetAccessoryId == obj.AssetAccessoryId
                     && d.MainAssetId == obj.MainAssetId)
                .FirstOrDefaultAsync();

            dbObj.UnassignedDateMainAss = obj.UnassignedDateMainAss;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetTestConsole")]
        public async Task<ActionResult<string>> GetTestConsole([FromQuery] int obj)
        {
            var test = await _context.AssetAccessHistoryT
                .Include(e => e.MainAsset)
                .Include(e => e.AssetAccessory)
                .Include(e => e.Employee)
                .Where(e => e.AssetAccessoryId == obj)
                .ToListAsync();

            var model = test.FirstOrDefault();
            var returnstring = $"parameter {obj}, return {model.UnassignedDateMainAss}";

            return Ok(returnstring);
        }
    }
}