using AutoMapper;
using DreamWeddsManager.Application.Requests.Identity;
using DreamWeddsManager.Application.Responses.Identity;

namespace DreamWeddsManager.Client.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            CreateMap<RoleClaimResponse, RoleClaimRequest>().ReverseMap();
        }
    }
}