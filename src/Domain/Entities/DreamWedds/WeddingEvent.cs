using DreamWeddsManager.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{   
    public partial class WeddingEvent : AuditableEntity<int>
    {
        public WeddingEvent()
        {
            this.Venues = new HashSet<Venue>();
        }

        public DateTime EventDate { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        public int WeddingID { get; set; }
        [MaxLength(500)]
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [MaxLength(1500)]
        public string Aboutevent { get; set; }
        [MaxLength(500)]
        public string BackGroundImage { get; set; }
    
        public virtual Wedding Wedding { get; set; }
        public virtual ICollection<Venue> Venues { get; set; }
    }
}
