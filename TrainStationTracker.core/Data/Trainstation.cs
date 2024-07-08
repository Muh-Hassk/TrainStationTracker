using System;
using System.Collections.Generic;

namespace TrainStationTracker.core.Data
{
    public partial class Trainstation
    {
        public Trainstation()
        {
            TripDestinationstations = new HashSet<Trip>();
            TripOriginstations = new HashSet<Trip>();
        }

        public decimal Stationid { get; set; }
        public string Stationname { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime? Createdat { get; set; }

        public virtual ICollection<Trip> TripDestinationstations { get; set; }
        public virtual ICollection<Trip> TripOriginstations { get; set; }
    }
}
