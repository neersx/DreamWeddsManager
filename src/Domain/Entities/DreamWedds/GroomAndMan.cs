using System;
using System.Collections.Generic;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    public partial class GroomAndMan : AuditableEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int WeddingID { get; set; }
        public bool IsGroom { get; set; }
        public int? RelationWithGroom { get; set; }
        public string Imageurl { get; set; }
        public string AboutMen { get; set; }
        public string fbUrl { get; set; }
        public string googleUrl { get; set; }
        public string instagramUrl { get; set; }
        public string lnkedinUrl { get; set; }
    
        public virtual Wedding Wedding { get; set; }
    }
}
