using Microsoft.AspNetCore.Authorization;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System.Security.Claims;

namespace HrisApp.Server.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly DataContext _context;

        public AuthController(IUserService userService, DataContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse>> Register(UserLoginDto request)
        {
            var verid = await _context.EmployeeT.Where(d => d.Id == request.EmployeeId).FirstOrDefaultAsync();
            var response = await _userService.Register(
                new UserMasterT
                {
                    EmployeeId = request.EmployeeId,
                    Username = request.Username,
                    Role = request.Role,
                    LoginStatus = request.LoginStatus,
                    Emp_VerifyId = verid.Verify_Id
                },
                request.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("UpdateLoginStatus/{id}")]
        public async Task<ActionResult<ServiceResponse>> UpdateLoginStatus(int id)
        {
            var response = await _userService.Putaccount(id);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("UpdatePassword/{id}")]
        public async Task<ActionResult<ServiceResponse>> UpdatePassword(int id, [FromBody] string newpass)
        {
            var response = await _userService.Putpassword(id, newpass);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserMasterT request)
        {
            request.LoginStatus = "Active";

            var response = await _userService.Login(request.Username, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("change-password"), Authorize]
        public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _userService.ChangesPassword(int.Parse(userId), newPassword);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("GetUserList")]
        public async Task<ActionResult<List<UserMasterT>>> GetUserList()
        {
            var user = await _context.UserMasterT.ToListAsync();
            return Ok(user);
        }

        [HttpGet("UserExists")]
        public async Task<bool> UserExists(string username)
        {
            if (await _context.UserMasterT.AnyAsync(user => user.Username.ToLower()
                .Equals(username.ToLower())))
            {
                return true;
            }
            return false;
        }

        [HttpGet("GetAllEmployeeID")]
        public async Task<ActionResult<List<string>>> GetAllEmployeeID()
        {
            var users = await _context.UserMasterT.ToListAsync();

            var employeeIds = users.Select(user => user.EmployeeId.ToString()).ToList();
            return Ok(employeeIds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserMasterT>> GetSingleObj(int id)
        {
            var obj = await _context.UserMasterT
                .Include(e => e.Employee)
                .Include(e => e.Employee!.Department)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return Ok(obj);
        }

        [HttpPut("UpdateObj")]
        public async Task<ActionResult> UpdateObj(UserMasterT model)
        {
            var dbarea = await _context.UserMasterT.FirstOrDefaultAsync(d => d.Id == model.Id);

            dbarea!.Role = model.Role;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("IsPassMatched")]
        public async Task<bool> IsPassMatched([FromQuery] int id, [FromQuery] string inputpass)
        {
            var response = await _userService.IsPassMatched(id, inputpass);

            return response;
        }
    }
}