
using DreamWeddsManager.Domain.Contracts;
using System.ComponentModel.DataAnnotations;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    public class Blog : AuditableEntity<int>
    {
        [Required]
        [MaxLength(150)]
        public string BlogName { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        [MaxLength(250)]
        public string BlogSubject { get; set; }
        [MaxLength(500)]
        public string Quote { get; set; }
        [MaxLength(150)]
        public string AuthorName { get; set; }
        public string Content { get; set; }
        [MaxLength(500)]
        public string ImageUrl { get; set; }
        public int BlogType { get; set; } = 0;
        [MaxLength(250)]
        public string SpecialNote { get; set; }
      
    }
}
