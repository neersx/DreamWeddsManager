using System.Linq;
using DreamWeddsManager.Shared.Constants.Localization;
using DreamWeddsManager.Shared.Settings;

namespace DreamWeddsManager.Server.Settings
{
    public record ServerPreference : IPreference
    {
        public string LanguageCode { get; set; } = LocalizationConstants.SupportedLanguages.FirstOrDefault()?.Code ?? "en-US";

        //TODO - add server preferences
    }
}