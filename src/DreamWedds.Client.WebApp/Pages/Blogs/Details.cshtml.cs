using DreamWeddsManager.Application.Extensions;
using DreamWeddsManager.Application.Features.Blogs.Queries;

namespace DreamWedds.Client.WebApp.Pages.Blogs
{
    public class DetailsModel : BasePageModel<DetailsModel>
    {
        public GetBlogByIdResponse Detail { get; set; }
        public async Task OnGetAsync(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception("Incorrect url");
            title = title.Replace('-', ' ').ToUpper();
            var Blogs = await _mediator.Send(new GetBlogByNameQuery(title));
            Detail = Blogs.Data;
            ViewData["LoadMetaTag"] = HtmlPageExtensions.GetMetadataString(Detail.MetaTags.ToList(), Detail.Title);
            var result = await _mediator.Send(new GetAllBlogsQuery());
            ViewData["Blogs"] = result.Data.ToList();
        }
    }
}
