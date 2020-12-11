using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class Floor: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid FloorTypeId { get; set; }
    }
}
