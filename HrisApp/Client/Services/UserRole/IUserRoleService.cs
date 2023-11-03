namespace HrisApp.Client.Services.UserRole
{
    public interface IUserRoleService
    {
        List<UserRoleT> UserRoleTs { get; set; }
        Task GetUserRole();
    }
}
