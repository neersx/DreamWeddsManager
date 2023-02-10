using DreamWeddsManager.Shared.Settings;
using System.Threading.Tasks;
using DreamWeddsManager.Shared.Wrapper;

namespace DreamWeddsManager.Shared.Managers
{
    public interface IPreferenceManager
    {
        Task SetPreference(IPreference preference);

        Task<IPreference> GetPreference();

        Task<IResult> ChangeLanguageAsync(string languageCode);
    }
}