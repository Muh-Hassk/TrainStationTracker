using System;
using System.Collections.Generic;

namespace TrainStationTracker.API.Data
{
    public partial class Trip
    {
        public decimal Tripid { get; set; }
        public decimal Originstationid { get; set; }
        public decimal Destinationstationid { get; set; }
        public DateTime Departuretime { get; set; }
        public decimal Duratointime { get; set; }
        public decimal Availableseats { get; set; }
        public DateTime? Createdat { get; set; }
        public decimal Price { get; set; }

        public virtual Trainstation Destinationstation { get; set; } = null!;
        public virtual Trainstation Originstation { get; set; } = null!;
    }
}
