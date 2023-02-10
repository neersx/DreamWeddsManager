using AutoMapper;
using DreamWeddsManager.Infrastructure.Models.Audit;
using DreamWeddsManager.Application.Responses.Audit;

namespace DreamWeddsManager.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}