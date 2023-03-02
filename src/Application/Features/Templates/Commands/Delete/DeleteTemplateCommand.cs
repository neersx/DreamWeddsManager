using DreamWeddsManager.Application.Interfaces.Repositories;
using DreamWeddsManager.Domain.Entities.Catalog;
using DreamWeddsManager.Shared.Wrapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Localization;
using DreamWeddsManager.Shared.Constants.Application;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWeddsManager.Application.Features.Templates.Commands.Delete
{
    public class DeleteTemplateCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
    }

    internal class DeleteTemplateCommandHandler : IRequestHandler<DeleteTemplateCommand, Result<int>>
    {
        private readonly IWeddingRepository _weddingRepository;
        private readonly IStringLocalizer<DeleteTemplateCommandHandler> _localizer;
        private readonly IUnitOfWork<int> _unitOfWork;

        public DeleteTemplateCommandHandler(IUnitOfWork<int> unitOfWork, IWeddingRepository weddingRepository, IStringLocalizer<DeleteTemplateCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _weddingRepository = weddingRepository;
            _localizer = localizer;
        }

        public async Task<Result<int>> Handle(DeleteTemplateCommand command, CancellationToken cancellationToken)
        {
            var isTemplateUsed = await _weddingRepository.IsTemplateUsed(command.Id);
            if (!isTemplateUsed)
            {
                var Template = await _unitOfWork.Repository<TemplateMaster>().GetByIdAsync(command.Id);
                if (Template != null)
                {
                    await _unitOfWork.Repository<TemplateMaster>().DeleteAsync(Template);
                    await _unitOfWork.CommitAndRemoveCache(cancellationToken, ApplicationConstants.Cache.GetAllTemplatesCacheKey);
                    return await Result<int>.SuccessAsync(Template.Id, _localizer["Template Deleted"]);
                }
                else
                {
                    return await Result<int>.FailAsync(_localizer["Template Not Found!"]);
                }
            }
            else
            {
                return await Result<int>.FailAsync(_localizer["Deletion Not Allowed"]);
            }
        }
    }
}