using DreamWeddsManager.Application.Features.Templates.Queries;
using DreamWeddsManager.Application.Features.Templates.Queries.GetById;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DreamWedds.Client.WebApp.Pages.Themes.Weddings
{
    public class DetailsModel : BasePageModel<DetailsModel>
    {
        public GetTemplateByIdResponse Detail { get; set; }
        public async Task OnGetAsync(string name)
        {
            var Templates = await _mediator.Send(new GetTemplateByNameQuery(name));
            Detail = Templates.Data;
        }
    }
}
