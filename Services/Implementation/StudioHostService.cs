using System.Collections.Generic;
using Infrastructure.Services;
using YYP.Dto;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class StudioHostService : ServiceBase<StudioHost>,IStudioHostService
	{
		
		private readonly IStudioHostRepository _studioHostRepository;
        private readonly IUserService _userService;
		
		public StudioHostService(IStudioHostRepository studioHostRepository, IUserService userService)
		{
			this._studioHostRepository = studioHostRepository;
            this._userService = userService;
		}

        public StudioHostServiceResult Register(RegisterDto dto)
        {
            return ExecuteCommand(() =>
            {
                var userResult = _userService.Register(dto);
                if (userResult.HasViolation)
                {
                    return new StudioHostServiceResult(userResult.RuleViolations);
                }
                var user = userResult.User;
                var studioHost = new StudioHost() { UserId = user.GUID, StudioHostName = dto.StudioHostName };
                _studioHostRepository.Add(studioHost);
                return new StudioHostServiceResult() { StudioHost = studioHost };
            });
        }
    }
}

