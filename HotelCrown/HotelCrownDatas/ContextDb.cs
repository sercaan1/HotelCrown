using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.HotelCrownDatas
{
    public class ContextDb : DbContext
    {
        public ContextDb() : base("name=HotelCrown")
        {

        }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<ServiceDetail> ServiceDetails { get; set; }
    }
}
