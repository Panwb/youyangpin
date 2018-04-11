using System;
using System.Collections.Generic;
using System.Linq;
using Kingston.ComLib.Logging;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities;
using WebAPI.Data;

namespace WebAPI.Services
{
	public class OrderService : ServiceBase<Order>,IOrderService
	{
		private readonly ILogger _logger;
		private readonly IOrderRepository _orderRepository;
		
		public OrderService(IOrderRepository orderRepository, ILogger logger)
		{
			this._orderRepository = orderRepository;
			this._logger = logger;
		}
		#region CRUD
		/// <summary>
		/// Add a new Order
		/// </summary>
		/// <param name="inOrder"></param>
		/// <returns></returns>
		public OrderServiceResult Add(Order inOrder)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _orderRepository.Add(inOrder);                                            
                                            return new OrderServiceResult();
                                        });			
		}		
		
		/// <summary>
		/// Update Order 
		/// </summary>
		/// <param name="inOrder"></param>
		/// <returns></returns>
		public OrderServiceResult Update(Order inOrder)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _orderRepository.Update(inOrder);                                            
                                            return new OrderServiceResult();
                                        });
		}
        
		/// <summary>
		/// delete Order
		/// </summary>
		/// <param name="inOrderId"></param>
		/// <returns></returns>
		public OrderServiceResult Delete(int inOrderId)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _orderRepository.Delete(inOrderId);
                                            return new OrderServiceResult();
                                        });
		}
        
		/// <summary>
		/// select a Order by ID
		/// </summary>
		/// <param name="inOrderId"></param>
		/// <returns></returns>
		public OrderServiceResult GetById(int inOrderId)
		{
            return ExecuteCommand(() =>
                new OrderServiceResult(_orderRepository.GetById(inOrderId))
            );
		}
        
		/// <summary>
		/// select all Order
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Order> GetAll()
		{
			try
			{
				return _orderRepository.GetAll();
			}
			catch(Exception ex)
			{
				_logger.Error(ex.ToString());
			}
			return Enumerable.Empty<Order>();
		}

		#endregion
        
        public OrderServiceResult Save(Order inOrder)
        {
            return ExecuteCommand(() =>
            {
                var result = new OrderServiceResult();
                switch(inOrder.Action)
                {
                    case EntityAction.New:
                        result = Add(inOrder);
                        break;
                    case EntityAction.Updated:
                        result = Update(inOrder);
                        break;
                    case EntityAction.Deleted:
                        result = Delete(inOrder.OrderId);
                        break;
                    case EntityAction.UnChanged:                        
                    case EntityAction.UnAttach:                        
                        break;
                }
                return result;
            });
        }
        
        public IEnumerable<Order> GetPagedOrder(int? pageIndex
                                    , int itemsPerPage
                                    , string sortField
                                    , string sort
                                    , out int recordCount)
		{
			return _orderRepository.GetPagedOrder(
				pageIndex, itemsPerPage, sortField, sort, out recordCount);
		}
        
	}
}

