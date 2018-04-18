using Infrastructure.Services;
using YYP.Dto;
using YYP.Entities;

namespace YYP.Services
{
	public interface IStudioHostService : IService<StudioHost>
	{
        StudioHostServiceResult Register(RegisterDto dto);
        StudioHostServiceResult GetById(string userId);
        StudioHostServiceResult Update(StudioHostDto dto);
    }
}

