﻿using DreamWeddsManager.Domain.Contracts;

namespace DreamWeddsManager.Domain.Entities.Catalog
{
    public class Brand : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Tax { get; set; }
    }
}