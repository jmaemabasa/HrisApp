using static System.Net.WebRequestMethods;

namespace HrisApp.Client.Services.UserRole
{
#nullable disable
    public class UserRoleService : IUserRoleService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public UserRoleService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<UserRoleT> UserRoleTs { get; set; }

        public async Task GetUserRole()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserRoleT>>("api/Role");
            if (result != null)
                UserRoleTs = result;
        }
    }
}
