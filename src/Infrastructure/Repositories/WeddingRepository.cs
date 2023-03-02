using DreamWeddsManager.Application.Interfaces.Repositories;
using DreamWeddsManager.Domain.Entities.Catalog;
using DreamWeddsManager.Domain.Entities.DreamWedds;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DreamWeddsManager.Infrastructure.Repositories
{
    public class WeddingRepository : IWeddingRepository
    {
        private readonly IRepositoryAsync<Wedding, int> _repository;

        public WeddingRepository(IRepositoryAsync<Wedding, int> repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsTemplateUsed(int templateId)
        {
            return await _repository.Entities.AnyAsync(b => b.TemplateID == templateId);
        }
    }
}