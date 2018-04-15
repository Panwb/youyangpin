using Infrastructure.Services;
using YYP.Dto;
using YYP.Entities;

namespace YYP.Services
{
    public interface IUserService : IService<User>
    {
        UserServiceResult Register(RegisterDto dto);
        UserServiceResult GetUser(string accountName, string password);
        UserServiceResult ChangePassword(string oldPassword, string newPassword);
    }
}

