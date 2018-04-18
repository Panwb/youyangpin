using System.Collections.Generic;
using Infrastructure.DomainModel;
using Infrastructure.Services;
using YYP.ComLib.Services;
using YYP.Dto;
using YYP.Entities;
using YYP.Repository;

namespace YYP.Services
{
	public class StudioHostService : ServiceBase<StudioHost>,IStudioHostService
	{		
		private readonly IStudioHostRepository _studioHostRepository;
        private readonly IUserService _userService;
        private readonly IWorkContext _workContext;
		
		public StudioHostService(IStudioHostRepository studioHostRepository, IUserService userService, IWorkContext workContext)
		{
			this._studioHostRepository = studioHostRepository;
            this._userService = userService;
            _workContext = workContext;
		}

        public StudioHostServiceResult GetById(string userId)
        {
            return ExecuteCommand(() =>
            {
                return new StudioHostServiceResult(_studioHostRepository.GetById(userId));
            });
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

        public StudioHostServiceResult Update(StudioHostDto dto)
        {
            return ExecuteCommand(() =>
            {
                var result = new StudioHostServiceResult();
                var user = _workContext.CurrentUser;
                var studioHost = _studioHostRepository.GetById(user.GUID);
                if (studioHost == null)
                {
                    result.RuleViolations.Add(new RuleViolation("", "更新用户信息失败"));
                    return result;
                }
                studioHost.StudioHostName = dto.StudioHostName;
                studioHost.AlipayAccount = dto.AlipayAccount;
                studioHost.Weight = dto.Weight;
                studioHost.Height = dto.Height;
                studioHost.ShoeSize = dto.ShoeSize;
                studioHost.ClothesSize = dto.ClothesSize;
                studioHost.Address = dto.Address;
                studioHost.LinkmanName = dto.LinkmanName;
                studioHost.LinkmanPhone = dto.LinkmanPhone;
                studioHost.TKName = dto.TKName;
                studioHost.WeChat = dto.WeChat;
                studioHost.QQ = dto.QQ;
                studioHost.VerticalFieldCode = dto.VerticalFieldCode;
                studioHost.DailyBeginTime = dto.DailyBeginTime;
                studioHost.DailyEndTime = dto.DailyEndTime;
                _studioHostRepository.Update(studioHost);
                return result;
            });
        }
    }
}

