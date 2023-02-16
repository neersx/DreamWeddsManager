using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace DreamWedds.Client.WebApp.Pages.Shared.Components.ImportExcel
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
