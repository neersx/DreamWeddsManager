using DreamWeddsManager.Application.Extensions;
using DreamWeddsManager.Application.Features.Common.Queries;
using DreamWeddsManager.Application.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DreamWedds.Client.WebApp.Pages
{
    public class FaqModel : BasePageModel<FaqModel>
    {
        public async Task OnGet()
        {
            var MetaTags = await _mediator.Send(new GetAllMetaTagsByPageNameQuery(KnownValues.KnownHtmlPage.Faq));
            string MetagTagsString = HtmlPageExtensions.GetMetadataString(MetaTags.Data) ;
            ViewData["LoadMetaTag"] = MetagTagsString;
        }
    }
}
