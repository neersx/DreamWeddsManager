using AutoMapper;
using DreamWeddsManager.Application.Enums;
using DreamWeddsManager.Application.Features.Brands.Queries.GetAll;
using DreamWeddsManager.Application.Interfaces.Repositories;
using DreamWeddsManager.Domain.Entities.Catalog;
using DreamWeddsManager.Domain.Entities.DreamWedds;
using DreamWeddsManager.Shared.Constants.Application;
using DreamWeddsManager.Shared.Wrapper;
using LazyCache;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWeddsManager.Application.Features.Blogs.Queries
{

    public class GetAllBlogsQuery : IRequest<Result<List<GetAllBlogsResponse>>>
    {
        public GetAllBlogsQuery()
        {
        }
    }

    internal class GetAllBlogsCachedQueryHandler : IRequestHandler<GetAllBlogsQuery, Result<List<GetAllBlogsResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllBlogsCachedQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllBlogsResponse>>> Handle(GetAllBlogsQuery request, CancellationToken cancellationToken)
        {
            Func<Task<List<Blog>>> getAllBlogs = () => _unitOfWork.Repository<Blog>().GetAllAsync();
            var list = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllBlogsCacheKey, getAllBlogs);
            var mappedBlogs = _mapper.Map<List<GetAllBlogsResponse>>(list);
            return await Result<List<GetAllBlogsResponse>>.SuccessAsync(mappedBlogs);
        }
    }

    public class GetAllBlogsResponse
    {
        public string BlogName { get; set; }
        public string Title { get; set; }
        public string BlogSubject { get; set; }
        public string Quote { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int BlogType { get; set; } = 0;
        public string SpecialNote { get; set; }
    }
}
