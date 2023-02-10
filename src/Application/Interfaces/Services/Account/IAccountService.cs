using DreamWeddsManager.Application.Interfaces.Common;
using DreamWeddsManager.Application.Requests.Identity;
using DreamWeddsManager.Shared.Wrapper;
using System.Threading.Tasks;

namespace DreamWeddsManager.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}