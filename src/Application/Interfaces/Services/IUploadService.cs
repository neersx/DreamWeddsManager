using DreamWeddsManager.Application.Requests;

namespace DreamWeddsManager.Application.Interfaces.Services
{
    public interface IUploadService
    {
        string UploadAsync(UploadRequest request);
    }
}