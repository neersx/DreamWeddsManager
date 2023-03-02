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
            var Blogs = await _mediator.Send(new GetBlogByNameQuery(title));
            Detail = Blogs.Data;
        }
    }
}
