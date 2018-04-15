using Infrastructure.Helper;
using System.Web;
using YYP.Entities;

namespace YYP.ComLib.Services
{
    public interface IWorkContext
    {
        string AccountName { get; }
    }

    public class DefaultWorkContext : IWorkContext
    {
        public string AccountName
        {
            get
            {
                var user = HttpContext.Current.User;
                if(user != null)
                {
                    return user.Identity.Name;
                }
                return null;
            }
        }
    }
}
