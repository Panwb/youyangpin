using System;
using System.Collections.Generic;
using System.Linq;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using Microsoft.Extensions.Logging;
using WebAPI.Entities;
using WebAPI.Data;

namespace WebAPI.Services
{
	public class UserService : ServiceBase<User>, IUserService
	{
		private readonly ILogger _logger;
		private readonly IUserRepository _userRepository;
		
		public UserService(IUserRepository userRepository, ILogger logger)
		{
			this._userRepository = userRepository;
			this._logger = logger;
		}

		#region CRUD
		/// <summary>
		/// Add a new User
		/// </summary>
		/// <param name="inUser"></param>
		/// <returns></returns>
		public UserServiceResult Add(User inUser)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _userRepository.Add(inUser);
                                            return new UserServiceResult();
                                        });			
		}		
		
		/// <summary>
		/// Update User 
		/// </summary>
		/// <param name="inUser"></param>
		/// <returns></returns>
		public UserServiceResult Update(User inUser)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _userRepository.Update(inUser);                                            
                                            return new UserServiceResult();
                                        });
		}
        
		/// <summary>
		/// delete User
		/// </summary>
		/// <param name="inGUID"></param>
		/// <returns></returns>
		public UserServiceResult Delete(int inGUID)
		{
            return ExecuteCommand ( () =>
                                        {
                                            _userRepository.Delete(inGUID);
                                            return new UserServiceResult();
                                        });
		}
        
		/// <summary>
		/// select a User by ID
		/// </summary>
		/// <param name="inGUID"></param>
		/// <returns></returns>
		public UserServiceResult GetById(int inGUID)
		{
            return ExecuteCommand(() =>
                new UserServiceResult(_userRepository.GetById(inGUID))
            );
		}
        
		/// <summary>
		/// select all User
		/// </summary>
		/// <returns></returns>
		public IEnumerable<User> GetAll()
		{
			try
			{
				return _userRepository.GetAll();
			}
			catch(Exception ex)
			{
				_logger.LogError(ex.ToString());
			}
			return Enumerable.Empty<User>();
		}

        public bool Login(string accountName, string password)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}

