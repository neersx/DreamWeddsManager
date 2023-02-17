using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DreamWedds.Client.WebApp.Pages.Themes.Weddings
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public IndexModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
