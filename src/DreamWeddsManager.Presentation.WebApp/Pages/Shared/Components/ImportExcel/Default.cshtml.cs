using System.ComponentModel.DataAnnotations;

namespace SmartAdmin.WebUI.Pages.Shared.Components.ImportExcel
{
    public class DefaultModel 
    {
        [BindProperty, Display(Name = "File")]
        public IFormFile UploadedFile { get; set; }
        public string ImportUri { get; set; }
        public string GetTemplateUri { get; set; }
        public string AntiForgeryToken { get; set; }
        public string OnImportedSucceeded { get; set; }
    }
}
