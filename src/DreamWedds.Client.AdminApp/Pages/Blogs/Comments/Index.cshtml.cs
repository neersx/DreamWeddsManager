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
    public class IndexModel : PageModel
    {
        private readonly DreamWedds.Client.AdminApp.Data.ApplicationDbContext _context;

        public IndexModel(DreamWedds.Client.AdminApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BlogComments> BlogComments { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BlogComments != null)
            {
                BlogComments = await _context.BlogComments
                .Include(b => b.Blog).ToListAsync();
            }
        }
    }
}
