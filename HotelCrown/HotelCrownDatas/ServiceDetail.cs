using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.HotelCrownDatas
{
    [Table("ServiceDetails")]
    public class ServiceDetail
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Quantity { get; set; }

        public override string ToString()
        {
            return "Customer: " + Customer.FullName + " " + Service.ServiceName + " " + Quantity + " unit";
        }
    }
}
