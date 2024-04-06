using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRSCleanArchitecture.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int? Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset? DateUpdate { get; set; }
        public DateTimeOffset? DateDeleted { get; set; }
    }
}
