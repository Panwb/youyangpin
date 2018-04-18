
using System;
using Infrastructure.DomainModel;

namespace YYP.Entities
{
    public class StudioHostDto
    {
        #region Public Properties

        public string StudioHostName { get; set; }
        public string TKName { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int ShoeSize { get; set; }
        public string ClothesSize { get; set; }
        public string Address { get; set; }
        public string LinkmanName { get; set; }
        public string LinkmanPhone { get; set; }
        public string WeChat { get; set; }
        public string QQ { get; set; }
        public string VerticalFieldCode { get; set; }
        public string AlipayAccount { get; set; }
        public DateTime? DailyBeginTime { get; set; }
        public DateTime? DailyEndTime { get; set; }

        #endregion
    }
}