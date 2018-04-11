using System;
using System.Collections.Generic;
using System.Linq;
using Kingston.ComLib.Logging;
using Kingston.ComLib.DomainModel;
using WebAPI.Entities;
using WebAPI.Data;

namespace WebAPI.Services
{
	public class MerchantService : ServiceBase<Merchant>,IMerchantService
	{
		private readonly ILogger _logger;
		private readonly IMerchantRepository _merchantRepository;
		
		public MerchantService(IMerchantRepository merchantRepository, ILogger logger)
		{
			this._merchantRepository = merchantRepository;
			this._logger = logger;
		}
		#region CRUD
		/// <summary>
		/// Add a new Merchant
		/// </summary>
		/// <param name="inMerchant"></param>
		/// <returns></returns>
		public MerchantServiceResult Add(Merchant inMerchant)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _merchantRepository.Add(inMerchant);                                            
                                            return new MerchantServiceResult();
                                        });			
		}		
		
		/// <summary>
		/// Update Merchant 
		/// </summary>
		/// <param name="inMerchant"></param>
		/// <returns></returns>
		public MerchantServiceResult Update(Merchant inMerchant)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _merchantRepository.Update(inMerchant);                                            
                                            return new MerchantServiceResult();
                                        });
		}
        
		/// <summary>
		/// delete Merchant
		/// </summary>
		/// <param name="inUserId"></param>
		/// <returns></returns>
		public MerchantServiceResult Delete(int inUserId)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _merchantRepository.Delete(inUserId);
                                            return new MerchantServiceResult();
                                        });
		}
        
		/// <summary>
		/// select a Merchant by ID
		/// </summary>
		/// <param name="inUserId"></param>
		/// <returns></returns>
		public MerchantServiceResult GetById(int inUserId)
		{
            return ExecuteCommand(() =>
                new MerchantServiceResult(_merchantRepository.GetById(inUserId))
            );
		}
        
		/// <summary>
		/// select all Merchant
		/// </summary>
		/// <returns></returns>
		public IEnumerable<Merchant> GetAll()
		{
			try
			{
				return _merchantRepository.GetAll();
			}
			catch(Exception ex)
			{
				_logger.Error(ex.ToString());
			}
			return Enumerable.Empty<Merchant>();
		}

		#endregion
        
        public MerchantServiceResult Save(Merchant inMerchant)
        {
            return ExecuteCommand(() =>
            {
                var result = new MerchantServiceResult();
                switch(inMerchant.Action)
                {
                    case EntityAction.New:
                        result = Add(inMerchant);
                        break;
                    case EntityAction.Updated:
                        result = Update(inMerchant);
                        break;
                    case EntityAction.Deleted:
                        result = Delete(inMerchant.UserId);
                        break;
                    case EntityAction.UnChanged:                        
                    case EntityAction.UnAttach:                        
                        break;
                }
                return result;
            });
        }
        
        public IEnumerable<Merchant> GetPagedMerchant(int? pageIndex
                                    , int itemsPerPage
                                    , string sortField
                                    , string sort
                                    , out int recordCount)
		{
			return _merchantRepository.GetPagedMerchant(
				pageIndex, itemsPerPage, sortField, sort, out recordCount);
		}
        
	}
}

