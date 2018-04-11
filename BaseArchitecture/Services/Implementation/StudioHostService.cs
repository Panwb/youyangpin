using System;
using System.Collections.Generic;
using System.Linq;
using Kingston.ComLib.Logging;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities;
using WebAPI.Data;

namespace WebAPI.Services
{
	public class StudioHostService : ServiceBase<StudioHost>,IStudioHostService
	{
		private readonly ILogger _logger;
		private readonly IStudioHostRepository _studioHostRepository;
		
		public StudioHostService(IStudioHostRepository studioHostRepository, ILogger logger)
		{
			this._studioHostRepository = studioHostRepository;
			this._logger = logger;
		}
		#region CRUD
		/// <summary>
		/// Add a new StudioHost
		/// </summary>
		/// <param name="inStudioHost"></param>
		/// <returns></returns>
		public StudioHostServiceResult Add(StudioHost inStudioHost)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _studioHostRepository.Add(inStudioHost);                                            
                                            return new StudioHostServiceResult();
                                        });			
		}		
		
		/// <summary>
		/// Update StudioHost 
		/// </summary>
		/// <param name="inStudioHost"></param>
		/// <returns></returns>
		public StudioHostServiceResult Update(StudioHost inStudioHost)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _studioHostRepository.Update(inStudioHost);                                            
                                            return new StudioHostServiceResult();
                                        });
		}
        
		/// <summary>
		/// delete StudioHost
		/// </summary>
		/// <param name="inUserId"></param>
		/// <returns></returns>
		public StudioHostServiceResult Delete(int inUserId)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _studioHostRepository.Delete(inUserId);
                                            return new StudioHostServiceResult();
                                        });
		}
        
		/// <summary>
		/// select a StudioHost by ID
		/// </summary>
		/// <param name="inUserId"></param>
		/// <returns></returns>
		public StudioHostServiceResult GetById(int inUserId)
		{
            return ExecuteCommand(() =>
                new StudioHostServiceResult(_studioHostRepository.GetById(inUserId))
            );
		}
        
		/// <summary>
		/// select all StudioHost
		/// </summary>
		/// <returns></returns>
		public IEnumerable<StudioHost> GetAll()
		{
			try
			{
				return _studioHostRepository.GetAll();
			}
			catch(Exception ex)
			{
				_logger.Error(ex.ToString());
			}
			return Enumerable.Empty<StudioHost>();
		}

		#endregion
        
        public StudioHostServiceResult Save(StudioHost inStudioHost)
        {
            return ExecuteCommand(() =>
            {
                var result = new StudioHostServiceResult();
                switch(inStudioHost.Action)
                {
                    case EntityAction.New:
                        result = Add(inStudioHost);
                        break;
                    case EntityAction.Updated:
                        result = Update(inStudioHost);
                        break;
                    case EntityAction.Deleted:
                        result = Delete(inStudioHost.UserId);
                        break;
                    case EntityAction.UnChanged:                        
                    case EntityAction.UnAttach:                        
                        break;
                }
                return result;
            });
        }
        
        public IEnumerable<StudioHost> GetPagedStudioHost(int? pageIndex
                                    , int itemsPerPage
                                    , string sortField
                                    , string sort
                                    , out int recordCount)
		{
			return _studioHostRepository.GetPagedStudioHost(
				pageIndex, itemsPerPage, sortField, sort, out recordCount);
		}
        
	}
}

