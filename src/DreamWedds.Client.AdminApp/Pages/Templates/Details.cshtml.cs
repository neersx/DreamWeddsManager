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
    public class DetailsModel : PageModel
    {
        private readonly DreamWedds.Client.AdminApp.Data.ApplicationDbContext _context;

        public DetailsModel(DreamWedds.Client.AdminApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public TemplateMaster TemplateMaster { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.TemplateMaster == null)
            {
                return NotFound();
            }

            var templatemaster = await _context.TemplateMaster.FirstOrDefaultAsync(m => m.Id == id);
            if (templatemaster == null)
            {
                return NotFound();
            }
            else 
            {
                TemplateMaster = templatemaster;
            }
            return Page();
        }
    }
}
