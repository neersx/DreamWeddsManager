using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DreamWedds.Client.AdminApp.Data;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWedds.Client.AdminApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly DreamWedds.Client.AdminApp.Data.ApplicationDbContext _context;

        public DeleteModel(DreamWedds.Client.AdminApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public MetaTags MetaTags { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.MetaTags == null)
            {
                return NotFound();
            }

            var metatags = await _context.MetaTags.FirstOrDefaultAsync(m => m.Id == id);

            if (metatags == null)
            {
                return NotFound();
            }
            else 
            {
                MetaTags = metatags;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.MetaTags == null)
            {
                return NotFound();
            }
            var metatags = await _context.MetaTags.FindAsync(id);

            if (metatags != null)
            {
                MetaTags = metatags;
                _context.MetaTags.Remove(MetaTags);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
