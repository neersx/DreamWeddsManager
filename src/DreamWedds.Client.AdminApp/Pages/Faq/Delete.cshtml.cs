using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DreamWedds.Client.AdminApp.Data;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWedds.Client.AdminApp.Pages.Faq
{
    public class DeleteModel : PageModel
    {
        private readonly DreamWedds.Client.AdminApp.Data.ApplicationDbContext _context;

        public DeleteModel(DreamWedds.Client.AdminApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DreamWeddsManager.Domain.Entities.DreamWedds.Faq Faq { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Faqs == null)
            {
                return NotFound();
            }

            var faq = await _context.Faqs.FirstOrDefaultAsync(m => m.Id == id);

            if (faq == null)
            {
                return NotFound();
            }
            else 
            {
                Faq = faq;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Faqs == null)
            {
                return NotFound();
            }
            var faq = await _context.Faqs.FindAsync(id);

            if (faq != null)
            {
                Faq = faq;
                _context.Faqs.Remove(Faq);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
