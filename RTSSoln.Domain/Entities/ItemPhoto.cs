using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class ItemPhoto: BaseEntity
    {
        public string Uri { get; set; }
        public Guid MenuItemId { get; set; }
    }
}
