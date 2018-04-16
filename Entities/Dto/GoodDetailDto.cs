using System.Collections.Generic;
using YYP.Entities;

namespace YYP.Dto
{
    public class GoodDetailDto
    {
        public Shop Shop { get; set; }
        public StudioHost StudioHost { get; set; }
        public Good CurrentGood { get; set; }
        public int RequestQuantity { get; set; }
        public IEnumerable<Good> RelatedGoods { get; set; }
    }
}