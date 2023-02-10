using DreamWeddsManager.Application.Interfaces.Common;

namespace DreamWeddsManager.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}