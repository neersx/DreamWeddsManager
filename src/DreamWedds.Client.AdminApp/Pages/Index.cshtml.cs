using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DreamWedds.Client.AdminApp.Data;
using DreamWeddsManager.Domain.Entities.DreamWedds;
using DreamWeddsManager.Application.Interfaces.Services;
using DreamWeddsManager.Application.Requests;

namespace DreamWedds.Client.AdminApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IUploadService _uploadService;
        public IndexModel(ApplicationDbContext context, IUploadService uploadService)
        {
            _context = context;
            _uploadService = uploadService;
        }

        [BindProperty]
        public AddEditMetatagCommand Input { get; set; }

        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public IList<MetaTags> MetaTags { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.MetaTags != null)
            {
                MetaTags = await _context.MetaTags.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            if (UploadedFile != null)
            {
                Input.UploadRequest = new UploadRequest();
                Input.UploadRequest.FileName = UploadedFile.FileName;
                var stream = new MemoryStream();
                UploadedFile.CopyTo(stream);
                Input.UploadRequest.Data = stream.ToArray();
                var result = _uploadService.UploadAsync(Input.UploadRequest);

                
                var meta = await _context.MetaTags.FirstOrDefaultAsync(m => m.Id == Input.Id);
                meta.Content = result;
                _context.Attach(meta).State = EntityState.Modified;
                await _context.SaveChangesAsync(cancellationToken);
                return new JsonResult(meta);
            }

            return new JsonResult(Input);
        }
    }
}
