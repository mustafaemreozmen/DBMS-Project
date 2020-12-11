using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class Customer: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
    }
}
