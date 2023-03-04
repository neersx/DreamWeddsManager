using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DreamWedds.Client.AdminApp.Data;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWedds.Client.AdminApp.Pages.Templates.Comments
{
    public class CreateModel : PageModel
    {
        private readonly DreamWedds.Client.AdminApp.Data.ApplicationDbContext _context;

        public CreateModel(DreamWedds.Client.AdminApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["TemplateId"] = new SelectList(_context.TemplateMaster, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public TemplateComments TemplateComments { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.TemplateComments == null || TemplateComments == null)
            {
                return Page();
            }

            _context.TemplateComments.Add(TemplateComments);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
