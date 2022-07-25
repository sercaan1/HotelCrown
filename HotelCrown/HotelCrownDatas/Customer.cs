using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.HotelCrownDatas
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int IdentityNumber { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string Description { get; set; }
        public Nullable<int> ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
        public virtual ICollection<Service> Services { get; set; } = new List<Service>();
        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();


        public override string ToString()
        {
            return FullName;
        }
    }
}
