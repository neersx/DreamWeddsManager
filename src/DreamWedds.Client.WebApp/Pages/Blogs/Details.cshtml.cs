using DreamWeddsManager.Application.Features.Blogs.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DreamWedds.Client.WebApp.Pages.Blogs
{
    public class DetailsModel : BasePageModel<DetailsModel>
    {
        public GetBlogByIdResponse Detail { get; set; }

        public async Task OnGetAsync(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new Exception("In correct url");
            title = title.Replace('-', ' ').ToUpper();
            var Blogs = await _mediator.Send(new GetBlogByNameQuery(title));
            Detail = Blogs.Data;
            var result = await _mediator.Send(new GetAllBlogsQuery());
            ViewData["Blogs"] = result.Data.ToList();
        }
    }
}
