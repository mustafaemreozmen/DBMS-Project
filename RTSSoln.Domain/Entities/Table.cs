using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class Table: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int SizeW { get; set; }
        public int SizeH { get; set; }
        public Guid FloorId { get; set; }
    }
}
