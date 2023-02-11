using DreamWeddsManager.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    public partial class Wedding : AuditableEntity<int>
    {
        public Wedding()
        {
            this.BrideAndMaids = new HashSet<BrideAndMaid>();
            this.GroomAndMen = new HashSet<GroomAndMan>();
            this.RsvpDetails = new HashSet<RsvpDetail>();
            this.TimeLines = new HashSet<TimeLine>();
            this.UserWeddingSubscriptions = new HashSet<UserWeddingSubscription>();
            this.WeddingEvents = new HashSet<WeddingEvent>();
            this.WeddingGalleries = new HashSet<WeddingImages>();
        }
        public DateTime WeddingDate { get; set; }
        [MaxLength(250)]
        [Required]
        public string Title { get; set; }
        public int WeddingStyle { get; set; }
        [MaxLength(500)]
        public string IconUrl { get; set; }
        public int? TemplateID { get; set; }
        public bool IsLoveMarriage { get; set; }
        public int? UserID { get; set; }
        public bool IsActive { get; set; }
        [MaxLength(500)]
        public string BackgroundImage { get; set; }
        [MaxLength(500)]
        public string Quote { get; set; }
        [MaxLength(250)]
        public string FbPageUrl { get; set; }
        [MaxLength(250)]
        public string VideoUrl { get; set; }
    
        public virtual ICollection<BrideAndMaid> BrideAndMaids { get; set; }
        public virtual ICollection<GroomAndMan> GroomAndMen { get; set; }
        public virtual ICollection<RsvpDetail> RsvpDetails { get; set; }
        public virtual ICollection<TimeLine> TimeLines { get; set; }
        public virtual ICollection<UserWeddingSubscription> UserWeddingSubscriptions { get; set; }
        public virtual ICollection<WeddingEvent> WeddingEvents { get; set; }
        public virtual ICollection<WeddingImages> WeddingGalleries { get; set; }
    }
}
