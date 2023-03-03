using DreamWeddsManager.Application.Interfaces.Services;
using DreamWeddsManager.Application.Models.Chat;
using DreamWeddsManager.Infrastructure.Models.Identity;
using DreamWeddsManager.Domain.Contracts;
using DreamWeddsManager.Domain.Entities.Catalog;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DreamWeddsManager.Domain.Entities.ExtendedAttributes;
using DreamWeddsManager.Domain.Entities.Misc;
using DreamWeddsManager.Domain.Entities.DreamWedds;
using DreamWeddsManager.Application.Interfaces;
using DreamWeddsManager.Domain.Entities;

namespace DreamWeddsManager.Infrastructure.Contexts
{
    public class BlazorHeroContext : AuditableContext, IBlazorHeroContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;

        public BlazorHeroContext(DbContextOptions<BlazorHeroContext> options, 
            ICurrentUserService currentUserService, 
            IDateTimeService dateTimeService)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }

        public DbSet<KeyValue> KeyValues { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentExtendedAttribute> DocumentExtendedAttributes { get; set; }
        public DbSet<ChatHistory<BlazorHeroUser>> ChatHistories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }


        #region Region | DreamWedds database entities
        public DbSet<BrideAndMaid> BrideAndMaid { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogComments> BlogComments { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<GroomAndMan> GroomAndMan { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderMaster> OrderMaster { get; set; }
        public DbSet<RsvpDetail> RsvpDetail { get; set; }
        public DbSet<SubscriptionMaster> SubscriptionMaster { get; set; }
        public DbSet<TemplateImage> TemplateImage { get; set; }
        public DbSet<TemplateMaster> TemplateMaster { get; set; }
        public DbSet<TemplateComments> TemplateComments { get; set; }
        public DbSet<TemplateMergeField> TemplateMergeField { get; set; }
        public DbSet<TimeLine> TimeLine { get; set; }
        public DbSet<UserWeddingSubscription> UserWeddingSubscription { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Wedding> Wedding { get; set; }
        public DbSet<WeddingEvent> WeddingEvent { get; set; }
        public DbSet<WeddingImages> WeddingImages { get; set; }
        public DbSet<MetaTags> MetaTags { get; set; }

        #endregion

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTimeService.NowUtc;
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTimeService.NowUtc;
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        break;
                }
            }
            if (_currentUserService.UserId == null)
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return await base.SaveChangesAsync(_currentUserService.UserId, cancellationToken);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }
            base.OnModelCreating(builder);
            builder.Entity<ChatHistory<BlazorHeroUser>>(entity =>
            {
                entity.ToTable("ChatHistory");

                entity.HasOne(d => d.FromUser)
                    .WithMany(p => p.ChatHistoryFromUsers)
                    .HasForeignKey(d => d.FromUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ToUser)
                    .WithMany(p => p.ChatHistoryToUsers)
                    .HasForeignKey(d => d.ToUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
            builder.Entity<BlazorHeroUser>(entity =>
            {
                entity.ToTable(name: "Users", "Identity");
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            builder.Entity<BlazorHeroRole>(entity =>
            {
                entity.ToTable(name: "Roles", "Identity");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles", "Identity");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims", "Identity");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins", "Identity");
            });

            builder.Entity<BlazorHeroRoleClaim>(entity =>
            {
                entity.ToTable(name: "RoleClaims", "Identity");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens", "Identity");
            });
        }
    }
}