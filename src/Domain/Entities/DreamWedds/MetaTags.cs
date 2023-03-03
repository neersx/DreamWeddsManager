using DreamWeddsManager.Domain.Contracts;
using System.ComponentModel.DataAnnotations;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    public class MetaTags :  AuditableEntity<int>
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Property { get; set; }
        [MaxLength(20)]
        public string TagPrefix { get; set; } // fb, og, twitter
        public string Content { get; set; }
        public string PageName { get; set; }
        public string PageTitle { get; set; }
        public bool IsImage { get; set; }
        public string Type { get; set; } // meta, stylesheet, preload, dns-prefetch 
        public string TypeId { get; set; } // id if link type

        public virtual Blog Blog { get; set; }
        public virtual TemplateMaster TemplateMaster { get; set; }

    }
}
