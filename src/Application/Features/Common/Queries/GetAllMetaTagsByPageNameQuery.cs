using AutoMapper;
using DreamWeddsManager.Application.Interfaces.Repositories;
using DreamWeddsManager.Domain.Entities.DreamWedds;
using DreamWeddsManager.Shared.Constants.Application;
using DreamWeddsManager.Shared.Wrapper;
using LazyCache;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DreamWeddsManager.Application.Features.Common.Queries
{
    public class GetAllMetaTagsByPageNameQuery : IRequest<Result<List<GetAllMetaTagsResponse>>>
    {
        public string PageName { get; set; }

        public GetAllMetaTagsByPageNameQuery(string pageName)
        {
            PageName = pageName;
        }
    }

    internal class GetAllMetaTagsCachedQueryHandler
        : IRequestHandler<GetAllMetaTagsByPageNameQuery, Result<List<GetAllMetaTagsResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppCache _cache;

        public GetAllMetaTagsCachedQueryHandler(
            IUnitOfWork<int> unitOfWork,
            IMapper mapper,
            IAppCache cache
        )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
        }

        public async Task<Result<List<GetAllMetaTagsResponse>>> Handle(
            GetAllMetaTagsByPageNameQuery query,
            CancellationToken cancellationToken
        )
        {
            Func<Task<List<MetaTags>>> GetAllMetaTags = async () => await _unitOfWork.Repository<MetaTags>().Entities.Where(x => x.PageName == query.PageName).ToListAsync();
            var list = await _cache.GetOrAddAsync(
                ApplicationConstants.Cache.GetAllMetaTagsCacheKey,
                GetAllMetaTags
            );
            var mappedBlogs = _mapper.Map<List<GetAllMetaTagsResponse>>(list);
            return await Result<List<GetAllMetaTagsResponse>>.SuccessAsync(mappedBlogs);
        }
    }

    public class GetAllMetaTagsResponse
    {
        public string Name { get; set; }
        public string Property { get; set; }
        public string TagPrefix { get; set; } // fb, og, twitter
        public string Content { get; set; }
        public string PageName { get; set; }
        public string PageTitle { get; set; }
        public bool IsImage { get; set; }
        public string Type { get; set; } // meta, stylesheet, preload, dns-prefetch 
        public string TypeId { get; set; } // id if link type
    }
}
