using HrisApp.Shared.Models.Assets.Consumables;

namespace HrisApp.Server.Controllers.AssetC.ConsumablesC
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumablesController : ControllerBase
    {
        private readonly DataContext _context;

        public ConsumablesController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<ConsumablesT>>> GetObjList()
        {
            var obj = await _context.ConsumablesT
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.Area)
                .Include(e => e.UOM)
                .Include(e => e.CreatedBy)
                .OrderByDescending(x => x.DateCreated)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<ConsumablesT>>> GetObj()
        {
            var obj = await _context.ConsumablesT
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.Area)
                .Include(e => e.UOM)
                .Include(e => e.CreatedBy)
                .OrderByDescending(x => x.DateCreated)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsumablesT>> GetSingleObj(int id)
        {
            var obj = await _context.ConsumablesT
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.Area)
                .Include(e => e.UOM)
                .Include(e => e.CreatedBy)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpGet("GetSingleObjByCode")]
        public async Task<ActionResult<ConsumablesT>> GetSingleObjByCode([FromQuery] string code)
        {
            var obj = await _context.ConsumablesT
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.Area)
                .Include(e => e.UOM)
                .Include(e => e.CreatedBy)
                .FirstOrDefaultAsync(h => h.AssetCode == code);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<ConsumablesT>> GetDBObj()
        {
            return await _context.ConsumablesT
                .Include(e => e.Category)
                .Include(e => e.SubCategory)
                .Include(e => e.Type)
                .Include(e => e.Area)
                .Include(e => e.UOM)
                .Include(e => e.CreatedBy)
                .OrderByDescending(x => x.DateCreated)
                .ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<ConsumablesT>> CreateArea(ConsumablesT model)
        {
            _context.ConsumablesT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(ConsumablesT model)
        {
            var dbarea = await _context.ConsumablesT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea!.Quantity = model.Quantity;
            dbarea.Cons_Name = model.Cons_Name;
            dbarea.Cons_Desc = model.Cons_Desc;
            dbarea.CategoryId = model.CategoryId;
            dbarea.SubCategoryId = model.SubCategoryId;
            dbarea.TypeId = model.TypeId;
            dbarea.AreaId = model.AreaId;
            dbarea.PurchaseDate = model.PurchaseDate;
            dbarea.TotalPurchaseAmount = model.TotalPurchaseAmount;
            dbarea.PricePerUOM = model.PricePerUOM;
            dbarea.UOMId = model.UOMId;
            dbarea.ProductID = model.ProductID;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetObjId/{name}")]
        public async Task<ActionResult<int>> GetObjId(string code)
        {
            var Masterlist = await _context.ConsumablesT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.JMCode.Contains(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId!.Id);
        }

        [HttpGet("GetLastCode")]
        public async Task<ActionResult<int>> GetLastCode([FromQuery] int type, [FromQuery] int cat, [FromQuery] int subcat)
        {
            var fromquery = $"{cat}-{subcat}";
            var filtered = await _context.ConsumablesT.Where(e => e.TypeId == type && e.CategoryId == cat && e.SubCategoryId == subcat).ToListAsync();
            var lastItem = filtered.OrderByDescending(e => e.Id).FirstOrDefault();

            if (lastItem != null)
            {
                string code = lastItem.JMCode;

                string splitcode = code.Split("-")[3];
                return Ok(Convert.ToInt32(splitcode));
            }

            return Ok(0);
        }
    }
}
