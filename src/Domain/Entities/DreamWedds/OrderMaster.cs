using System;
using System.Collections.Generic;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    
    public partial class OrderMaster : AuditableEntity<int>
    {
        public OrderMaster()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.UserWeddingSubscriptions = new HashSet<UserWeddingSubscription>();
        }

        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string OrderStatus { get; set; }
        public string AddressID { get; set; }
        public int? CGST { get; set; }
        public int? SGST { get; set; }
        public int? Discount { get; set; }
        public decimal Amount { get; set; }
        public decimal? ReceivedAmount { get; set; }
        public int? PaymentMode { get; set; }
        public string PaymentTerms { get; set; }
        public string OderNote { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<UserWeddingSubscription> UserWeddingSubscriptions { get; set; }
        //public virtual User UserMaster { get; set; }
    }
}
