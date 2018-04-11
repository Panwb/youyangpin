using System.Collections.Generic;
using Infrastructure.Services;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IUserService : IService<User>
	{				
		UserServiceResult Add(User inUser);
		
		UserServiceResult Update(User inUser);
		
		UserServiceResult Delete(int inGUID);
		
		UserServiceResult GetById(int inUser);	
		
		IEnumerable<User> GetAll();
        
        UserServiceResult Save(User inUser);

        IEnumerable<User> GetPagedUser(int? pageIndex
                                         , int itemsPerPage
                                         , string sortField
                                         , string sort
                                         , out int recordCount);
	}
}

