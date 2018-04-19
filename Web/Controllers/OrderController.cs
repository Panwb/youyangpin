using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using YYP.ComLib.Services;
using YYP.Entities;
using YYP.Services;
using YYP.Web;

namespace YYP.Controllers
{   
    public class OrderController : ApiController
    {
        #region Construction
        private readonly IWorkContext _workContext;
        private readonly IOrderService _orderService;
        
        public OrderController(IOrderService orderService,IWorkContext workContext)
        {   
            this._orderService = orderService;
            this._workContext= workContext;
        }

        #endregion

        [Authorization]
        [HttpGet]
        public IEnumerable<OrderDto> GetOrders(string orderStatus)
        {
            var user = _workContext.CurrentUser;
            return _orderService.GetOrderByUserId(user.GUID, orderStatus);
        }
    }
}




