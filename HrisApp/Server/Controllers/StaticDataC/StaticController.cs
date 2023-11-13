using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.StaticDataC
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticController : ControllerBase
    {
        private readonly DataContext _context;

        public StaticController(DataContext context)
        {
            _context = context;
        }
    }
}
