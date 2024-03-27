using HrisApp.Shared.Models.Assets.Consumables;

namespace HrisApp.Server.Controllers.AssetC.ConsumablesC
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsTransactionController : ControllerBase
    {
        private readonly DataContext _context;

        public ConsTransactionController(DataContext context)
        {
            _context = context;
        }

        //GEEET
        [HttpGet]
        public async Task<ActionResult<List<Cons_TransactionT>>> GetObjList()
        {
            var obj = await _context.Cons_TransactionT
                .Include(e => e.Consumable)
                .Include(e => e.Consumable!.UOM)
                .Include(e => e.Employee)
                .Include(e => e.Department)
                .Include(e => e.Vendor)
                .Include(e => e.CreatedBy)
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("GetObj")]
        public async Task<ActionResult<List<Cons_TransactionT>>> GetObj()
        {
            var obj = await _context.Cons_TransactionT
                 .Include(e => e.Consumable)
                .Include(e => e.Consumable!.UOM)
                .Include(e => e.Employee)
                .Include(e => e.Department)
                .Include(e => e.Vendor)
                .Include(e => e.CreatedBy)
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();
            return Ok(obj);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cons_TransactionT>> GetSingleObj(int id)
        {
            var obj = await _context.Cons_TransactionT
                .Include(e => e.Consumable)
                .Include(e => e.Consumable!.UOM)
                .Include(e => e.Employee)
                .Include(e => e.Department)
                .Include(e => e.Vendor)
                .Include(e => e.CreatedBy)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpGet("GetSingleObjByCode")]
        public async Task<ActionResult<Cons_TransactionT>> GetSingleObjByCode([FromQuery] string code)
        {
            var obj = await _context.Cons_TransactionT
                .Include(e => e.Consumable)
                .Include(e => e.Consumable!.UOM)
                .Include(e => e.Employee)
                .Include(e => e.Department)
                .Include(e => e.Vendor)
                .Include(e => e.CreatedBy)
                .FirstOrDefaultAsync(h => h.Transact_Code == code);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        private async Task<List<Cons_TransactionT>> GetDBObj()
        {
            return await _context.Cons_TransactionT
                .Include(e => e.Consumable)
                .Include(e => e.Consumable!.UOM)
                .Include(e => e.Employee)
                .Include(e => e.Department)
                .Include(e => e.Vendor)
                .Include(e => e.CreatedBy)
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();
        }

        //CREATE AND UPDATEEE
        [HttpPost("CreateObj")]
        public async Task<ActionResult<Cons_TransactionT>> CreateArea(Cons_TransactionT model)
        {
            _context.Cons_TransactionT.Add(model);
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateArea(Cons_TransactionT model)
        {
            var dbarea = await _context.Cons_TransactionT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea!.Transact_Type = model.Transact_Type;
            await _context.SaveChangesAsync();

            return Ok(await GetDBObj());
        }

        [HttpGet("GetObjId/{name}")]
        public async Task<ActionResult<int>> GetObjId(string code)
        {
            var Masterlist = await _context.Cons_TransactionT
                .ToListAsync();

            var _returnId = Masterlist.Where(d => d.Transact_Code.Contains(code, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            return Ok(_returnId!.Id);
        }

        [HttpGet("GetLastCode")]
        public async Task<ActionResult<int>> GetLastCode()
        {
            var lastItem = await _context.Cons_TransactionT.OrderByDescending(e => e.CreatedOn).FirstOrDefaultAsync();

            if (lastItem != null)
            {
                string code = lastItem.Transact_Code;
                string numericPart = code.Substring(3);
                return Ok(Convert.ToInt32(numericPart));
            }

            return Ok(0);

        }

        [HttpGet("TopIssuedEmployees")]
        public async Task<ActionResult<List<EmployeeT>>> GetTopIssuedEmployees([FromQuery] int consID)
        {
            var topIssuedEmployees = await _context.Cons_TransactionT
                .Where(e => e.ConsumableId == consID)
                .GroupBy(t => t.EmployeeId)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.FirstOrDefault()!.Employee)
                .ToListAsync();

            return Ok(topIssuedEmployees);
        }
    }
}
