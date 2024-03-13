namespace HrisApp.Client.Services.AuthService
{
#nullable disable

    public class AuthService : IAuthService
    {
        public HttpClient _httpClient;
        public readonly AuthenticationStateProvider _authStateProvider;

        private MainsService _mainService = new();

        public AuthService(/*AuthenticationStateProvider authStateProvider*/)
        {
            _httpClient = _mainService.Get_Http();
            //_authStateProvider = authStateProvider;
        }

        public List<UserMasterT> UserMasterTs { get; set; } = new List<UserMasterT>();

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
            return await _httpClient.GetFromJsonAsync<bool>($"api/Auth/UserExists?username={username}");
        }

        public async Task<ServiceResponse<string>> Login(UserMasterT request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Auth/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<int>> Register(UserLoginDto request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Auth/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task GetUsers()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserMasterT>>("api/Auth/GetUserList");
            if (result != null)
            {
                UserMasterTs = result;
            }
        }

        public async Task<ServiceResponse<int>> UpdateLoginStatus(int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Auth/UpdateLoginStatus/{id}", id);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<int>> UpdatePassword(int id, string newpass)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Auth/UpdatePassword/{id}", newpass);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
    }
}