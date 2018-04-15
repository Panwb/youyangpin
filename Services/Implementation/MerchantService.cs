using Infrastructure.Services;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
    public class MerchantService : ServiceBase<Merchant>,IMerchantService
	{
		private readonly IMerchantRepository _merchantRepository;
		
		public MerchantService(IMerchantRepository merchantRepository)
		{
			this._merchantRepository = merchantRepository;
		}
        
	}
}

