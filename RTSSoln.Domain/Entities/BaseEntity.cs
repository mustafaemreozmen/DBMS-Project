using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Creator { get; set; }
        public DateTime Modified { get; set; }
        public string Modifier { get; set; }
    }
}
