using DreamWeddsManager.Domain.Contracts;
using System.ComponentModel.DataAnnotations;
namespace DreamWeddsManager.Domain.Entities.DreamWedds
{

    public class TimeLine : AuditableEntity<int>
    {
        public System.DateTime StoryDate { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Story { get; set; }
        [MaxLength(500)]
        public string ImageUrl { get; set; }
        public int WeddingID { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }
    
        public virtual Wedding Wedding { get; set; }
    }
}
