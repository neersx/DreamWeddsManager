using AutoMapper;
using DreamWeddsManager.Infrastructure.Models.Identity;
using DreamWeddsManager.Application.Responses.Identity;

namespace DreamWeddsManager.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorHeroRole>().ReverseMap();
        }
    }
}