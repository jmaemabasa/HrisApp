namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetSubCategory2Controller : ControllerBase
    {
        private readonly DataContext _context;

        public AssetSubCategory2Controller(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetSubCategory2T>>> GetObjList()
        {
            var obj = await _context.AssetSubCategory2T.Include(e => e.Category).Include(e => e.SubCategory).ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<AssetSubCategory2T>>> GetObj()
        {
            var obj = await _context.AssetSubCategory2T.Include(e => e.Category).Include(e => e.SubCategory).ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetSubCategory2T>> GetSingleObj(int id)
        {
            var obj = await _context.AssetSubCategory2T.Include(e => e.Category).Include(e => e.SubCategory).FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<AssetSubCategory2T>> GetDBObj()
        {
            return await _context.AssetSubCategory2T.Include(e => e.Category).ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetSubCategory2T>> CreateArea(AssetSubCategory2T model)
        {
            _context.AssetSubCategory2T.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(AssetSubCategory2T model)
        {
            var dbarea = await _context.AssetSubCategory2T.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea.ASubCat2_Name = model.ASubCat2_Name;
            dbarea.CategoryId = model.CategoryId;
            dbarea.SubCategoryId = model.SubCategoryId;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetObjId/{code}")]
        public async Task<ActionResult<int>> GetAreaId(string code)
        {
            var Masterlist = await _context.AssetSubCategory2T
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.ASubCat2_Code.Contains(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        [HttpGet("GetLastCode")]
        public async Task<ActionResult<int>> GetLastCode()
        {
            var lastItem = await _context.AssetSubCategory2T.OrderByDescending(e => e.Id).FirstOrDefaultAsync();

            if (lastItem != null)
            {
                string code = lastItem.ASubCat2_Code;
                string numericPart = code.Substring(5);
                return Ok(Convert.ToInt32(numericPart));
            }

            return Ok(0);
        }
    }
}
