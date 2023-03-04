using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DreamWedds.Client.AdminApp.Data;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWedds.Client.AdminApp.Pages.Faq
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
            return Page();
        }

        [BindProperty]
        public DreamWeddsManager.Domain.Entities.DreamWedds.Faq Faq { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Faqs == null || Faq == null)
            {
                return Page();
            }

            _context.Faqs.Add(Faq);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
