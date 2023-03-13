using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DreamWedds.Client.AdminApp.Data;
using DreamWeddsManager.Domain.Entities.DreamWedds;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DreamWeddsManager.Application.Requests;
using DreamWeddsManager.Application.Enums;

namespace DreamWedds.Client.AdminApp.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public AddEditMetatagCommand Input { get; set; }
        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MetaTags MetaTags { get; set; } = default!;

        public async Task OnGetAsync(int? id)
        {

            var metatags =  await _context.MetaTags.FirstOrDefaultAsync(m => m.Id == id);
            MetaTags = metatags;
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (UploadedFile != null)
            {
                Input.UploadRequest = new UploadRequest();
                Input.UploadRequest.FileName = UploadedFile.FileName;
                Input.UploadRequest.UploadType = UploadType.Document;
                var stream = new MemoryStream();
                UploadedFile.CopyTo(stream);
                Input.UploadRequest.Data = stream.ToArray();
            }

            _context.Attach(MetaTags).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetaTagsExists(MetaTags.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MetaTagsExists(int id)
        {
          return (_context.MetaTags?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }

    public class AddEditMetatagCommand 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [MaxLength(50)]
        public string Property { get; set; }
        [MaxLength(20)]
        public string TagPrefix { get; set; } // fb, og, twitter
        public string Content { get; set; }
        [MaxLength(200)]
        public string PageName { get; set; }
        [MaxLength(250)]
        public string PageTitle { get; set; }
        public bool IsImage { get; set; }
        [MaxLength(20)]
        public string Type { get; set; } // meta, stylesheet, preload, dns-prefetch 
        public string TypeId { get; set; } // id if link type
        public UploadRequest UploadRequest { get; set; }
    }
}
