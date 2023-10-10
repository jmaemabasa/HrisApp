using HrisApp.Shared.Models.User;

namespace HrisApp.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserLoginDto request);
        Task<ServiceResponse<string>> Login(UserLoginDto request);
        Task<ServiceResponse<bool>> ChangePassword(UserLoginDto request);
        Task<bool> IsUserAuthenticated();
    }
}
