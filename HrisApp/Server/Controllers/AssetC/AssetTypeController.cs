namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public AssetTypeController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetTypesT>>> GetObjList()
        {
            var obj = await _context.AssetTypesT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<AssetTypesT>>> GetObj()
        {
            var obj = await _context.AssetTypesT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetTypesT>> GetSingleObj(int id)
        {
            var obj = await _context.AssetTypesT.FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<AssetTypesT>> GetDBObj()
        {
            return await _context.AssetTypesT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetTypesT>> CreateArea(AssetTypesT model)
        {
            _context.AssetTypesT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(AssetTypesT model)
        {
            var dbarea = await _context.AssetTypesT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea.AType_Name = model.AType_Name;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetObjId/{code}")]
        public async Task<ActionResult<int>> GetAreaId(string code)
        {
            var Masterlist = await _context.AssetTypesT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.AType_Code.Contains(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId.Id);
        }

        [HttpGet("GetLastCode")]
        public async Task<ActionResult<int>> GetLastCode()
        {
            var lastItem = await _context.AssetTypesT.OrderByDescending(e => e.Id).FirstOrDefaultAsync();

            if (lastItem != null)
            {
                return Ok(Convert.ToInt32(lastItem.AType_Code));
            }
            return Ok(000);
        }
    }
}
