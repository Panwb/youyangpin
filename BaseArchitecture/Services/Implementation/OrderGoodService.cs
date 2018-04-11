using System;
using System.Collections.Generic;
using System.Linq;
using Kingston.ComLib.Logging;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities;
using WebAPI.Data;

namespace WebAPI.Services
{
	public class OrderGoodService : ServiceBase<OrderGood>,IOrderGoodService
	{
		private readonly ILogger _logger;
		private readonly IOrderGoodRepository _orderGoodRepository;
		
		public OrderGoodService(IOrderGoodRepository orderGoodRepository, ILogger logger)
		{
			this._orderGoodRepository = orderGoodRepository;
			this._logger = logger;
		}
		#region CRUD
		/// <summary>
		/// Add a new OrderGood
		/// </summary>
		/// <param name="inOrderGood"></param>
		/// <returns></returns>
		public OrderGoodServiceResult Add(OrderGood inOrderGood)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _orderGoodRepository.Add(inOrderGood);                                            
                                            return new OrderGoodServiceResult();
                                        });			
		}		
		
		/// <summary>
		/// Update OrderGood 
		/// </summary>
		/// <param name="inOrderGood"></param>
		/// <returns></returns>
		public OrderGoodServiceResult Update(OrderGood inOrderGood)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _orderGoodRepository.Update(inOrderGood);                                            
                                            return new OrderGoodServiceResult();
                                        });
		}
        
		/// <summary>
		/// delete OrderGood
		/// </summary>
		/// <param name="inOrderGoodsId"></param>
		/// <returns></returns>
		public OrderGoodServiceResult Delete(int inOrderGoodsId)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _orderGoodRepository.Delete(inOrderGoodsId);
                                            return new OrderGoodServiceResult();
                                        });
		}
        
		/// <summary>
		/// select a OrderGood by ID
		/// </summary>
		/// <param name="inOrderGoodsId"></param>
		/// <returns></returns>
		public OrderGoodServiceResult GetById(int inOrderGoodsId)
		{
            return ExecuteCommand(() =>
                new OrderGoodServiceResult(_orderGoodRepository.GetById(inOrderGoodsId))
            );
		}
        
		/// <summary>
		/// select all OrderGood
		/// </summary>
		/// <returns></returns>
		public IEnumerable<OrderGood> GetAll()
		{
			try
			{
				return _orderGoodRepository.GetAll();
			}
			catch(Exception ex)
			{
				_logger.Error(ex.ToString());
			}
			return Enumerable.Empty<OrderGood>();
		}

		#endregion
        
        public OrderGoodServiceResult Save(OrderGood inOrderGood)
        {
            return ExecuteCommand(() =>
            {
                var result = new OrderGoodServiceResult();
                switch(inOrderGood.Action)
                {
                    case EntityAction.New:
                        result = Add(inOrderGood);
                        break;
                    case EntityAction.Updated:
                        result = Update(inOrderGood);
                        break;
                    case EntityAction.Deleted:
                        result = Delete(inOrderGood.OrderGoodsId);
                        break;
                    case EntityAction.UnChanged:                        
                    case EntityAction.UnAttach:                        
                        break;
                }
                return result;
            });
        }
        
        public IEnumerable<OrderGood> GetPagedOrderGood(int? pageIndex
                                    , int itemsPerPage
                                    , string sortField
                                    , string sort
                                    , out int recordCount)
		{
			return _orderGoodRepository.GetPagedOrderGood(
				pageIndex, itemsPerPage, sortField, sort, out recordCount);
		}
        
	}
}

