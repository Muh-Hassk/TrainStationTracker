using System;
using System.Collections.Generic;

namespace TrainStationTracker.API.Data
{
    public partial class Booking
    {
        public decimal Bookingid { get; set; }
        public decimal Userid { get; set; }
        public decimal Tripid { get; set; }
        public DateTime? Bookingtime { get; set; }
        public string Paymentstatus { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
