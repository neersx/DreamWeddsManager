//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    using System;
    using System.Collections.Generic;
    
    public partial class WeddingGallery : AuditableEntity<int>
    {
        public string ImageTitle { get; set; }
        public int WeddingID { get; set; }
        public string ImageUrl { get; set; }
        public string ImageName { get; set; }
        public Nullable<System.DateTime> DateTaken { get; set; }
        public string Place { get; set; }
    
        public virtual Wedding Wedding { get; set; }
    }
}
