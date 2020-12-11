using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class Order: BaseEntity
    {
        public Guid TableId { get; set; }
        public Guid OrderStatusId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
