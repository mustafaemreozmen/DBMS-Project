using System;
using System.Collections.Generic;
using System.Text;

namespace RTSSoln.Domain.Entities
{
    public class Reservation: BaseEntity
    {
        public Guid TableId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime ReservationTime { get; set; }
    }
}
