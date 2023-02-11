using DreamWeddsManager.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{

    public class WeddingTemplate : AuditableEntity<int>
    {
        public WeddingTemplate()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
            this.TemplateImages = new HashSet<TemplateImage>();
            this.TemplateMergeFields = new HashSet<TemplateMergeField>();
            //this.TemplatePages = new HashSet<TemplatePage>();
            this.UserWeddingSubscriptions = new HashSet<UserWeddingSubscription>();
        }
        [MaxLength(250)]
        public string Name { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        [MaxLength(2500)]
        public string Content { get; set; }
        [MaxLength(250)]
        public string Subject { get; set; }
        [MaxLength(250)]
        public string Tags { get; set; }
        [MaxLength(500)]
        public string TemplateUrl { get; set; }
        [MaxLength(250)]
        public string TemplateFolderPath { get; set; }
        [MaxLength(500)]
        public string ThumbnailImageUrl { get; set; }
        [MaxLength(250)]
        public string TagLine { get; set; }
        public int? Cost { get; set; }
        [MaxLength(150)]
        public string AuthorName { get; set; }
        [MaxLength(250)]
        public string AboutTemplate { get; set; }
        [MaxLength(500)]
        public string Features { get; set; }
      
        public Nullable<int> TemplateCode { get; set; }
    
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<TemplateImage> TemplateImages { get; set; }
        public virtual ICollection<TemplateMergeField> TemplateMergeFields { get; set; }
        //public virtual ICollection<TemplatePage> TemplatePages { get; set; }
        public virtual ICollection<UserWeddingSubscription> UserWeddingSubscriptions { get; set; }
    }
}
