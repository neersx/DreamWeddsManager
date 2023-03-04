using AutoMapper;
using DreamWeddsManager.Application.Features.Common.Queries;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWeddsManager.Application.Mappings
{
    public class MetatagsProfile : Profile
    {
        public MetatagsProfile()
        {
            // CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            // CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllMetaTagsResponse, MetaTags>().ReverseMap();
        }
    }
}