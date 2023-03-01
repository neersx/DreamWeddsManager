using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DreamWedds.Client.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

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