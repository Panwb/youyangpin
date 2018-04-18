using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using YYP.ComLib;
using YYP.ComLib.Services;
using YYP.Dto;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
    public class UserService : ServiceBase<User>, IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IWorkContext _workContext;


        public UserService(IUserRepository userRepository, IWorkContext workContext)
        {
            this._userRepository = userRepository;

            this._workContext = workContext;

        }

        public UserServiceResult Register(RegisterDto dto)
        {
            return ExecuteCommand(() =>
            {
                var user = new User() { Account = dto.Telphone, TelPhone = dto.Telphone, Pwd = dto.Password, UserType = UserType.StudioHost };

                var existUserResult = GetUser(user.Account);
                if (existUserResult.User != null)
                {
                    var result = new UserServiceResult();
                    result.ViolationType = ViolationType.Validation;
                    result.RuleViolations.Add(new RuleViolation("account", "用户已存在"));
                    return result;
                }

                user.Pwd = Ezg.Sell.Common.Encrypt.MD5Encrypt.Encrypt(user.Pwd);
                user.IsAdmin = false;
                user.UserState = (byte)UserState.Enabled;
                user.CreatePerson = _workContext.AccountName;
                _userRepository.Add(user);
                return new UserServiceResult(user);
            });
        }

        public UserServiceResult GetUser(string accountName, string password)
        {
            return ExecuteCommand(() =>
            {
                var encryptPassword = Ezg.Sell.Common.Encrypt.MD5Encrypt.Encrypt(password);
                var users = _userRepository.GetAll();
                var user = users.FirstOrDefault(u => u.Account == accountName && u.Pwd == encryptPassword && u.UserState == (byte)UserState.Enabled);
                return new UserServiceResult(user);
            });
        }

        private UserServiceResult GetUser(string accountName)
        {
            return ExecuteCommand(() =>
            {
                var users = _userRepository.GetAll();
                var user = users.FirstOrDefault(u => u.Account == accountName && u.UserState == (byte)UserState.Enabled);
                return new UserServiceResult(user);
            });
        }

        public UserServiceResult ChangePassword(string userId, string oldPassword, string newPassword)
        {
            var result = new UserServiceResult();
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrWhiteSpace(newPassword))
            {
                result.RuleViolations.Add(new RuleViolation("password", "密码不能为空"));
                return result;
            }

            var user = _userRepository.GetById(userId);
            if (user.Pwd != Ezg.Sell.Common.Encrypt.MD5Encrypt.Encrypt(oldPassword))
            {
                result.RuleViolations.Add(new RuleViolation("oldPassword", "原密码不正确"));
                return result;
            }

            user.Pwd = Ezg.Sell.Common.Encrypt.MD5Encrypt.Encrypt(newPassword);
            _userRepository.Update(user);
            result.User = user;

            return result;
        }

        public UserServiceResult GetByAccount(string accountName)
        {
            var userResult = new UserServiceResult();
            var users = _userRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Account == accountName && u.UserState == (byte)UserState.Enabled);
            if (user == null)
            {
                userResult.RuleViolations.Add(new RuleViolation("", "用户不存在"));
            }
            userResult.User = user;
            return userResult;
        }

        public UserServiceResult ResetPassword(string accountName, string newPassword)
        {
            return ExecuteCommand(() =>
            {
                var userResult = GetByAccount(accountName);
                if (userResult.HasViolation)
                {
                    return userResult;
                }
                var user = userResult.User;
                user.Pwd = Ezg.Sell.Common.Encrypt.MD5Encrypt.Encrypt(newPassword);
                _userRepository.Update(user);
                return new UserServiceResult(user);
            });
        }
    }
}
