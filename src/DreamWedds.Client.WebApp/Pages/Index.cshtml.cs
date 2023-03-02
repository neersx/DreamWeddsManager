using DreamWeddsManager.Application.Features.Brands.Queries.GetAll;
using DreamWeddsManager.Application.Features.Templates.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DreamWedds.Client.WebApp.Pages
{
    public class IndexModel : BasePageModel<IndexModel>
    {

        public async Task OnGetAsync()
        {
            var Templates = await _mediator.Send(new GetAllTemplatesQuery());
            ViewData["Templates"] = Templates.Data.ToList().Take(4);
            ViewData["LoadMetaTag"] = BindMetaTag();
            
        }

        private string BindMetaTag()
        {
            System.Text.StringBuilder strDynamicMetaTag = new System.Text.StringBuilder();
            strDynamicMetaTag.AppendFormat(@"<meta content='{0}' name='Keywords'/>", "Dotnet-helpers");
            strDynamicMetaTag.AppendFormat(@"<meta content='{0}' name='Descption'/>", "creating meta tags dynamically in" + " asp.net mvc by dotnet-helpers.com");
            return strDynamicMetaTag.ToString();
        }
    }
}