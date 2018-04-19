
using System;
using System.Collections.Generic;
using Infrastructure.DomainModel;

namespace YYP.Entities
{
    public class OrderDto
    {
        #region Public Properties

        public string OrderID { get; set; }
        public string ShopName { get; set; }
        public string WangWangNo { get; set; }
        public string LinkmanName { get; set; }
        public string LinkmanPhone { get; set; }
        public string OrderNo { get; set; }
        public string OrderStatus { get; set; }
        public string DirectionalPlanStatus { get; set; }
        public IEnumerable<Good> Goods { get; set; }

        #endregion
    }
}