using System.Collections.Generic;
using System.Threading.Tasks;
using DreamWeddsManager.Application.Features.DocumentTypes.Commands.AddEdit;
using DreamWeddsManager.Application.Features.DocumentTypes.Queries.GetAll;
using DreamWeddsManager.Shared.Wrapper;

namespace DreamWeddsManager.Client.Infrastructure.Managers.Misc.DocumentType
{
    public interface IDocumentTypeManager : IManager
    {
        Task<IResult<List<GetAllDocumentTypesResponse>>> GetAllAsync();

        Task<IResult<int>> SaveAsync(AddEditDocumentTypeCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}