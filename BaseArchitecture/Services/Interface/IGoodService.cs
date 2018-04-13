using System.Collections.Generic;
using Infrastructure.Services;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IGoodService : IService<Good>
	{				
        IEnumerable<Good> GetPagedGood(int? pageIndex
                                         , int itemsPerPage
                                         , string sortField
                                         , string sort
                                         , out int recordCount);
	}
}

