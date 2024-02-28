namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetCategoryController : ControllerBase
    {
        private readonly DataContext _context;
        public AssetCategoryController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetCategoryT>>> GetObjList()
        {
            var obj = await _context.AssetCategoryT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<AssetCategoryT>>> GetObj()
        {
            var obj = await _context.AssetCategoryT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetCategoryT>> GetSingleObj(int id)
        {
            var obj = await _context.AssetCategoryT.FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<AssetCategoryT>> GetDBObj()
        {
            return await _context.AssetCategoryT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetCategoryT>> CreateArea(AssetCategoryT model)
        {
            _context.AssetCategoryT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(AssetCategoryT model)
        {
            var dbarea = await _context.AssetCategoryT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea.ACat_Name = model.ACat_Name;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetObjId/{name}")]
        public async Task<ActionResult<int>> GetAreaId(string code)
        {
            var Masterlist = await _context.AssetCategoryT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.ACat_Code.Contains(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        [HttpGet("GetLastCode")]
        public async Task<ActionResult<int>> GetLastCode()
        {
            var lastItem = await _context.AssetCategoryT.OrderByDescending(e => e.Id).FirstOrDefaultAsync();

            if (lastItem != null)
            {
                string code = lastItem.ACat_Code;
                string numericPart = code.Substring(3); 
                return Ok(Convert.ToInt32(numericPart));
            }

            return Ok(0);

        }
    }
}
