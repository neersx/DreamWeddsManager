using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DreamWedds.Client.AdminApp.Data;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWedds.Client.AdminApp.Pages.Blogs
{
    public class DetailsModel : PageModel
    {
        private readonly DreamWedds.Client.AdminApp.Data.ApplicationDbContext _context;

        public DetailsModel(DreamWedds.Client.AdminApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Blog Blog { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Blogs == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FirstOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            else 
            {
                Blog = blog;
            }
            return Page();
        }
    }
}
