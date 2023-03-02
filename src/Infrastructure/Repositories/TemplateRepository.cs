using DreamWeddsManager.Application.Interfaces.Repositories;
using DreamWeddsManager.Domain.Entities.Catalog;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWeddsManager.Infrastructure.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly IRepositoryAsync<TemplateMaster, int> _repository;

        public TemplateRepository(IRepositoryAsync<TemplateMaster, int> repository)
        {
            _repository = repository;
        }
    }
}