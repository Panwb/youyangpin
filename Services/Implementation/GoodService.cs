using System.Collections.Generic;
using Infrastructure.Services;
using YYP.ComLib;
using YYP.ComLib.Services;
using YYP.Dto;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class GoodService : ServiceBase<Good>,IGoodService
	{
		private readonly IGoodRepository _goodRepository;
        private readonly IStudioHostRepository _studioHostRepository;
        private readonly IShopRepository _shopRepository;
        private readonly IWorkContext _workContext;

        public GoodService(IGoodRepository goodRepository, IStudioHostRepository studioHostRepository, IShopRepository shopRepository, IWorkContext workContext)
        {
			this._goodRepository = goodRepository;
            this._studioHostRepository = studioHostRepository;
            this._shopRepository = shopRepository;
            this._workContext = workContext;
		}

        public IEnumerable<GoodStatistic> GetStatistics()
        {
            var goodStatistics = new List<GoodStatistic>() { new GoodStatistic() { VerticalFieldCode = "全部", Quantity = 0 } };
            var results = _goodRepository.GetStatistics(CheckStatus.Pass);
            foreach(var item in results)
            {
                goodStatistics[0].Quantity += item.Quantity;
                goodStatistics.Add(item);
            }
            return goodStatistics;
        }

        public IEnumerable<Good> GetPagedGood(string goodsName, string verticalFieldCode, string activityType, int? sales, decimal? lowDailyPrice, decimal? highDailyPrice, decimal? commissionRatio, int? pageIndex, int itemsPerPage, string sortField, string sort, out int recordCount)
        {
            return _goodRepository.GetPagedGood(goodsName, verticalFieldCode, activityType, sales, lowDailyPrice, highDailyPrice, commissionRatio, CheckStatus.Pass,
                pageIndex, itemsPerPage, sortField, sort, out recordCount);
        }

        public GoodDetailDto GetDetail(string goodsId)
        {
            var goodDetail = new GoodDetailDto();
            var good = _goodRepository.GetById(goodsId);
            goodDetail.CurrentGood = good;

            var user = _workContext.CurrentUser;
            if (user != null)
            {
                var studioHost = _studioHostRepository.GetById(user.GUID);
                goodDetail.StudioHost = studioHost;
            }

            if (good != null)
            {
                goodDetail.RequestQuantity = _goodRepository.GetRequestQuantity(good.GoodsId);
                goodDetail.Shop = _shopRepository.GetById(good.ShopId);
                goodDetail.RelatedGoods = _goodRepository.GetRelatedGoods(good.ShopId, good.ActivityType);
            }

            return goodDetail;
        }

        public IEnumerable<string> GetActivityTypes()
        {
            return _goodRepository.GetActivityTypes();
        }
    }
}

