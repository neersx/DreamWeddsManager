


using AutoMapper;
using DreamWeddsManager.Application.Features.Templates.Queries;
using DreamWeddsManager.Application.Features.Templates.Queries.GetById;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWeddsManager.Application.Mappings
{
    public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {
            // CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetTemplateByIdResponse, TemplateMaster>().ReverseMap();
            CreateMap<GetAllTemplatesResponse, TemplateMaster>().ReverseMap();
        }
    }
}