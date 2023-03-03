using AutoMapper;
using DreamWeddsManager.Application.Features.Blogs.Queries;
using DreamWeddsManager.Application.Interfaces.Repositories;
using DreamWeddsManager.Domain.Entities.DreamWedds;
using DreamWeddsManager.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWeddsManager.Application.Features.Blogs.Queries
{
    public class GetBlogByNameQuery : IRequest<Result<GetBlogByIdResponse>>
    {
        public string Name { get; set; }
        public GetBlogByNameQuery(string name)
        {
            Name = name;
        }
    }

    internal class GetBlogByNameQueryHandler : IRequestHandler<GetBlogByNameQuery, Result<GetBlogByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetBlogByNameQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetBlogByIdResponse>> Handle(GetBlogByNameQuery query, CancellationToken cancellationToken)
        {
            var Blog = await _unitOfWork.Repository<Blog>().FindByAsync(name => name.BlogName == query.Name);
            var mappedBlog = _mapper.Map<GetBlogByIdResponse>(Blog);
            return await Result<GetBlogByIdResponse>.SuccessAsync(mappedBlog);
        }
    }

        public class GetBlogByIdResponse
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
        public DateTime CreatedOn { get; set; }
    }

}
