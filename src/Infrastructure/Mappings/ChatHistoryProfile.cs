using AutoMapper;
using DreamWeddsManager.Application.Interfaces.Chat;
using DreamWeddsManager.Application.Models.Chat;
using DreamWeddsManager.Infrastructure.Models.Identity;

namespace DreamWeddsManager.Infrastructure.Mappings
{
    public class ChatHistoryProfile : Profile
    {
        public ChatHistoryProfile()
        {
            CreateMap<ChatHistory<IChatUser>, ChatHistory<BlazorHeroUser>>().ReverseMap();
        }
    }
}