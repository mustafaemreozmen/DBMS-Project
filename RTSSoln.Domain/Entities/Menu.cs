using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class Menu: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
