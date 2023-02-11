using DreamWeddsManager.Domain.Contracts;
using System.ComponentModel.DataAnnotations;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    public class Venue : AuditableEntity<int>
    {
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string ImageUrl { get; set; }
        [MaxLength(500)]
        public string BannerImageUrl { get; set; }
        [MaxLength(500)]
        public string Website { get; set; }
        [MaxLength(150)]
        public string OwnerName { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        [MaxLength(15)]
        public string Mobile { get; set; }
        public int? WeddingEventID { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(1500)]
        public string GoogleMapUrl { get; set; }
    
        public virtual WeddingEvent WeddingEvent { get; set; }
    }
}
