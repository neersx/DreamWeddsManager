using System.Threading.Tasks;

namespace DreamWeddsManager.Application.Interfaces.Repositories
{
    public interface IWeddingRepository
    {
        Task<bool> IsTemplateUsed(int brandId);
    }
}
