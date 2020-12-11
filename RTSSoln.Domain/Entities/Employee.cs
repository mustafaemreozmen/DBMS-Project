using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
