using DreamWeddsManager.Shared.Wrapper;
using System.Threading.Tasks;
using DreamWeddsManager.Application.Features.Dashboards.Queries.GetData;

namespace DreamWeddsManager.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}