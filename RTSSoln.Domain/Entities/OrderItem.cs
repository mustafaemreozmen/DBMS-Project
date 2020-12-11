using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class OrderItem: BaseEntity
    {
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public string Notes { get; set; }
    }
}
