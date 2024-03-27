namespace HrisApp.Server.Controllers.MasterData
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly DataContext _context;

        public VendorController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<VendorT>>> GetObjList()
        {
            var obj = await _context.VendorT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<VendorT>>> GetObj()
        {
            var obj = await _context.VendorT.ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VendorT>> GetSingleObj(int id)
        {
            var obj = await _context.VendorT.FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<VendorT>> GetDBObj()
        {
            return await _context.VendorT.ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<VendorT>> CreateArea(VendorT model)
        {
            _context.VendorT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateObj(VendorT model)
        {
            var dbarea = await _context.VendorT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea!.Code = model.Code;
            dbarea.Name = model.Name;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("IsExistCode")]
        public async Task<ActionResult<int>> IsExistCode([FromQuery] string code)
        {
            var masterlist = await _context.VendorT.ToListAsync();
            var countreturn = masterlist.Count(h => h.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
            return countreturn;
        }

        [HttpDelete("DeleteObj")]
        public async Task<ActionResult<string>> DeleteObj([FromQuery] int id)
        {
            try
            {
                var obj = await _context.VendorT
                .FirstOrDefaultAsync(h => h.Id == id);
                if (obj == null)
                    return NotFound("Sorry, but no obj");

                _context.VendorT.Remove(obj);

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
