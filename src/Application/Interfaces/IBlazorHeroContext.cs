using DreamWeddsManager.Domain.Entities;
using DreamWeddsManager.Domain.Entities.ExtendedAttributes;
using DreamWeddsManager.Domain.Entities.Misc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DreamWeddsManager.Shared.Constants.Permission.Permissions;

namespace DreamWeddsManager.Application.Interfaces
{
    public interface IBlazorHeroContext
    {
        DbSet<KeyValue> KeyValues { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<DocumentExtendedAttribute> DocumentExtendedAttributes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
