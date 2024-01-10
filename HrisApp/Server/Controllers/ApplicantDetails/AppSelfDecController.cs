using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppSelfDecController : ControllerBase
    {
        private readonly DataContext _context;

        public AppSelfDecController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet("GetSelfDec")]
        public async Task<ActionResult<IEnumerable<App_SelfDeclarationT>>> GetASelfDec()
        {
            var address = await _context.App_SelfDeclarationT.ToListAsync();
            return Ok(address);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<App_SelfDeclarationT>> GetSingleSelfDec(int id)
        {
            var address = await _context.App_SelfDeclarationT.FirstOrDefaultAsync(h => h.Id == id);
            if (address == null)
            {
                return NotFound("sorry no address here");
            }
            return Ok(address);
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSelfDec(int id, App_SelfDeclarationT address)
        {
            var dbaddress = await _context.App_SelfDeclarationT
                 .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbaddress == null)
                return NotFound("Sorry, but no users for you. :/");

            dbaddress.App_VerifyId = address.App_VerifyId;

            dbaddress.Q1Ans = address.Q1Ans;
            dbaddress.Q1Dtls = address.Q1Dtls;
            dbaddress.Q2Ans = address.Q2Ans;
            dbaddress.Q2Dtls = address.Q2Dtls;
            dbaddress.Q3Ans = address.Q3Ans;
            dbaddress.Q3Dtls = address.Q3Dtls;
            dbaddress.Q4Ans = address.Q3Ans;
            dbaddress.Q4Dtls = address.Q3Dtls;
            dbaddress.Q5Ans = address.Q3Ans;
            dbaddress.Q5Dtls = address.Q3Dtls;
            dbaddress.Q6Ans = address.Q3Ans;
            dbaddress.Q6Dtls = address.Q3Dtls;
            dbaddress.Q7Ans = address.Q3Ans;
            dbaddress.Q7Dtls = address.Q3Dtls;


            await _context.SaveChangesAsync();

            return Ok(await GetDbSelfDec());

        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<App_SelfDeclarationT>> PostSelfDec(App_SelfDeclarationT address)
        {
            _context.App_SelfDeclarationT.Add(address);
            await _context.SaveChangesAsync();

            return Ok(await GetDbSelfDec());
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSelfDec(int id)
        {
            if (_context.App_SelfDeclarationT == null)
            {
                return NotFound();
            }
            var address = await _context.App_SelfDeclarationT.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.App_SelfDeclarationT.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SelfDecExists(int id)
        {
            return (_context.App_SelfDeclarationT?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private async Task<List<App_SelfDeclarationT>> GetDbSelfDec()
        {
            return await _context.App_SelfDeclarationT.ToListAsync();
        }
    }
}
