using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DreamWedds.Client.AdminApp.Data;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWedds.Client.AdminApp.Pages.Templates.Comments
{
    public class DeleteModel : PageModel
    {
        private readonly DreamWedds.Client.AdminApp.Data.ApplicationDbContext _context;

        public DeleteModel(DreamWedds.Client.AdminApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TemplateComments TemplateComments { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TemplateComments == null)
            {
                return NotFound();
            }

            var templatecomments = await _context.TemplateComments.FirstOrDefaultAsync(m => m.Id == id);

            if (templatecomments == null)
            {
                return NotFound();
            }
            else 
            {
                TemplateComments = templatecomments;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.TemplateComments == null)
            {
                return NotFound();
            }
            var templatecomments = await _context.TemplateComments.FindAsync(id);

            if (templatecomments != null)
            {
                TemplateComments = templatecomments;
                _context.TemplateComments.Remove(TemplateComments);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
