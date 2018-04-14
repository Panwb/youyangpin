﻿using Infrastructure.Helper;
using Microsoft.AspNetCore.Http;
using YYP.Entities;

namespace YYP.ComLib.Services
{
    public interface IWorkContext
    {
        User CurrentUser { get; }

        string AccountName { get; }
    }

    public class DefaultWorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public DefaultWorkContext(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public User CurrentUser
        {
            get
            {
                if(_contextAccessor.HttpContext.Session.TryGetValue(GlobalConstants.UserSessionKey, out var userBytes))
                {
                    return ByteConvertHelper.Bytes2Object<User>(userBytes);
                }
                return null;
            }
        }

        public string AccountName => CurrentUser?.Account;
    }
}