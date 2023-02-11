using System;
namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    public partial class UserWeddingSubscription : AuditableEntity<int>
    {
        public int UserId { get; set; }
        public int TemplateID { get; set; }
        public int? InvoiceNo { get; set; }
        public int? WeddingID { get; set; }
        public int SubscriptionType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ReasonOfUpdate { get; set; }
        public int SubscriptionStatus { get; set; }
    
        public virtual OrderMaster OrderMaster { get; set; }
        public virtual SubscriptionMaster SubscriptionMaster { get; set; }
        public virtual WeddingTemplate TemplateMaster { get; set; }
        public virtual Wedding Wedding { get; set; }
    }
}
