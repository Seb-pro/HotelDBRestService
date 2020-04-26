using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDBSebastian
{
    public class Facility
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }

        public override string ToString()
        {
            return $"{nameof(FacilityId)}: {FacilityId}, {nameof(FacilityName)}: {FacilityName}";
        }
    }
}
