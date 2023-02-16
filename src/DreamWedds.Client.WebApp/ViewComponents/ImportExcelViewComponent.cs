using DreamWedds.Client.WebApp.Pages.Shared.Components.ImportExcel;
using Microsoft.AspNetCore.Mvc;

namespace DreamWedds.Client.WebApp.ViewComponents
{
    public class ImportExcelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string importUri,string getTemplateUri,string onImportedSucceeded)
        {
            return View(new DefaultModel() { ImportUri = importUri ,
                GetTemplateUri = getTemplateUri,
                OnImportedSucceeded= onImportedSucceeded });
        }
    }
}
