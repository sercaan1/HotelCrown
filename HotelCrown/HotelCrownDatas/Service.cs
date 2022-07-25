using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.HotelCrownDatas
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public virtual ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();

        public override string ToString()
        {
            return ServiceName;
        }
    }
}
