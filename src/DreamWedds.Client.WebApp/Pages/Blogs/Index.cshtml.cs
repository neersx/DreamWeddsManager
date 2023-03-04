using DreamWeddsManager.Application.Features.Blogs.Queries;
using DreamWeddsManager.Application.Features.Common.Queries;
using DreamWeddsManager.Application.Utilities;
using DreamWeddsManager.Application.Extensions;

namespace DreamWedds.Client.WebApp.Pages.Blogs
{
    public class IndexModel : BasePageModel<IndexModel>
    {
        public List<GetAllBlogsResponse> Blogs { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _mediator.Send(new GetAllBlogsQuery());
            if (result == null)
                throw new Exception("No Blogs available to display.");
            Blogs = result.Data.ToList();

            var MetaTags = await _mediator.Send(
                new GetAllMetaTagsByPageNameQuery(KnownValues.KnownHtmlPage.Blog)
            );
            string MetagTagsString = HtmlPageExtensions.GetMetadataString(MetaTags.Data);
            ViewData["LoadMetaTag"] = MetagTagsString;
        }
    }
}
