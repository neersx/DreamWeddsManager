using DreamWeddsManager.Application.Features.Blogs.Queries;
using DreamWeddsManager.Application.Features.Templates.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        }
    }
}
