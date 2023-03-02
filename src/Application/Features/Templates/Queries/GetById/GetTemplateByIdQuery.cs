using AutoMapper;
using DreamWeddsManager.Application.Interfaces.Repositories;
using DreamWeddsManager.Domain.Entities.Catalog;
using DreamWeddsManager.Domain.Entities.DreamWedds;
using DreamWeddsManager.Shared.Wrapper;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace DreamWeddsManager.Application.Features.Templates.Queries.GetById
{
    public class GetTemplateByIdQuery : IRequest<Result<GetTemplateByIdResponse>>
    {
        public int Id { get; set; }
        public GetTemplateByIdQuery(int id)
        {
            Id = id;
        }
    }

    internal class GetTemplateByIdQueryHandler : IRequestHandler<GetTemplateByIdQuery, Result<GetTemplateByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetTemplateByIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetTemplateByIdResponse>> Handle(GetTemplateByIdQuery query, CancellationToken cancellationToken)
        {
            var Template = await _unitOfWork.Repository<TemplateMaster>().GetByIdAsync(query.Id);
            var mappedTemplate = _mapper.Map<GetTemplateByIdResponse>(Template);
            return await Result<GetTemplateByIdResponse>.SuccessAsync(mappedTemplate);
        }
    }

    public class GetTemplateByIdResponse
    {
        [MaxLength(250)]
        public string Name { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        [MaxLength(2500)]
        public string Content { get; set; }
        [MaxLength(250)]
        public string Subject { get; set; }
        [MaxLength(250)]
        public string Tags { get; set; }
        [MaxLength(500)]
        public string TemplateUrl { get; set; }
        [MaxLength(500)]
        public string ThumbnailImageUrl { get; set; }
        [MaxLength(250)]
        public string TagLine { get; set; }
        public int? Cost { get; set; }
        public string Features { get; set; }
        public string AuthorName { get; set; }
         public string AboutTemplate { get; set; }
    }
}