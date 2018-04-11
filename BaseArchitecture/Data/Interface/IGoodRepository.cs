using System.Data;
using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public interface IGoodRepository : IRepository<Good>
	{
        
    
		IEnumerable<Good> GetPagedGood(int? pageIndex
                                                        , int itemsPerPage
                                                        , string sortField
                                                        , string sort
                                                        , out int recordCount);
                                                                
        DataTable GetHistoryByColumns(int inGoodsId);
	}
}
