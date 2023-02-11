using DreamWeddsManager.Domain.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    public class WeddingImages : AuditableEntity<int>
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        public int WeddingID { get; set; }
        [MaxLength(500)]
        public string ImageUrl { get; set; }
        public DateTime? DateTaken { get; set; }
        [MaxLength(100)]
        public string Place { get; set; }

        public virtual Wedding Wedding { get; set; }
    }
}
