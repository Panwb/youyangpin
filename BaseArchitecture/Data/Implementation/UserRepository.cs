using System.Data;
using System.Collections.Generic;
using Infrastructure.Repository;
using WebAPI.Common;
using WebAPI.Entities;

namespace WebAPI.Data
{
    /// <summary>
    /// Summary description for UserRepository.
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
	{
        private readonly IWorkContext _workContext;

	    public UserRepository(IWorkContext workContext)
	    {
	        this._workContext = workContext;
	    }

	}
}

