using System;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    public partial class RSVPDetail : AuditableEntity<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool IsComing { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? GuestCount { get; set; }
        public byte PreferredFood { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string SpecialNote { get; set; }
        public string ImageUrl { get; set; }
        public int WeddingID { get; set; }
        public string ParticipatingInEvents { get; set; }
        public string ComingFromCity { get; set; }
        public int? PreferredStayIn { get; set; }
    
        public virtual Wedding Wedding { get; set; }
    }
}
