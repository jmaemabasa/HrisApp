namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetAccessController : ControllerBase
    {
        private readonly DataContext _context;

        public AssetAccessController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetAccessoryT>>> GetObjList()
        {
            var obj = await _context.AssetAccessoryT
                .Include(e => e.AssetStatus)
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                                .Include(e => e.MainAsset)
.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<AssetAccessoryT>>> GetObj()
        {
            var obj = await _context.AssetAccessoryT
                .Include(e => e.AssetStatus)
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                                .Include(e => e.MainAsset)
.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetAccessoryT>> GetSingleObj(int id)
        {
            var obj = await _context.AssetAccessoryT
                .Include(e => e.AssetStatus)
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.MainAsset)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<AssetAccessoryT>> GetDBObj()
        {
            return await _context.AssetAccessoryT
                .Include(e => e.AssetStatus)
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.MainAsset)
                .ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetAccessoryT>> CreateArea(AssetAccessoryT model)
        {
            _context.AssetAccessoryT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(AssetAccessoryT model)
        {
            var dbarea = await _context.AssetAccessoryT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea.Asset = model.Asset;
            dbarea.Brand = model.Brand;
            dbarea.Model = model.Model;
            dbarea.TypeId = model.TypeId;
            dbarea.CategoryId = model.CategoryId;
            dbarea.SubCategoryId = model.SubCategoryId;
            dbarea.Location = model.Location;
            dbarea.Serial = model.Serial;
            dbarea.PurchaseDate = model.PurchaseDate;
            dbarea.AssetStatusId = model.AssetStatusId;
            dbarea.Remarks = model.Remarks;
            dbarea.InUseStatusDate = model.InUseStatusDate;
            dbarea.StatusDate = model.StatusDate;

            dbarea.MainAssetId = model.MainAssetId;
            dbarea.MainAssetDateUpdated = model.MainAssetDateUpdated;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetObjId/{name}")]
        public async Task<ActionResult<int>> GetAreaId(string code)
        {
            var Masterlist = await _context.AssetAccessoryT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Code.Contains(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        [HttpGet("GetLastCode")]
        public async Task<ActionResult<int>> GetLastCode([FromQuery] int cat, [FromQuery] int subcat)
        {
            var fromquery = $"{cat}-{subcat}";
            var filtered = await _context.AssetAccessoryT.Where(e => e.CategoryId == cat && e.SubCategoryId == subcat).ToListAsync();
            var lastItem = filtered.OrderByDescending(e => e.Id).FirstOrDefault();

            if (lastItem != null)
            {
                string code = lastItem.Code;

                string splitcode = code.Split("-")[2];
                return Ok(Convert.ToInt32(splitcode));
            }

            return Ok(0);
        }
    }
}