using System.Globalization;

namespace DreamWedds.Client.WebApp.Pages.Shared.Components.LanguageSelector
{

    public class DefaultModel
    {
        public CultureInfo CurrentUICulture { get; set; }
        public List<CultureInfo> SupportedCultures { get; set; }
    }

}
