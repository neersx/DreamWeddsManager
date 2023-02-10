using AutoMapper;
using DreamWeddsManager.Application.Features.Documents.Commands.AddEdit;
using DreamWeddsManager.Application.Features.Documents.Queries.GetById;
using DreamWeddsManager.Domain.Entities.Misc;

namespace DreamWeddsManager.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
            CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
        }
    }
}