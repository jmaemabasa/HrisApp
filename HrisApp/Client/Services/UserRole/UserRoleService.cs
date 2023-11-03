using static System.Net.WebRequestMethods;

namespace HrisApp.Client.Services.UserRole
{
#nullable disable
    public class UserRoleService : IUserRoleService
    {
        private readonly HttpClient _http;
        public UserRoleService(HttpClient http)
        {
            _http = http;
        }

        public List<UserRoleT> UserRoleTs { get; set; }

        public async Task GetUserRole()
        {
            var result = await _http.GetFromJsonAsync<List<UserRoleT>>("api/Role");
            if (result != null)
                UserRoleTs = result;
        }
    }
}
