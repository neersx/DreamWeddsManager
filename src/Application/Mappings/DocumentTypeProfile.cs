using AutoMapper;
using DreamWeddsManager.Application.Features.DocumentTypes.Commands.AddEdit;
using DreamWeddsManager.Application.Features.DocumentTypes.Queries.GetAll;
using DreamWeddsManager.Application.Features.DocumentTypes.Queries.GetById;
using DreamWeddsManager.Domain.Entities.Misc;

namespace DreamWeddsManager.Application.Mappings
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
            CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
            CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
        }
    }
}