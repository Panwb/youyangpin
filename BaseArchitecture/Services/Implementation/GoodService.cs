using System;
using System.Collections.Generic;
using System.Linq;
using Kingston.ComLib.Logging;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities;
using WebAPI.Data;

namespace WebAPI.Services
{
	public class GoodService : ServiceBase<Good>,IGoodService
	{
		private readonly ILogger _logger;
		private readonly IGoodRepository _goodRepository;
		
		public GoodService(IGoodRepository goodRepository, ILogger logger)
		{
			this._goodRepository = goodRepository;
			this._logger = logger;
		}
		#region CRUD
		/// <summary>
		/// Add a new Good
		/// </summary>
		/// <param name="inGood"></param>
		/// <returns></returns>
		public GoodServiceResult Add(Good inGood)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _goodRepository.Add(inGood);                                            
                                            return new GoodServiceResult();
                                        });			
		}		
		
		/// <summary>
		/// Update Good 
		/// </summary>
		/// <param name="inGood"></param>
		/// <returns></returns>
		public GoodServiceResult Update(Good inGood)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _goodRepository.Update(inGood);                                            
                                            return new GoodServiceResult();
                                        });
		}
        
		/// <summary>
		/// delete Good
		/// </summary>
		/// <param name="inGoodsId"></param>
		/// <returns></returns>
		public GoodServiceResult Delete(int inGoodsId)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _goodRepository.Delete(inGoodsId);
                                            return new GoodServiceResult();
                                        });
		}
        
		/// <summary>
		/// select a Good by ID
		/// </summary>
		/// <param name="inGoodsId"></param>
		/// <returns></returns>
		public GoodServiceResult GetById(int inGoodsId)
		{
            return ExecuteCommand(() =>
                new GoodServiceResult(_goodRepository.GetById(inGoodsId))
            );
		}
        
		/// <summary>
		/// select all Good
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Good> GetAll()
		{
			try
			{
				return _goodRepository.GetAll();
			}
			catch(Exception ex)
			{
				_logger.Error(ex.ToString());
			}
			return Enumerable.Empty<Good>();
		}

		#endregion
        
        public GoodServiceResult Save(Good inGood)
        {
            return ExecuteCommand(() =>
            {
                var result = new GoodServiceResult();
                switch(inGood.Action)
                {
                    case EntityAction.New:
                        result = Add(inGood);
                        break;
                    case EntityAction.Updated:
                        result = Update(inGood);
                        break;
                    case EntityAction.Deleted:
                        result = Delete(inGood.GoodsId);
                        break;
                    case EntityAction.UnChanged:                        
                    case EntityAction.UnAttach:                        
                        break;
                }
                return result;
            });
        }
        
        public IEnumerable<Good> GetPagedGood(int? pageIndex
                                    , int itemsPerPage
                                    , string sortField
                                    , string sort
                                    , out int recordCount)
		{
			return _goodRepository.GetPagedGood(
				pageIndex, itemsPerPage, sortField, sort, out recordCount);
		}
        
	}
}

