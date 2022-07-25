using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.HotelCrownDatas
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Feature> Features { get; set; } = new List<Feature>();
        
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        public override string ToString()
        {
            return RoomName;
        }
    }
}
