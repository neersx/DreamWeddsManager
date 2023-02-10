using System.Collections.Generic;
using System.Threading.Tasks;
using DreamWeddsManager.Application.Requests.Identity;
using DreamWeddsManager.Application.Responses.Identity;
using DreamWeddsManager.Shared.Wrapper;

namespace DreamWeddsManager.Client.Infrastructure.Managers.Identity.RoleClaims
{
    public interface IRoleClaimManager : IManager
    {
        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

        Task<IResult<string>> SaveAsync(RoleClaimRequest role);

        Task<IResult<string>> DeleteAsync(string id);
    }
}