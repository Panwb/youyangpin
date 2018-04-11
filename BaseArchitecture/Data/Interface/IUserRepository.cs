using System.Data;
using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public interface IUserRepository : IRepository<User>
	{
        
    
		IEnumerable<User> GetPagedUser(int? pageIndex
                                                        , int itemsPerPage
                                                        , string sortField
                                                        , string sort
                                                        , out int recordCount);
                                                                
        DataTable GetHistoryByColumns(int inGUID);
	}
}
