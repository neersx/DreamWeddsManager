


using AutoMapper;
using DreamWeddsManager.Application.Features.Blogs.Queries;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWeddsManager.Application.Mappings
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            // CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBlogByIdResponse, Blog>().ReverseMap();
            CreateMap<GetAllBlogsResponse, Blog>().ReverseMap();
        }
    }
}