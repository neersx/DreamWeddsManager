using DreamWeddsManager.Domain.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    public partial class GroomAndMan : AuditableEntity<int>
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        public DateTime? DateofBirth { get; set; }
        public int WeddingID { get; set; }
        public bool IsGroom { get; set; }
        public int? RelationWithGroom { get; set; }
        [MaxLength(1000)]
        public string Imageurl { get; set; }
        [MaxLength(1250)]
        public string About { get; set; }
        [MaxLength(250)]
        public string FbUrl { get; set; }
        [MaxLength(500)]
        public string GoogleUrl { get; set; }
        [MaxLength(250)]
        public string InstagramUrl { get; set; }
        [MaxLength(250)]
        public string LinkedinUrl { get; set; }

        public virtual Wedding Wedding { get; set; }
    }
}
