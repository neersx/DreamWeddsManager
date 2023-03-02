using AutoMapper;
using DreamWeddsManager.Application.Features.Templates.Queries.GetById;
using DreamWeddsManager.Application.Interfaces.Repositories;
using DreamWeddsManager.Domain.Entities.DreamWedds;
using DreamWeddsManager.Shared.Wrapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWeddsManager.Application.Features.Templates.Queries
{
    public class GetTemplateByNameQuery : IRequest<Result<GetTemplateByIdResponse>>
    {
        public string Name { get; set; }
        public GetTemplateByNameQuery(string name)
        {
            Name = name;
        }
    }

    internal class GetTemplateByNameQueryHandler : IRequestHandler<GetTemplateByNameQuery, Result<GetTemplateByIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetTemplateByNameQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetTemplateByIdResponse>> Handle(GetTemplateByNameQuery query, CancellationToken cancellationToken)
        {
            var Template = await _unitOfWork.Repository<TemplateMaster>().FindByAsync(name => name.Name == query.Name);
            var mappedTemplate = _mapper.Map<GetTemplateByIdResponse>(Template);
            return await Result<GetTemplateByIdResponse>.SuccessAsync(mappedTemplate);
        }
    }

}
