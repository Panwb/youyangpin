using System.Collections.Generic;
using Infrastructure.Services;

using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class StudioHostService : ServiceBase<StudioHost>,IStudioHostService
	{
		
		private readonly IStudioHostRepository _studioHostRepository;
		
		public StudioHostService(IStudioHostRepository studioHostRepository)
		{
			this._studioHostRepository = studioHostRepository;
			
		}
        
	}
}

