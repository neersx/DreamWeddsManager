﻿using DreamWeddsManager.Application.Extensions;
using DreamWeddsManager.Application.Features.Common.Queries;
using DreamWeddsManager.Application.Features.Templates.Queries;
using DreamWeddsManager.Application.Utilities;

namespace DreamWedds.Client.WebApp.Pages
{
    public class IndexModel : BasePageModel<IndexModel>
    {

        public async Task OnGetAsync()
        {
            var Templates = await _mediator.Send(new GetAllTemplatesQuery());
            ViewData["Templates"] = Templates.Data.ToList().Take(4);

            var MetaTags = await _mediator.Send(new GetAllMetaTagsByPageNameQuery(KnownValues.KnownHtmlPage.Home));
            string MetagTagsString = HtmlPageExtensions.GetMetadataString(MetaTags.Data) ;
            ViewData["LoadMetaTag"] = MetagTagsString;
        }
    }
}