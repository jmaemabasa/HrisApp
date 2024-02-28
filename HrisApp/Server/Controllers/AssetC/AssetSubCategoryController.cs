namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetSubCategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public AssetSubCategoryController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetSubCategoryT>>> GetObjList()
        {
            var obj = await _context.AssetSubCategoryT.Include(e => e.Category).ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<AssetSubCategoryT>>> GetObj()
        {
            var obj = await _context.AssetSubCategoryT.Include(e => e.Category).ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetSubCategoryT>> GetSingleObj(int id)
        {
            var obj = await _context.AssetSubCategoryT.FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<AssetSubCategoryT>> GetDBObj()
        {
            return await _context.AssetSubCategoryT.Include(e => e.Category).ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetSubCategoryT>> CreateArea(AssetSubCategoryT model)
        {
            _context.AssetSubCategoryT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(AssetSubCategoryT model)
        {
            var dbarea = await _context.AssetSubCategoryT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea.ASubCat_Name = model.ASubCat_Name;
            dbarea.CategoryId = model.CategoryId;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetObjId/{code}")]
        public async Task<ActionResult<int>> GetAreaId(string code)
        {
            var Masterlist = await _context.AssetSubCategoryT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.ASubCat_Code.Contains(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        [HttpGet("GetLastCode")]
        public async Task<ActionResult<int>> GetLastCode()
        {
            var lastItem = await _context.AssetSubCategoryT.OrderByDescending(e => e.Id).FirstOrDefaultAsync();

            if (lastItem != null)
            {
                string code = lastItem.ASubCat_Code;
                string numericPart = code.Substring(4);
                return Ok(Convert.ToInt32(numericPart));
            }

            return Ok(0);
        }
    }
}