using AutoMapper;
using DreamWeddsManager.Application.Features.Products.Commands.AddEdit;
using DreamWeddsManager.Domain.Entities.Catalog;

namespace DreamWeddsManager.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}