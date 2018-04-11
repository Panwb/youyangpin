using System;
using System.Collections.Generic;
using System.Linq;
using Kingston.ComLib.Logging;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities;
using WebAPI.Data;

namespace WebAPI.Services
{
	public class ShopService : ServiceBase<Shop>,IShopService
	{
		private readonly ILogger _logger;
		private readonly IShopRepository _shopRepository;
		
		public ShopService(IShopRepository shopRepository, ILogger logger)
		{
			this._shopRepository = shopRepository;
			this._logger = logger;
		}
		#region CRUD
		/// <summary>
		/// Add a new Shop
		/// </summary>
		/// <param name="inShop"></param>
		/// <returns></returns>
		public ShopServiceResult Add(Shop inShop)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _shopRepository.Add(inShop);                                            
                                            return new ShopServiceResult();
                                        });			
		}		
		
		/// <summary>
		/// Update Shop 
		/// </summary>
		/// <param name="inShop"></param>
		/// <returns></returns>
		public ShopServiceResult Update(Shop inShop)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _shopRepository.Update(inShop);                                            
                                            return new ShopServiceResult();
                                        });
		}
        
		/// <summary>
		/// delete Shop
		/// </summary>
		/// <param name="inShopId"></param>
		/// <returns></returns>
		public ShopServiceResult Delete(int inShopId)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _shopRepository.Delete(inShopId);
                                            return new ShopServiceResult();
                                        });
		}
        
		/// <summary>
		/// select a Shop by ID
		/// </summary>
		/// <param name="inShopId"></param>
		/// <returns></returns>
		public ShopServiceResult GetById(int inShopId)
		{
            return ExecuteCommand(() =>
                new ShopServiceResult(_shopRepository.GetById(inShopId))
            );
		}
        
		/// <summary>
		/// select all Shop
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Shop> GetAll()
		{
			try
			{
				return _shopRepository.GetAll();
			}
			catch(Exception ex)
			{
				_logger.Error(ex.ToString());
			}
			return Enumerable.Empty<Shop>();
		}

		#endregion
        
        public ShopServiceResult Save(Shop inShop)
        {
            return ExecuteCommand(() =>
            {
                var result = new ShopServiceResult();
                switch(inShop.Action)
                {
                    case EntityAction.New:
                        result = Add(inShop);
                        break;
                    case EntityAction.Updated:
                        result = Update(inShop);
                        break;
                    case EntityAction.Deleted:
                        result = Delete(inShop.ShopId);
                        break;
                    case EntityAction.UnChanged:                        
                    case EntityAction.UnAttach:                        
                        break;
                }
                return result;
            });
        }
        
        public IEnumerable<Shop> GetPagedShop(int? pageIndex
                                    , int itemsPerPage
                                    , string sortField
                                    , string sort
                                    , out int recordCount)
		{
			return _shopRepository.GetPagedShop(
				pageIndex, itemsPerPage, sortField, sort, out recordCount);
		}
        
	}
}

