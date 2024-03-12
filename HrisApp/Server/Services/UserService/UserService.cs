using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace HrisApp.Server.Services.UserService
{
#nullable disable

    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UserService(IHttpContextAccessor httpContextAccessor, DataContext context, IConfiguration configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _configuration = configuration;
        }

        //GEEEEET
        public async Task<bool> UserExists(string username)
        {
            if (await _context.UserMasterT.AnyAsync(user => user.Username.ToLower()
                .Equals(username.ToLower())))
            {
                return true;
            }
            return false;
        }

        public string GetUserEmail() =>
            _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

        public int GetUserId() =>
            int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<UserMasterT> GetUserByEmail(string email)
        {
            return await _context.UserMasterT.FirstOrDefaultAsync(u => u.Username.Equals(email));
            //return await _context.UserMasterT.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

        //PASSWORDSSSSSSSS and TOKEN
        private string CreateToken(UserMasterT user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.EmployeeId.ToString()),
                new Claim(ClaimTypes.Name,  user.Username),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.StreetAddress, user.Emp_VerifyId),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac
                    .ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash =
                    hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public async Task<ServiceResponse<bool>> ChangesPassword(int userId, string newPassword)
        {
            var user = await _context.UserMasterT.FindAsync(userId);
            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "User not found."
                };
            }
            CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();

            return new ServiceResponse<bool> { Data = true, Message = "Password has been changed." };
        }

        //LOGIN AND RESGITER

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var login = await _context.UserMasterT
                .FirstOrDefaultAsync(x => x.Username.ToLower().Equals(username.ToLower()));
            if (login == null)
            {
                response.Success = false;
                response.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, login.PasswordHash, login.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong password.";
            }
            else
            {
                response.Message = login.EmployeeId.ToString();
                response.Data = CreateToken(login);
                response.UserRole = login.Role;
                login.LoginStatus = "Active";
                await _context.SaveChangesAsync();
            }

            return response;
        }

        public async Task<ServiceResponse<int>> Register(UserMasterT user, string password)
        {
            if (await UserExists(user.Username))
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.UserMasterT.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = user.Id, Message = "Registration successful!" };
        }

        //[HttpPut("Putaccount/{id}")]
        public async Task<ServiceResponse<int>> Putaccount(int id)
        {
            var db = await _context.UserMasterT.Where(s => s.EmployeeId == id).FirstOrDefaultAsync();
            if (db == null)
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "Not Found."
                };
            }

            db.LoginStatus = "Inactive";

            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = db.Id, Message = "Successful!" };
        }

        public async Task<ServiceResponse<int>> Putpassword(int id, string newpass)
        {
            var db = await _context.UserMasterT.Where(s => s.EmployeeId == id).FirstOrDefaultAsync();
            if (db == null)
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "Not Found."
                };
            }

            CreatePasswordHash(newpass, out byte[] passwordHash, out byte[] passwordSalt);

            db.PasswordHash = passwordHash;
            db.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync();

            return new ServiceResponse<int> { Data = db.Id, Message = "Successful!" };
        }
    }
}