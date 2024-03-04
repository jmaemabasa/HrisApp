namespace HrisApp.Server.Controllers.AssetC
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetLastDateCheckController : ControllerBase
    {
        private readonly DataContext _context;

        public AssetLastDateCheckController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<AssetLastCheckT>>> GetObjList()
        {
            var obj = await _context.AssetLastCheckT
                .Include(e => e.MainAsset)
                .OrderByDescending(e => e.LastCheckDate)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<AssetLastCheckT>>> GetObj()
        {
            var obj = await _context.AssetLastCheckT
                .Include(e => e.MainAsset)
                .OrderByDescending(e => e.LastCheckDate)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetLastCheckT>> GetSingleObj(int id)
        {
            var obj = await _context.AssetLastCheckT
                .Include(e => e.MainAsset)
                .OrderByDescending(e => e.LastCheckDate)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<AssetLastCheckT>> GetDBObj()
        {
            return await _context.AssetLastCheckT
                .Include(e => e.MainAsset)
                .OrderByDescending(e => e.LastCheckDate)
                .ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<AssetLastCheckT>> CreateArea(AssetLastCheckT model)
        {
            _context.AssetLastCheckT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(AssetLastCheckT model)
        {
            var dbarea = await _context.AssetLastCheckT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea.MainAssetId = model.MainAssetId;
            dbarea.LastCheckDate = model.LastCheckDate;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }
    }
}