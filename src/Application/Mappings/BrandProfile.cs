using AutoMapper;
using DreamWeddsManager.Application.Features.Brands.Commands.AddEdit;
using DreamWeddsManager.Application.Features.Brands.Queries.GetAll;
using DreamWeddsManager.Application.Features.Brands.Queries.GetById;
using DreamWeddsManager.Domain.Entities.Catalog;

namespace DreamWeddsManager.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}