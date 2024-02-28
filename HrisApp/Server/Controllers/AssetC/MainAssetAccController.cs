namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainAssetAccController : ControllerBase
    {
        private readonly DataContext _context;

        public MainAssetAccController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<MainAssetAccessoriesT>>> GetObjList()
        {
            var obj = await _context.MainAssetAccessoriesT
                .Include(e => e.AssetMaster)
                .Include(e => e.AssetAccessory)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<MainAssetAccessoriesT>>> GetObj()
        {
            var obj = await _context.MainAssetAccessoriesT
                .Include(e => e.AssetMaster)
                .Include(e => e.AssetAccessory)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MainAssetAccessoriesT>> GetSingleObj(int id)
        {
            var obj = await _context.MainAssetAccessoriesT
                .Include(e => e.AssetMaster)
                .Include(e => e.AssetAccessory)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<MainAssetAccessoriesT>> GetDBObj()
        {
            return await _context.MainAssetAccessoriesT
                .Include(e => e.AssetMaster)
                .Include(e => e.AssetAccessory)
                .ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<MainAssetAccessoriesT>> CreateArea(MainAssetAccessoriesT model)
        {
            _context.MainAssetAccessoriesT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(MainAssetAccessoriesT model)
        {
            var dbarea = await _context.MainAssetAccessoriesT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea.AssetMasterId = model.AssetMasterId;
            dbarea.AssetMasterCode = model.AssetMasterCode;
            dbarea.AssetAccessoryId = model.AssetAccessoryId;
            dbarea.DateUsed = model.DateUsed;
            dbarea.DateStatusChanged = model.DateStatusChanged;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        //[HttpGet("GetObjId/{name}")]
        //public async Task<ActionResult<int>> GetAreaId(string code)
        //{
        //    var Masterlist = await _context.MainAssetAccessoriesT
        //        .ToListAsync();

        //    var _returnId = Masterlist.Where(d => d.Code.Contains(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

        //    return Ok(_returnId.Id);
        //}

        //[HttpGet("GetLastCode")]
        //public async Task<ActionResult<int>> GetLastCode([FromQuery] int type, [FromQuery] int cat, [FromQuery] int subcat)
        //{
        //    var fromquery = $"{cat}-{subcat}";
        //    var filtered = await _context.MainAssetAccessoriesT.Where(e => e.TypeId == type && e.CategoryId == cat && e.SubCategoryId == subcat).ToListAsync();
        //    var lastItem = filtered.OrderByDescending(e => e.Id).FirstOrDefault();

        //    if (lastItem != null)
        //    {
        //        string code = lastItem.Code;

        //        string splitcode = code.Split("-")[3];
        //        return Ok(Convert.ToInt32(splitcode));
        //    }

        //    return Ok(0);
        //}
    }
}