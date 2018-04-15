using Infrastructure.Helper;
using System.Web;
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
        public string AccountName => CurrentUser?.Account;

        public User CurrentUser => HttpContext.Current.Session[SessionKey.LoginUser] as User;
    }
}
