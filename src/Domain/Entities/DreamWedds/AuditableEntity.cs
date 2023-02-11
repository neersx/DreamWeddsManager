using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamWeddsManager.Domain.Entities.DreamWedds
{
    public class AuditableEntity<TId>
    {
        public TId Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
