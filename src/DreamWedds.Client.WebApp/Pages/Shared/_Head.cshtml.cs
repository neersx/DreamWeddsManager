using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DreamWedds.Client.WebApp.Pages.Shared
{
    public class _HeadModel : PageModel
    {
        public void OnGet()
        {
            ViewData["title"] = "This is test title for meta data check.";
        }
    }
}
