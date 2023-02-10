using DreamWeddsManager.Application.Features.Products.Commands.AddEdit;
using DreamWeddsManager.Application.Features.Products.Queries.GetAllPaged;
using DreamWeddsManager.Application.Requests.Catalog;
using DreamWeddsManager.Shared.Wrapper;
using System.Threading.Tasks;

namespace DreamWeddsManager.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}