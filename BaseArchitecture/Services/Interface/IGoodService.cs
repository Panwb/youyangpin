using System.Collections.Generic;
using Infrastructure.Services;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IGoodService : IService<Good>
	{				
		GoodServiceResult Add(Good inGood);
		
		GoodServiceResult Update(Good inGood);
		
		GoodServiceResult Delete(int inGoodsId);
		
		GoodServiceResult GetById(int inGood);	
		
		IEnumerable<Good> GetAll();
        
        GoodServiceResult Save(Good inGood);

        IEnumerable<Good> GetPagedGood(int? pageIndex
                                         , int itemsPerPage
                                         , string sortField
                                         , string sort
                                         , out int recordCount);
	}
}

