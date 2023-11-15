using System.Net.Http.Json;

namespace HrisApp.Client.Services.AuthService
{
#nullable disable
    public class AuthService : IAuthService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public List<UserMasterT> UserMasterTs { get; set; } = new List<UserMasterT>();

        public AuthService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public Task<ServiceResponse<bool>> ChangePassword(UserLoginDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<bool> IsUsernameExist(string username)
        {
            return await _http.GetFromJsonAsync<bool>($"api/Auth/UserExists?username={username}");
        }

        public async Task<ServiceResponse<string>> Login(UserMasterT request)
        {
            var result = await _http.PostAsJsonAsync("api/Auth/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<int>> Register(UserLoginDto request)
        {
            var result = await _http.PostAsJsonAsync("api/Auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task GetUsers()
        {
            var result = await _http.GetFromJsonAsync<List<UserMasterT>>("api/Auth/GetUserList");
            if (result != null)
            {
                UserMasterTs = result;
            }
        }

        
    }
}
