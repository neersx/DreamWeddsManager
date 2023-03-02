using DreamWeddsManager.Application.Features.Templates.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DreamWedds.Client.WebApp.Pages.Themes.Weddings
{
    public class IndexModel : BasePageModel<IndexModel>
    {
        public List<GetAllTemplatesResponse> Templates { get; set; }
        public async Task OnGetAsync()
        {
            var result = await _mediator.Send(new GetAllTemplatesQuery());
            if (result == null)
                throw new Exception("No Wedding Tempaltes available to display.");
            Templates = result.Data.ToList();
        }
    }
}
