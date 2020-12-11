using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class Payment: BaseEntity
    {
        public Guid CashRegisterId { get; set; }
        public Guid TableId { get; set; }
        public decimal Price { get; set; }
    }
}
