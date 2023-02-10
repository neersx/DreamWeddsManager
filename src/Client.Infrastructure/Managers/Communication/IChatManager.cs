using DreamWeddsManager.Application.Models.Chat;
using DreamWeddsManager.Application.Responses.Identity;
using DreamWeddsManager.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using DreamWeddsManager.Application.Interfaces.Chat;

namespace DreamWeddsManager.Client.Infrastructure.Managers.Communication
{
    public interface IChatManager : IManager
    {
        Task<IResult<IEnumerable<ChatUserResponse>>> GetChatUsersAsync();

        Task<IResult> SaveMessageAsync(ChatHistory<IChatUser> chatHistory);

        Task<IResult<IEnumerable<ChatHistoryResponse>>> GetChatHistoryAsync(string cId);
    }
}