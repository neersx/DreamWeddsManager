using DreamWeddsManager.Application.Extensions;
using DreamWeddsManager.Application.Features.Common.Queries;
using DreamWeddsManager.Application.Utilities;

namespace DreamWedds.Client.WebApp.Pages
{
    public class ContactUsModel : BasePageModel<ContactUsModel>
    {
        public async Task OnGet()
        {
            var MetaTags = await _mediator.Send(new GetAllMetaTagsByPageNameQuery(KnownValues.KnownHtmlPage.ContactUs));
            string MetagTagsString = HtmlPageExtensions.GetMetadataString(MetaTags.Data) ;
            ViewData["LoadMetaTag"] = MetagTagsString;
        }
    }
}
