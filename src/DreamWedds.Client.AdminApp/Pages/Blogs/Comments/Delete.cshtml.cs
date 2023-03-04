using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DreamWedds.Client.AdminApp.Data;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWedds.Client.AdminApp.Pages.Blogs.Comments
{
    public class DeleteModel : PageModel
    {
        private readonly DreamWedds.Client.AdminApp.Data.ApplicationDbContext _context;

        public DeleteModel(DreamWedds.Client.AdminApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BlogComments BlogComments { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BlogComments == null)
            {
                return NotFound();
            }

            var blogcomments = await _context.BlogComments.FirstOrDefaultAsync(m => m.Id == id);

            if (blogcomments == null)
            {
                return NotFound();
            }
            else 
            {
                BlogComments = blogcomments;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BlogComments == null)
            {
                return NotFound();
            }
            var blogcomments = await _context.BlogComments.FindAsync(id);

            if (blogcomments != null)
            {
                BlogComments = blogcomments;
                _context.BlogComments.Remove(BlogComments);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
