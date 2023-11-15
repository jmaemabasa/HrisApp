namespace HrisApp.Client.Services.AuthService
{
    public interface IAuthService
    {
        List<UserMasterT> UserMasterTs { get; set; }
        Task<ServiceResponse<int>> Register(UserLoginDto request);
        Task<ServiceResponse<string>> Login(UserMasterT request);
        Task<ServiceResponse<bool>> ChangePassword(UserLoginDto request);
        Task<bool> IsUserAuthenticated();
        Task<bool> IsUsernameExist(string username);

        Task GetUsers();
    }
}

