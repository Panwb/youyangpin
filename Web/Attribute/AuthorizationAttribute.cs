using System;
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
            var session = HttpContext.Current.Session;
            if(session == null || session[GlobalConstants.UserSessionKey] == null)
            {
                return false;
            }
            return true;
        }
    }
}