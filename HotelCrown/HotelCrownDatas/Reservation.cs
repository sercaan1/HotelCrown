using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.HotelCrownDatas
{
    public class Reservation
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public DateTime? CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        public DateTime? CheckedInTime { get; set; }
        public DateTime? CheckedOutTime { get; set; }
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        public override string ToString()
        {
            return string.Join(", ", Customers) + " " + ((DateTime)CheckInDate).ToShortDateString() + "-" + ((DateTime)CheckOutDate).ToShortDateString();
        }
    }
}
