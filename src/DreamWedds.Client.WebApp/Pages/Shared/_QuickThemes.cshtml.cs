using DreamWeddsManager.Application.Features.Templates.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DreamWedds.Client.WebApp.Pages.Shared
{
    public class _QuickThemesModel : PageModel
    {
        public async Task OnGet()
        {
            //var templates = await _mediator.Send(new GetAllTemplatesQuery());
            //ViewData["Templates"] = templates;
        }
    }
}
