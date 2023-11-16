﻿namespace HrisApp.Server.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<int>> Register(UserMasterT user, string password);
        Task<ServiceResponse<int>> Putaccount(int id);
        Task<ServiceResponse<int>> Putpassword(int id, string newpass);
        Task<bool> UserExists(string username);
        Task<ServiceResponse<string>> Login(string email, string password);
        Task<ServiceResponse<bool>> ChangesPassword(int userId, string newPassword);
        int GetUserId();
        string GetUserEmail();
        Task<UserMasterT> GetUserByEmail(string email);
    }
}
