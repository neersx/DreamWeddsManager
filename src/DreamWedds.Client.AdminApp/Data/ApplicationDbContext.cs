using DreamWeddsManager.Domain.Entities.DreamWedds;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DreamWedds.Client.AdminApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MetaTags> MetaTags { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<BlogComments> BlogComments { get; set; }
        public DbSet<TemplateMaster> TemplateMaster { get; set; }
        public DbSet<TemplateComments> TemplateComments { get; set; }
    }
}