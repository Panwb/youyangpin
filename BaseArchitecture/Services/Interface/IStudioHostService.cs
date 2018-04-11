using System.Collections.Generic;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities; 

namespace WebAPI.Services
{
	public interface IStudioHostService : IService<StudioHost>
	{				
		StudioHostServiceResult Add(StudioHost inStudioHost);
		
		StudioHostServiceResult Update(StudioHost inStudioHost);
		
		StudioHostServiceResult Delete(int inUserId);
		
		StudioHostServiceResult GetById(int inStudioHost);	
		
		IEnumerable<StudioHost> GetAll();
        
        StudioHostServiceResult Save(StudioHost inStudioHost);

        IEnumerable<StudioHost> GetPagedStudioHost(int? pageIndex
                                         , int itemsPerPage
                                         , string sortField
                                         , string sort
                                         , out int recordCount);
	}
}

