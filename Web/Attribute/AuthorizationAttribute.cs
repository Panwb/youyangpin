﻿using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Routing;
using System.Web.Security;
using YYP.ComLib;

namespace YYP.Web
{
    public class AuthorizationAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var user = HttpContext.Current.Session[SessionKey.LoginUser];
            //if(user == null)
            //{
            //    return false;
            //}
            return true;
        }
    }
}