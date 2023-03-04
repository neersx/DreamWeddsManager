using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DreamWedds.Client.AdminApp.Data;
using DreamWeddsManager.Domain.Entities.DreamWedds;

namespace DreamWedds.Client.AdminApp.Pages.Templates
{
    public class IndexModel : PageModel
    {
        private readonly DreamWedds.Client.AdminApp.Data.ApplicationDbContext _context;

        public IndexModel(DreamWedds.Client.AdminApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TemplateMaster> TemplateMaster { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.TemplateMaster != null)
            {
                TemplateMaster = await _context.TemplateMaster.ToListAsync();
            }
        }
    }
}
