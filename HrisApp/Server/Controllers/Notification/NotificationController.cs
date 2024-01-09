using HrisApp.Shared.Models.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HrisApp.Server.Controllers.Notification
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly DataContext _context;

        public NotificationController(DataContext context)
        {
            _context = context;
        }

    }
}
