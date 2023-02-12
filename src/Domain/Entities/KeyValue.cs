using DreamWeddsManager.Domain.Contracts;
using System;
using System.Collections.Generic;

namespace DreamWeddsManager.Domain.Entities
{
    public class KeyValue : AuditableEntity<int>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        //public List<DomainEvent> DomainEvents { get; set; } = new();
    }
}
