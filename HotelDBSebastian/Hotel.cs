using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDBSebastian
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }

        public override string ToString()
        {
            return $"{nameof(HotelId)}: {HotelId}, {nameof(HotelName)}: {HotelName}, {nameof(HotelAddress)}: {HotelAddress}";
        }
    }
}
