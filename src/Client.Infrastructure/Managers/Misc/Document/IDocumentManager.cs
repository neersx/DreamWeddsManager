using DreamWeddsManager.Application.Features.Documents.Commands.AddEdit;
using DreamWeddsManager.Application.Features.Documents.Queries.GetAll;
using DreamWeddsManager.Application.Requests.Documents;
using DreamWeddsManager.Shared.Wrapper;
using System.Threading.Tasks;
using DreamWeddsManager.Application.Features.Documents.Queries.GetById;

namespace DreamWeddsManager.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}