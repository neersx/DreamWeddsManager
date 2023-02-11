
namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    
    public partial class Blog : AuditableEntity<int>
    {
        public string BlogName { get; set; }
        public string Title { get; set; }
        public string BlogSubject { get; set; }
        public string Quote { get; set; }
        public string AuthorName { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int BlogType { get; set; } = 0;
        public string SpecialNote { get; set; }
      
    }
}
