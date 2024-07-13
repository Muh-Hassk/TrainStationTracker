using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainStationTracker.core.DTO
{
    public class TripsDTO
    {
        public decimal Tripid { get; set; }
        public decimal Originstationid { get; set; }
        public decimal Destinationstationid { get; set; }
        public DateTime Departuretime { get; set; }
        public decimal Duratointime { get; set; }
        public decimal Availableseats { get; set; }
        public DateTime? Createdat { get; set; }
        public decimal Price { get; set; }
    }
}
