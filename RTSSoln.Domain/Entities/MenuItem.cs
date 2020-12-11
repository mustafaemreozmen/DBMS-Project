using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class MenuItem: BaseEntity
    {
        public string Title { get; set; }
        public Guid ProductId { get; set; }
        public Guid MenuId { get; set; }
    }
}
