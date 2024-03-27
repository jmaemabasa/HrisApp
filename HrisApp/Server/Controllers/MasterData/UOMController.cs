namespace HrisApp.Server.Controllers.MasterData
{
    [Route("api/[controller]")]
    [ApiController]
    public class UOMController : ControllerBase
    {
        private readonly DataContext _context;

        public UOMController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<UOMT>>> GetObjList()
        {
            var obj = await _context.UOMT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<UOMT>>> GetObj()
        {
            var obj = await _context.UOMT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UOMT>> GetSingleObj(int id)
        {
            var obj = await _context.UOMT.FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<UOMT>> GetDBObj()
        {
            return await _context.UOMT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<UOMT>> CreateArea(UOMT model)
        {
            _context.UOMT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(UOMT model)
        {
            var dbarea = await _context.UOMT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea.Code = model.Code;
            dbarea.Description = model.Description;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("IsExistCode")]
        public async Task<ActionResult<int>> IsExistCode([FromQuery] string code)
        {
            var masterlist = await _context.UOMT.ToListAsync();
            var countreturn = masterlist.Count(h => h.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
            return countreturn;
        }

        [HttpDelete("DeleteObj")]
        public async Task<ActionResult<string>> DeleteObj([FromQuery]int id)
        {
            try
            {
                var obj = await _context.UOMT
                .FirstOrDefaultAsync(h => h.Id == id);
                if (obj == null)
                    return NotFound("Sorry, but no obj");

                _context.UOMT.Remove(obj);

                await _context.SaveChangesAsync();

                return "Success";
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}
