using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelCrown.HotelCrownDatas
{
    public class Feature
    {
        public int Id { get; set; }
        public string FeatureName { get; set; }
        public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();

        public override string ToString()
        {
            return FeatureName;
        }
    }
}
