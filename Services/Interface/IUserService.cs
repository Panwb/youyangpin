using Infrastructure.Services;
using YYP.Dto;
using YYP.Entities;

namespace YYP.Services
{
    public interface IUserService : IService<User>
    {
        UserServiceResult Register(RegisterDto dto);
        UserServiceResult GetUser(string accountName, string password);
        UserServiceResult GetByAccount(string accountName);
        UserServiceResult ResetPassword(string accountName, string newPassword);
        UserServiceResult ChangePassword(string userId, string oldPassword, string newPassword);
    }
}

