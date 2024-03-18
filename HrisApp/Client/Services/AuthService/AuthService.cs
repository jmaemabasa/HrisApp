using System.Security.Cryptography;

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

        public async Task<bool> IsPassMatched(int id, string inputpass)
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<bool>($"api/Auth/IsPassMatched?id={id}&inputpass={inputpass}");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error calling authservice: {ex}");
                return false;
            }
        }

        public async Task<List<string>> GetAllEmployeeID()
        {
            var result = await _httpClient.GetFromJsonAsync<List<string>>("api/Auth/GetAllEmployeeID");
            return result;
        }

        public async Task<UserMasterT> GetSingleObj(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<UserMasterT>($"api/Auth/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("user not found");
        }

        public async Task UpdateObj(UserMasterT model)
        {
            await _httpClient.PutAsJsonAsync("api/Auth/UpdateObj", model);
        }
    }
}