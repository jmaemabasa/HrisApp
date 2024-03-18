namespace HrisApp.Client.Services.AuthService
{
    public interface IAuthService
    {
        List<UserMasterT> UserMasterTs { get; set; }

        Task<ServiceResponse<int>> Register(UserLoginDto request);

        Task<ServiceResponse<int>> UpdateLoginStatus(int id);

        Task<ServiceResponse<int>> UpdatePassword(int id, string newpass);

        Task<ServiceResponse<string>> Login(UserMasterT request);

        Task<ServiceResponse<bool>> ChangePassword(UserLoginDto request);

        Task<bool> IsUserAuthenticated();

        Task<bool> IsUsernameExist(string username);

        Task GetUsers();

        Task<List<string>> GetAllEmployeeID();

        Task<UserMasterT> GetSingleObj(int id);

        Task UpdateObj(UserMasterT model);

        Task<bool> IsPassMatched(int id, string inputpass);
    }
}