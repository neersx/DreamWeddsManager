using DreamWeddsManager.Application.Requests.Mail;
using System.Threading.Tasks;

namespace DreamWeddsManager.Application.Interfaces.Services
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}