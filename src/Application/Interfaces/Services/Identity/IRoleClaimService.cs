using System.Collections.Generic;
using System.Threading.Tasks;
using DreamWeddsManager.Application.Interfaces.Common;
using DreamWeddsManager.Application.Requests.Identity;
using DreamWeddsManager.Application.Responses.Identity;
using DreamWeddsManager.Shared.Wrapper;

namespace DreamWeddsManager.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}