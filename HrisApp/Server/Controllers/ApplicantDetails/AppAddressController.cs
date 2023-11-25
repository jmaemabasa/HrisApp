using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.ApplicantDetails
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppAddressController : ControllerBase
    {
        private readonly DataContext _context;

        public AppAddressController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet("GetAddresses")]
        public async Task<ActionResult<IEnumerable<App_AddressT>>> GetAddresses()
        {
            var address = await _context.App_AddressT.ToListAsync();
            return Ok(address);
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<App_AddressT>> GetSingleAddress(int id)
        {
            var address = await _context.App_AddressT.FirstOrDefaultAsync(h => h.Id == id);
            if (address == null)
            {
                return NotFound("sorry no address here");
            }
            return Ok(address);
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, App_AddressT address)
        {
            var dbaddress = await _context.App_AddressT
                 .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbaddress == null)
                return NotFound("Sorry, but no users for you. :/");

            dbaddress.Verify_Id = address.Verify_Id;

            dbaddress.CurrentAdd = address.CurrentAdd;
            dbaddress.CurrentBrgy = address.CurrentBrgy;
            dbaddress.CurrentCity = address.CurrentCity;
            dbaddress.CurrentProvince = address.CurrentProvince;
            dbaddress.CurrentZipCode = address.CurrentZipCode;
            dbaddress.PermanentCountry = address.PermanentCountry;

            dbaddress.PermanentAdd = address.PermanentAdd;
            dbaddress.PermanentBrgy = address.PermanentBrgy;
            dbaddress.PermanentCity = address.PermanentCity;
            dbaddress.PermanentProvince = address.PermanentProvince;
            dbaddress.PermanentZipCode = address.PermanentZipCode;
            dbaddress.CurrentCountry = address.CurrentCountry;

            await _context.SaveChangesAsync();

            return Ok(await GetDbAddress());

        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<App_AddressT>> PostAddress(App_AddressT address)
        {
            _context.App_AddressT.Add(address);
            await _context.SaveChangesAsync();

            return Ok(await GetDbAddress());
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (_context.App_AddressT == null)
            {
                return NotFound();
            }
            var address = await _context.App_AddressT.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }

            _context.App_AddressT.Remove(address);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return (_context.App_AddressT?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private async Task<List<App_AddressT>> GetDbAddress()
        {
            return await _context.App_AddressT.ToListAsync();
        }
    }
}
